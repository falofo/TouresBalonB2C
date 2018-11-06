using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouresBalonB2C.Controllers
{
    public class HomeController : ControllerUtil
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Titulo = "Bienvenido a TouresBalon";
            return View();
        }
        
    }
    
}