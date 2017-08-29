using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicApplication.Models;

namespace MusicApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var musicFilePath = "~/Music/";
            var backGroundPaths = "~/Media/";
            var musicFileServerPath = Server.MapPath(musicFilePath);
            var backGroundFilePaths = Server.MapPath(backGroundPaths);
            var musicFiles= Directory.GetFiles(musicFileServerPath).Select(x => x.Replace(currentDirectory, "~/").Replace("\\", "/")).ToList();
            var backgroundFiles= Directory.GetFiles(backGroundFilePaths).Select(x => x.Replace(currentDirectory, "/").Replace("\\", "/")).ToList();
            ViewBag.MusicFilePath = musicFilePath;
            var model=new MusicAppHomeModel()
            {
                BackGroundPaths = backgroundFiles,
                MusicPaths = musicFiles
            };
            return View(model);
        }

        public ActionResult MyAudio(string fileName)
        {
            var file = Server.MapPath(fileName);
            return File(file, "audio/mp3");
        }

        
       
    }
    
}