using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore.Services
{
    public class EmployeeSC : BaseSC
    {
        #region Methods
        public void UpdateEmployeeName(int employeeID, string employeeName, int isFirstName = 1)
        {
            var currentEmployee = GetAllEmployees().Where(e => e.EmployeeId == employeeID).FirstOrDefault();

            if (currentEmployee == null)
                throw new Exception("\nID de empleado no escontrado");

            if (isFirstName == 1)
                currentEmployee.FirstName = employeeName;
            else
                currentEmployee.LastName = employeeName;

            dbContext.SaveChanges();
        }

        //DELETE
        public void DeleteEmployeeById(int id)
        {
            var employee = GetEmployeeById(id);
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
        }
        #endregion

        #region HelperMethods
        //GET
        public IQueryable<Employees> GetAllEmployees()
        {
            return dbContext.Employees.Select(e => e);
        }

        //GET
        public IEnumerable<Employees> GetEmployeeById(int employeeId)
        {
            return GetAllEmployees().Where(w => w.EmployeeId == employeeId);
        }
        #endregion
    }
}
