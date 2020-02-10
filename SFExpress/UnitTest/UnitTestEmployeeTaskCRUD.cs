using NUnit.Framework;
using SFExpress.Controllers;
using SFExpress.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFExpress.UnitTest
{
    public class UnitTestEmployeeTaskCRUD
    {
        public EmployeeTaskController EmployeeTaskController { get; private set; }

        public UnitTestEmployeeTaskCRUD()
        {
            EmployeeTaskController = new EmployeeTaskController();
        }

        [Test]
        public void EmployeeCRUDTest()
        {
            //create
            var newEmployeeTask = new EmployeeTask()
            {
                TaskName = "CRUDTest",
                StartTime = DateTime.Now,
                Deadline = DateTime.Now.AddDays(1)
            };
            EmployeeTaskController.Post(newEmployeeTask);
            List<EmployeeTask> _allEmployee = EmployeeTaskController.Get();
            EmployeeTask toCompare = _allEmployee.Where(x => x.EmployeeTaskID == newEmployeeTask.EmployeeTaskID).FirstOrDefault();
            Assert.IsTrue(toCompare != null && newEmployeeTask.TaskName == toCompare.TaskName);
            //update
            newEmployeeTask.TaskName = "UpdatedTask";
            EmployeeTaskController.Put(newEmployeeTask);
            _allEmployee = EmployeeTaskController.Get();
            toCompare = _allEmployee.Where(x => x.EmployeeTaskID == newEmployeeTask.EmployeeTaskID).FirstOrDefault();
            Assert.IsTrue(toCompare != null && newEmployeeTask.TaskName == toCompare.TaskName);
            //delete
            EmployeeTaskController.Delete(newEmployeeTask.EmployeeTaskID);
            _allEmployee = EmployeeTaskController.Get();
            Assert.IsTrue(!_allEmployee.Any(x => x.EmployeeTaskID == newEmployeeTask.EmployeeTaskID));
        }
    }
}