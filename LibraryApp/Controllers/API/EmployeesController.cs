using LibraryApp.Models;
using LibraryApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryApp.Controllers.API
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/employees
        [Authorize(Roles = RoleName.Admin)]
        public IHttpActionResult GetEmployees()
        {
            var employees = _context.Users.ToList();

            return Ok(employees);
        }

        //DELETE /api/employees
        [Authorize(Roles = RoleName.Admin)]
        public IHttpActionResult DeleteEmployee(string id)
        {
            var employeeInDb = _context.Users.SingleOrDefault(o => o.Id == id);
            if (employeeInDb == null)
                return NotFound();

            _context.Users.Remove(employeeInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
