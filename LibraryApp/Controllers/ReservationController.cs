using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Employee))
                return View("EmployeeIndex");

            return View("Index");
        }

        
        public ActionResult Status()
        {
            return View();
        }
    }
}