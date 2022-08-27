using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using EmployeeCrud.Api.Models;
using EmployeeCrud.Api.Models.DTO;

namespace EmployeeCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _db;

        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Employees.ToList());
        }

        [HttpPost]
        public IActionResult Post(EmployeeDto employee)
        {
            try
            {
                Employee emp = new Employee { FirstName = employee.FirstName, LastName = employee.LastName, DateOfBirth = employee.DateOfBirth };
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
