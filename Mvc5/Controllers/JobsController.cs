using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 射後不理實作
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEnqueue()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));
            return RedirectToAction("Index", "Hangfire");
        }

        /// <summary>
        /// 延遲實作
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDelayed()
        {
            BackgroundJob.Schedule(() => Console.WriteLine("Hello, world. After a Days :)"), TimeSpan.FromDays(1));
            return RedirectToAction("Index", "Hangfire");
        }

        /// <summary>
        /// 定時實作
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRecurring()
        {
            RecurringJob.AddOrUpdate("Job-1", () => Console.Write("Easy!"), Cron.Minutely);
            return RedirectToAction("Index", "Hangfire");
        }

        /// <summary>
        /// 移除定時
        /// </summary>
        /// <returns></returns>
        public ActionResult RemoveRecurring()
        {
            RecurringJob.RemoveIfExists("Job-1");
            return RedirectToAction("Index", "Hangfire");
        }
    }
}