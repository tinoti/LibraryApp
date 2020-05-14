using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Index()
        {
            return View();
        }
    }
}