using Lab2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {

            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));

            string[] fileNames = new string[files.Count()];



            var i = 0;

            foreach (var item in files)
            {
                //FileInfo info = new FileInfo(files[item]);
                FileInfo info = new FileInfo(files[i]);
                fileNames[i] = Path.GetFileNameWithoutExtension(info.Name);
                i++;
            }


            return View(fileNames);
        }






        public ActionResult DisplayContent(string id)
        {
            string selectedFile = Server.MapPath("~/TextFiles") + "\\" + id + ".txt";
            TextFile modelFile = new TextFile();
            modelFile.FileName = id + ".txt";
            modelFile.FileContent = System.IO.File.ReadAllText(@selectedFile);


            return View(modelFile);
        }
    }
}
