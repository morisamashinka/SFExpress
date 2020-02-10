using SFExpress.EntityFrameworks;
using SFExpress.Interfaces;
using System.Collections.Generic;

namespace SFExpress.Services
{
    public class EmployeeDataService
    {
        #region employee
        public List<Employee> GetEmployees(IEmployeeDataBaseAdapter db)
        {
            return db.GetEmployees();
        }
        #endregion

        #region employeeTask
        public List<EmployeeTask> GetEmployeeTasks(IEmployeeTaskDataBaseAdapter db)
        {
            return db.GetEmployeeTasks();
        }
        #endregion
    }
}