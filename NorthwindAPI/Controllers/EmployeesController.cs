using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea1DWB_DBFirst_EFCore.Services;
using Tarea1DWB_DBFirst_EFCore.DataAccess;
using DBFirst.Models;

namespace NorthwindAPI.Controllers
{
    // https://localhost:5001/api/[controller]/...
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeeSC employeeService = new EmployeeSC();

        // GET: api/Employees
        [HttpGet(Name = "GetEmployees")]
        public IActionResult Get()
        {
            var employees = employeeService.GetAllEmployees().Select(s => new Employees { 
                EmployeeId = s.EmployeeId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Title = s.Title,
                Address = s.Address,
                City = s.City,
                Region = s.Region,
                PostalCode = s.PostalCode,
                Country = s.Country,
                HomePhone = s.HomePhone,
                Notes = s.Notes
            }).ToList();
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public IActionResult Get(int id)
        {
            var employee = employeeService.GetEmployeeById(id).Select(s => new Employees
            {
                EmployeeId = s.EmployeeId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Title = s.Title,
                Address = s.Address,
                City = s.City,
                Region = s.Region,
                PostalCode = s.PostalCode,
                Country = s.Country,
                HomePhone = s.HomePhone,
                Notes = s.Notes
            }).FirstOrDefault();
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost(Name = "NewEmployee")]
        public IActionResult Post([FromBody] EmployeeModel newEmployee)
        {
            employeeService.AddEmployee(newEmployee);
            return Ok();
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}", Name = "DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            employeeService.DeleteEmployeeById(id);
            return Ok();
        }
    }
}
