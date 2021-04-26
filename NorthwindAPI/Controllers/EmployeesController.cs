using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea1DWB_DBFirst_EFCore.Services;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace NorthwindAPI.Controllers
{
    // https://localhost:5001/api/[controller]/...
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/Employees
        [HttpGet(Name = "GetEmployees")]
        public List<Employees> Get()
        {
            var employees = new EmployeeSC().GetAllEmployees().Select(s => new Employees { 
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
            var employee = new EmployeeSC().GetEmployeeById(id).Select(s => new Employees
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
