using SFExpress.EntityFrameworks;
using SFExpress.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SFExpress.Logics
{
    public class EmployeeSQLAdapter : IEmployeeDataBaseAdapter
    {
        public List<Employee> GetEmployees()
        {
            using (var entities = new SFExpressEntities())
            {
                return entities.Employee.ToList();
            }
        }

        public bool SaveEmployee(Employee employee)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    entities.Employee.AddOrUpdate(employee);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public bool DeleteEmployee(int EmployeeID)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    Employee employee = new Employee() { EmployeeID = EmployeeID };
                    entities.Employee.Attach(employee);
                    entities.Employee.Remove(employee);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
    }
}