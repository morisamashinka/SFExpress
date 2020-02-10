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
    [TestFixture]
    public class UnitTestEmployeeCRUD
    {
        public EmployeeController EmployeeController { get; private set; }

        public UnitTestEmployeeCRUD()
        {
            EmployeeController = new EmployeeController();
        }

        [Test]
        public void EmployeeCRUDTest()
        {
            //create
            var newEmployee = new Employee()
            {
                FirstName = "UnitTest",
                LastName = "Employee1",
                HiredDate = DateTime.Now,
            };
            EmployeeController.Post(newEmployee);
            List<EmployeeViewModel> _allEmployee = EmployeeController.Get();
            EmployeeViewModel toCompare = _allEmployee.Where(x => x.EmployeeID == newEmployee.EmployeeID).FirstOrDefault();
            Assert.IsTrue(toCompare != null && newEmployee.FirstName == toCompare.FirstName && newEmployee.LastName == toCompare.LastName);
            //update
            newEmployee.FirstName = "Updated";
            EmployeeController.Put(newEmployee);
            _allEmployee = EmployeeController.Get();
            toCompare = _allEmployee.Where(x => x.EmployeeID == newEmployee.EmployeeID).FirstOrDefault();
            Assert.IsTrue(toCompare != null && newEmployee.FirstName == toCompare.FirstName);
            //delete
            EmployeeController.Delete(newEmployee.EmployeeID);
            _allEmployee = EmployeeController.Get();
            Assert.IsTrue(!_allEmployee.Any(x => x.EmployeeID == newEmployee.EmployeeID));
        }
    }
}