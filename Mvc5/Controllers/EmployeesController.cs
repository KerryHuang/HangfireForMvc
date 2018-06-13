using Hangfire;
using Services;
using System;
using System.Web.Mvc;

namespace Mvc5.Controllers
{
    public class EmployeesController : Controller
    {
        public IEmployeesService EmployeesService { protected get; set; }

        // GET: Employees
        public ActionResult Index()
        {
            var result = EmployeesService.GetAll();
            BackgroundJob.Enqueue(() => Excute());
            return View(result.Entities);
        }

        public void Excute()
        {
            Console.WriteLine("隊列任務");
            EmployeesService = new EmployeesService();
            var result = EmployeesService.GetAll();            
            Console.WriteLine($"資料筆數：{result.Count}");
        }
    }
}