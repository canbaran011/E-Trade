using ElectronicTrade.BusinessLayer.Abstract;
using ElectronicTrade.BusinessLayer.Result;
using ElectronicTrade.Common.Helpers;
using ElectronicTrade.Entities;
using ElectronicTrade.Entities.EntityEnums.UserStatus;
using ElectronicTrade.Entities.EntityEnums.UserTypes;
using ElectronicTrade.Entities.Messages;
using ElectronicTrade.Entities.ViewModels.VirtualViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.BusinessLayer.OperationManagers
{
    public class MemberManager : ManagerBase<Member>
    {
        BusinessLayerResult<Member> LayerResult = new BusinessLayerResult<Member>();

        //RegisterUser Method//
        #region

        public BusinessLayerResult<Member> RegisterUser(RegisterViewModel data)
        {

            data.Password = CryptoHelper.Manager(data.Password);

            Member user = Find(x => x.Username == data.Username || x.Email == data.Email);

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    LayerResult.AddErrorMessage(ErrorMessageCode.UsernameAlreadyExist, "Username already exist.");
                }
                if (user.Email == data.Email)
                {
                    LayerResult.AddErrorMessage(ErrorMessageCode.EmailAlreadyExist, "Email already exist.");
                }
            }
            else
            {
                int dbResult = base.Insert(new Member()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    Email = data.Email,
                    Password = data.Password,
                    Username = data.Username,
                    //Biography=,
                    ProfileImageName = "Images/Profile/MemberProfile",
                    UserBy = "System",
                    AddedDate = DateTime.Now,
                    //ModifiedDate=,
                    MemberType = UserType.Customer,
                    ActivateGuid = Guid.NewGuid(),
                    AccountStatus = UserStatusType.passive

                });

                if (dbResult > 0)
                {
                    LayerResult.Result = Find(x => x.Email == data.Email && x.Username == data.Username);
                    string siteurl = ConfigHelper.Get<string>("SiteRootUrl");
                    string activateurl = $"{siteurl}/User/UserHome/UserActivate/{LayerResult.Result.ActivateGuid}";
                    string messagebody = $"Hi {LayerResult.Result.Name} {LayerResult.Result.Surname};<br/><br/> plase click for activated your <a href='{activateurl}' target='_blank'>account</a>.";
                    MailHelper.SendMail(messagebody, LayerResult.Result.Email, "Electronic Trade active your account.");

                }
            }

            return LayerResult;

        }

        #endregion


        //UserActivate Method//
        #region

        public BusinessLayerResult<Member> ActivateUser(Guid activateId)
        {

            LayerResult.Result = Find(x => x.ActivateGuid == activateId);

            if (LayerResult.Result != null)
            {
                if (LayerResult.Result.AccountStatus == UserStatusType.active)
                {
                    LayerResult.AddErrorMessage(ErrorMessageCode.UserAlreadyActive, "User already active!");

                    return LayerResult;
                }

                LayerResult.Result.AccountStatus = UserStatusType.active;
                Update(LayerResult.Result);
            }
            else
            {
                LayerResult.AddErrorMessage(ErrorMessageCode.ActivateIdDoesNotExist, "No user to activate.");
            }

            return LayerResult;
        }

        #endregion


        //LoginUser Method//
        #region

        public BusinessLayerResult<Member> LogInUser(LoginViewModel data)
        {
            data.Password = CryptoHelper.Manager(data.Password);

            LayerResult.Result = Find(x => x.Email == data.Email && x.Password == data.Password);

            if (LayerResult.Result != null)
            {
                if (LayerResult.Result.AccountStatus == UserStatusType.passive)
                {
                    LayerResult.AddErrorMessage(ErrorMessageCode.UserIsNotActive, "User not activated.");
                    LayerResult.AddErrorMessage(ErrorMessageCode.CheckYourEmail, "Plase check your email.");
                }
                else if (LayerResult.Result.AccountStatus == UserStatusType.restricted)
                {
                    LayerResult.AddErrorMessage(ErrorMessageCode.UserIsNotActive, "Your account restricted.");
                    LayerResult.AddErrorMessage(ErrorMessageCode.CheckYourEmail, "Plase please contact us.");
                }
                else if (LayerResult.Result.AccountStatus == UserStatusType.banned)
                {
                    LayerResult.AddErrorMessage(ErrorMessageCode.UserIsNotActive, "Your account banned.");
                }
            }
            else
            {
                LayerResult.AddErrorMessage(ErrorMessageCode.UsernameOrPaswordNotMatch, "Username or password does not match.");
            }

            return LayerResult;
        }

        #endregion
    }
}
