using HW3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW3.Controllers
{
    public class ImageController : Controller
    {
        //  Get the file
        public ActionResult Index()
        {

            string[] filePaths = Directory.GetFiles(HttpContext.Server.MapPath("~/Media/Images/"));
            List<FileModel> fileList = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                FileModel filemodel = new FileModel();
                filemodel.FileName = Path.GetFileName(filePath);
                fileList.Add(filemodel);
            }

            return View(fileList);
        }

        public ActionResult Download(string FileName)
        {
            // Create/Build the file path
            string path = Server.MapPath("~/Media/Images/") + FileName;

            // Read the data of the file into a Byte Array
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            // Send the file so it can be downloaded
            return File(bytes, "application/octet-stream", FileName);

        }

        // Delete the file that was uploaded
        public ActionResult Delete(string FileName)
        {

            string fullPath = Request.MapPath("~/Media/Images/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Index");

        }
    }
}