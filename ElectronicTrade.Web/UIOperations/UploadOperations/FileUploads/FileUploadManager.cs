using ElectronicTrade.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ElectronicTrade.Web.UIOperations.UploadOperations.FileUploads
{
    public static class FileUploadManager
    {

        public static bool ResumePDFUpload(HttpPostedFileBase ResumeFile)
        {
            if (ResumeFile != null && (ResumeFile.ContentType == "application/pdf"))
            {
                string filename = $"user_{Guid.NewGuid()}.{ResumeFile.ContentType.Split('/')[1]}";

                ResumeFile.SaveAs(HttpContext.Current.Server.MapPath($"~/Files/Upload/{filename}"));
                return true;
            }

            return false;
        }

        public static bool ResumeAjaxUpload(HttpPostedFileBase ResumeFile)
        {
            if (Directory.Exists(HttpContext.Current.Server.MapPath("~/Files/Upload")) == false)
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Files/Upload"));
            }

            if (ResumeFile != null && (ResumeFile.ContentType == "application/pdf"))
            {
                //ResumeFile.SaveAs(Path.Combine(HttpContext.Current.Server.MapPath("~/Files/Upload"), ResumeFile.FileName)); //Combine ile path ile dosya adini birleştirir.Full path yapar Combine.
                string filename = $"user_{Guid.NewGuid()}.{ResumeFile.ContentType.Split('/')[1]}"; //Biz gelen dosyanın adını değiştirip Guid atamayı tercih ettik.

                ResumeFile.SaveAs(HttpContext.Current.Server.MapPath($"~/Files/Upload/{filename}"));
                return true;
            }

            return false;
        }

    }
}