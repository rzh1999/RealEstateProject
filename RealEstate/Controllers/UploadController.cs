using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<bool> UploadFile(IFormFile file)
        {
         
                if (file.Length > 0)
                {
                    string _fileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Directory.GetCurrentDirectory(), @"UploadedFiles", _fileName);
                    using (var filestream = new FileStream(_path, FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    return true;
                }

            return false;
        }
    }
}
