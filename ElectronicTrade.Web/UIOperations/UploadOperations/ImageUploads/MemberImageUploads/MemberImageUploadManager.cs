using ElectronicTrade.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ElectronicTrade.Web.UIOperations.UploadOperations.ImageUploads.MemberImageUploads
{
    public static class MemberImageUploadManager
    {
  
        public static void UserProfileImageFolderCreate(int UserId)
        {
            string foldername = "user_" + UserId.ToString();
            string folderpath = HttpContext.Current.Server.MapPath(string.Format("~/Images/Profile/MemberProfile/{0}", foldername));
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
        }

        public static void UserUpdateImageInsert(Member model, HttpPostedFileBase ProfileImage)
        {
            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"user_{model.Id}/user_{Guid.NewGuid()}.{ProfileImage.ContentType.Split('/')[1]}";

                ProfileImage.SaveAs(HttpContext.Current.Server.MapPath($"~/images/userimg/{filename}"));
                model.ProfileImageName = filename;

            }
        }

    }
}