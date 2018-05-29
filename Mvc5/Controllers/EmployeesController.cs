using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Mvc5.Controllers
{
    public class EmployeesController : Controller
    {
        private IService<Employees> _service;

        public EmployeesController(IService<Employees> service)
        {
            this._service = service;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var result = _service.GetAll();
            return View();
        }
    }
}