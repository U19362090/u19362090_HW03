using HW3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HW3.Controllers
{
    public class HomeController : Controller
    {

        // This returns us back to the home page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        // This gets the file as well as radio buttons inputs
        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase file)
        {                     
            
               
            // This checks if a file has been uploaded
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);

                // This checks the file type, if the radio button for image is selected and it is an image
                if( FileType == "Image")
                {
                    // Saves the uploaded image into the image folder
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File has been successfully uploaded";
                }
                // if the radio button for video is selected and it is a video
                else if ( FileType == "Video")
                {
                    // Save the uploaded video into the video folder
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Videos"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File has been successfully uploaded";
                }
                // if the radio button for document is selected and it is a document
                else if (FileType == "Document")
                {
                    // Save the uploaded document into the document folder
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File has been successfully uploaded";
                }
            }
            else
            {
                ViewBag.Message = "Please select a file type";
             
            }
            // after successfully uploading redirect the user return the user back to the HomeIndex view
            return View();
        }

        public ActionResult About()
        {
            return View();
        }



    }
}