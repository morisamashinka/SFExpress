using Newtonsoft.Json;
using SFExpress.EntityFrameworks;
using SFExpress.Interfaces;
using SFExpress.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFExpress.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? HiredDate { get; set; }
        public string EmployeeTasks { get; set; }
        public EmployeeViewModel(Employee employee, IEmployeeTaskDataBaseAdapter adapter)
        {
            EmployeeID = employee.EmployeeID;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            HiredDate = employee.HiredDate;
            EmployeeTasks = JsonConvert.SerializeObject(adapter.GetEmployeeTasks(employee));
        }
    }
}