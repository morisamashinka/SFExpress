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
            List<EmployeeTask> tasks = new List<EmployeeTask>();
            if (employee.EmployeeTasks != null && !string.IsNullOrEmpty(employee.EmployeeTasks))
            {
                using (var entities = new SFExpressEntities())
                {
                    HashSet<int> taskIDs = new HashSet<int>(JsonConvert.DeserializeObject<List<int>>(employee.EmployeeTasks));
                    tasks =  entities.EmployeeTask.Where(x => taskIDs.Contains(x.EmployeeTaskID)).ToList();
                }
            }
            return tasks;
        }

        public bool CreateEmployeeTask(EmployeeTask employeeTask)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    entities.EmployeeTask.Add(employeeTask);
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

        public bool UpdateEmployeeTask(EmployeeTask employeeTask)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    var toUpdate = entities.EmployeeTask.SingleOrDefault(x => x.EmployeeTaskID == employeeTask.EmployeeTaskID);
                    if (toUpdate != null)
                    {
                        entities.EmployeeTask.AddOrUpdate(employeeTask);
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

        public bool DeleteEmployeeTask(int id)
        {
            using (var entities = new SFExpressEntities())
            {
                try
                {
                    EmployeeTask toDelete = new EmployeeTask { EmployeeTaskID = id };
                    entities.EmployeeTask.Attach(toDelete);
                    entities.EmployeeTask.Remove(toDelete);
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