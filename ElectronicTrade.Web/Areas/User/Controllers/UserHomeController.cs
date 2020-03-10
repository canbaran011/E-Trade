using ElectronicTrade.BusinessLayer.OperationManagers;
using ElectronicTrade.BusinessLayer.Result;
using ElectronicTrade.BusinessLayer.Utilities;
using ElectronicTrade.BusinessLayer.ValidationRules.FluentValidation.VirtualViewModel;
using ElectronicTrade.Entities;
using ElectronicTrade.Entities.Messages;
using ElectronicTrade.Entities.ViewModels.NotificationViewModel.NotificationTypes;
using ElectronicTrade.Entities.ViewModels.VirtualViewModel;
using ElectronicTrade.Web.UIOperations;
using ElectronicTrade.Web.UIOperations.SessionOperations;
using ElectronicTrade.Web.UIOperations.UploadOperations.ImageUploads.MemberImageUploads;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicTrade.Web.Areas.User.Controllers
{
    public class UserHomeController : Controller
    {
        ProductManager mngr_product = new ProductManager();
        CategoryManager mngr_category = new CategoryManager();
        MemberManager mngr_member = new MemberManager();
        public ActionResult Index()
        {
            return View();
        }

        //Logins Operations//
        #region

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            ValidationResult result = ValidationTool.Validate(new LoginViewModelValidator(), model);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model);
            }

            BusinessLayerResult<Member> res = mngr_member.LogInUser(model);

            if (res.Errors.Count > 0)
            {

                if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                {
                    ViewBag.SetLink = "http://Home/Activate/12365-8925-56565";
                }


                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message)); //Tüm Errors List inde Foreach ile dön herbiri için ilgili string i (x yani) ModelState in Error üne ekle.

                return View(model);
            }

            CurrentSession.Set<Member>("LogIn", res.Result);  // TODO :  Yonlendirme yada Session a kullanıcı bilgisi atılacak
            return RedirectToAction("Profile", "UserHome");
        }

        #endregion

        //Registrations Operations//
        #region

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            ValidationResult result = ValidationTool.Validate(new RegisterViewModelValidator(), model);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            BusinessLayerResult<Member> res = mngr_member.RegisterUser(model);

            if (res.Errors.Count > 0)
            {
                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message)); //Tüm Errors List inde Foreach ile dön herbiri için ilgili string i (x yani) ModelState in Error üne ekle.

                return View(model);
            }

            MemberImageUploadManager.UserProfileImageFolderCreate(res.Result.Id);

            SuccessfulOperationsViewModel successful_notify = new SuccessfulOperationsViewModel()
            {
                Header = "INFORMATION",
                title = "Please Activate Your Account.",
                RedirectingUrl = "Home/Index",
                RedirectingTimeout = 5000,
                Items = new List<SuccessfulMessageObject>()
                    {
                        new SuccessfulMessageObject(){Message = "Successful Operations One"},
                        new SuccessfulMessageObject(){Message="Successful Operations Two"}
                    },
                IsRedirecting = false
            };

            return View("SuccessfulNotificationPage", successful_notify);

        }

        #endregion

        //UserActivations Operations//
        #region

        [HttpGet]
        public ActionResult UserActivate(Guid id)
        {
            BusinessLayerResult<Member> res = mngr_member.ActivateUser(id);

            if (res.Errors.Count > 0)
            {
                ErrorOperationsViewModel error_notifyobj = new ErrorOperationsViewModel()
                {
                    title = "Invalid Operation!",
                    text = "Your process was rejected by the system!",
                    Items = res.Errors,
                    RedirectingUrl = "/Home/Index",
                    RedirectingTimeout = 5000

                };

                return View("ErrorNotificationPage", error_notifyobj);
            }

            SuccessfulOperationsViewModel successful_notify = new SuccessfulOperationsViewModel()
            {
                Header = "INFORMATION",
                title = "Your Account has been activated.",
                RedirectingUrl = "Home/Index",
                RedirectingTimeout = 5000,
                Items = new List<SuccessfulMessageObject>()
                    {
                        new SuccessfulMessageObject(){Message = "Successful Operations One"},
                        new SuccessfulMessageObject(){Message="Successful Operations Two"}
                    },
                IsRedirecting = false
            };

            return View("SuccessfulNotificationPage", successful_notify);


        }

        #endregion

        //Logout Operations//
        #region
        public ActionResult LogOut()
        {
            return View();
        }

        #endregion

        //Profile Operations//
        #region
        public new ActionResult Profile()
        {
            return View();
        }

        #endregion


        //Operasyonların yazılımı

    }
}