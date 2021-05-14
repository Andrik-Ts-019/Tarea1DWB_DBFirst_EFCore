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
        public List<Employees> Get()
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
            return employees;
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public Employees Get(int id)
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
            return employee;
        }

        // POST: api/Employees
        [HttpPost(Name = "NewEmployee")]
        public void Post([FromBody] EmployeeModel newEmployee)
        {
            employeeService.AddEmployee(newEmployee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}", Name = "DeleteEmployee")]
        public void Delete(int id)
        {
            employeeService.DeleteEmployeeById(id);
        }
    }
}
