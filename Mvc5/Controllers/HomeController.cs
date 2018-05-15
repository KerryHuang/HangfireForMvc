using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IBackgroundJobClient _jobClient;

        // For ASP.NET MVC
        //public HomeController()
        //    : this(new BackgroundJobClient())
        //{
        //}

        //public HomeController(IBackgroundJobClient jobClient)
        //{
        //    _jobClient = jobClient;
        //}

        public ActionResult Index()
        {
            //_jobClient.Enqueue(() => Console.WriteLine("Fire-and-forget!"));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}