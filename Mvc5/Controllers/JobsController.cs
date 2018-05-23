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
            //支持基於隊列的任務處理：任務執行不是同步的，而是放到一個持久化隊列中，以便馬上把請求控制權返回給調用者。
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("隊列任務"));

            //延續性任務執行：類似於.NET中的Task,可以在第一個任務執行完之後緊接着再次執行另外的任務
            BackgroundJob.ContinueWith(jobId, () => Console.WriteLine("連續任務"));

            return RedirectToAction("Index", "Hangfire");
        }

        /// <summary>
        /// 延遲實作
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDelayed()
        {
            //延遲任務執行：不是馬上調用方法，而是設定一個未來時間點再來執行。
            BackgroundJob.Schedule(() => Console.WriteLine("延時任務"), TimeSpan.FromSeconds(10));
            return RedirectToAction("Index", "Hangfire");
        }

        /// <summary>
        /// 定時實作
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRecurring()
        {
            //延續性任務執行：類似於.NET中的Task,可以在第一個任務執行完之後緊接着再次執行另外的任務
            //循環任務執行：一行代碼添加重複執行的任務，其內置了常見的時間循環模式，也可基於CRON表達式來設定複雜的模式。
            RecurringJob.AddOrUpdate("Job-1", () => Console.Write("定時任務"), Cron.Minutely);
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