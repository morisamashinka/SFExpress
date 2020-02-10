using Newtonsoft.Json;
using SFExpress.EntityFrameworks;
using SFExpress.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SFExpress.Logics
{
    public class EmployeeTaskSQLAdapter : IEmployeeTaskDataBaseAdapter
    {
        public List<EmployeeTask> GetEmployeeTasks()
        {
            using (var entities = new SFExpressEntities())
            {
                return entities.EmployeeTask.ToList();
            }
        }

        public List<EmployeeTask> GetEmployeeTasks(Employee employee)
        {
            using (var entities = new SFExpressEntities())
            {
                HashSet<int> taskIDs = new HashSet<int>(JsonConvert.DeserializeObject<List<int>>(employee.EmployeeTasks));
                return entities.EmployeeTask.Where(x => taskIDs.Contains(x.EmployeeTaskID)).ToList();
            }
        }

        public bool SaveEmployeeTask(EmployeeTask employeeTask)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    entities.EmployeeTask.AddOrUpdate(employeeTask);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public bool DeleteEmployeeTask(EmployeeTask employeeTask)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    entities.EmployeeTask.Remove(employeeTask);
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