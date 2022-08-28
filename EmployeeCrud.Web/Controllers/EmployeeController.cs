using EmployeeCrud.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmployeeCrud.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly string apiBaseUrl;

        public EmployeeController(IConfiguration configuration)
        {
            this.Configuration = configuration;
            apiBaseUrl = Configuration.GetValue<string>("BaseApiAddress");
        }

        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Employee> employees = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "employee";
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(await Response.Content.ReadAsStringAsync());
                        return View(employees);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Occured");
                        return View();
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            Employee employee = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "employee" + "/" + id;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        employee = JsonConvert.DeserializeObject<Employee>(await Response.Content.ReadAsStringAsync());
                        return View(employee);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Occured");
                        return View();
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Employee employee)
        {
            EmployeeCrudDto employeeCrudDto = new EmployeeCrudDto { 
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth 
            };

            var data = JsonConvert.SerializeObject(employeeCrudDto);

            StringContent content = new StringContent(JsonConvert.SerializeObject(employeeCrudDto), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "employee" + "/" + id;
                

                using (var Response = await client.PutAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("Details", new { id });
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Occured");
                        return View();
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            Employee employee = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "employee" + "/" + id;
                using (var Response = await client.GetAsync(endpoint))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        employee = JsonConvert.DeserializeObject<Employee>(await Response.Content.ReadAsStringAsync());
                        return View(employee);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Occured");
                        return View();
                    }
                }
            }
            return View();
        }

    }
}
