using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBDeskDemos.SimpleSPA.WebApp.Controllers
{
    public class SPADemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}