using SFExpress.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFExpress.Interfaces
{
    public interface IEmployeeTaskDataBaseAdapter
    {
        List<EmployeeTask> GetEmployeeTasks();
        List<EmployeeTask> GetEmployeeTasks(Employee employee);
        bool SaveEmployeeTask(EmployeeTask employeeTask);
        bool DeleteEmployeeTask(EmployeeTask employeeTask);
    }
}
