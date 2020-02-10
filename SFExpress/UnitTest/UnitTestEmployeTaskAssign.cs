using Newtonsoft.Json;
using NUnit.Framework;
using SFExpress.Controllers;
using SFExpress.EntityFrameworks;
using SFExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFExpress.UnitTest
{
    public class UnitTestEmployeTaskAssign
    {
        private readonly string jsonFormat = "[{0}]";
        public UnitTestEmployeTaskAssign()
        {
            EmployeeController = new EmployeeController();
            EmployeeTaskController = new EmployeeTaskController();
        }

        public EmployeeController EmployeeController { get; private set; }
        public EmployeeTaskController EmployeeTaskController { get; private set; }

        [Test]
        public void EmployeeTaskAssignTest()
        {

            var newEmployeeTask = new EmployeeTask()
            {
                TaskName = "CRUDTestAssignment",
                StartTime = DateTime.Now,
                Deadline = DateTime.Now.AddDays(1)
            };
            EmployeeTaskController.Post(newEmployeeTask);
            var newEmployee = new Employee()
            {
                FirstName = "UnitTest",
                LastName = "Employee1",
                HiredDate = DateTime.Now,
                EmployeeTasks = string.Format(jsonFormat, newEmployeeTask.EmployeeTaskID)
            };
            EmployeeController.Post(newEmployee);
            List<EmployeeViewModel> _allEmployee = EmployeeController.Get();
            EmployeeViewModel toCompare = _allEmployee.Where(x => x.EmployeeID == newEmployee.EmployeeID).FirstOrDefault();
            var assignedTask = JsonConvert.DeserializeObject<List<EmployeeTask>>(toCompare.EmployeeTasks).FirstOrDefault();
            Assert.IsTrue(toCompare != null && newEmployeeTask.TaskName == assignedTask.TaskName);
            EmployeeController.Delete(newEmployee.EmployeeID);
            EmployeeTaskController.Delete(newEmployeeTask.EmployeeTaskID);
           
        }
    }
}