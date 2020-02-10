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

        public bool CreateEmployee(Employee employee)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    entities.Employee.Add(employee);
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

        public bool UpdateEmployee(Employee employee)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    var toUpdate = entities.Employee.SingleOrDefault(x => x.EmployeeID == employee.EmployeeID);
                    if (toUpdate != null)
                    {
                        entities.Employee.AddOrUpdate(employee);
                        entities.SaveChanges();
                        return true;
                    }
                    else return false;
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