using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBDeskDemos.SimpleSPA.Web.Controllers
{
    public class SPADemoController : Controller
    {
        //
        // GET: /SPADemo/
        public ActionResult Index()
        {
            return View();
        }

         public ActionResult V1(string id)
        {
            return View();
        }
         public ActionResult V2(string id)
         {
             return View();
         }
	}
}