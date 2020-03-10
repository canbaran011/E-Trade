using ElectronicTrade.Entities;
using ElectronicTrade.Web.UIOperations.SessionOperations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ElectronicTrade.Web.UIOperations.UploadOperations.ImageUploads.ProductImageUploads
{
    public static class ProductImageUploadManager
    {
        public static void ProductImageInsert(Product product, HttpPostedFileBase ProfileImage)
        {
            string foldername = "article_" + CurrentSession.User.Id.ToString();
            string folderpath = HttpContext.Current.Server.MapPath(string.Format("~/images/articleimg/{0}", foldername));
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"article_{CurrentSession.User.Id}/article_{Guid.NewGuid()}.{ProfileImage.ContentType.Split('/')[1]}";

                ProfileImage.SaveAs(HttpContext.Current.Server.MapPath($"~/images/articleimg/{filename}"));
                product.productImages[0].FirstImageName = filename;

            }
        }

        public static bool ProductImageUpdate(Product product, HttpPostedFileBase ProfileImage)
        {
            string foldername = "article_" + CurrentSession.User.Id.ToString();
            string folderpath = HttpContext.Current.Server.MapPath(string.Format("~/images/articleimg/{0}", foldername));
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"article_{CurrentSession.User.Id}/article_{Guid.NewGuid()}.{ProfileImage.ContentType.Split('/')[1]}";

                ProfileImage.SaveAs(HttpContext.Current.Server.MapPath($"~/images/articleimg/{filename}"));
                product.productImages[0].FirstImageName = filename;

                return true;
            }

            return false;
        }

    }
}