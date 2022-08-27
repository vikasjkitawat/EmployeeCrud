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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.Employees.FirstOrDefault(x=>x.Id == id));
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

        [HttpPut]
        public IActionResult Put(int id, EmployeeDto employee)
        {
            try
            {
                Employee emp = _db.Employees.FirstOrDefault(x => x.Id == id);
                if (emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.DateOfBirth = employee.DateOfBirth;
                    _db.Employees.Update(emp);
                    _db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Employee emp = _db.Employees.FirstOrDefault(x => x.Id == id);
                if (emp != null)
                {
                    _db.Employees.Remove(emp);
                    _db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
