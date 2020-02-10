using SFExpress.EntityFrameworks;
using System.Collections.Generic;

namespace SFExpress.Services
{
    public interface IEmployeeDataBaseAdapter
    {
        List<Employee> GetEmployees();
        bool SaveEmployee(Employee employee);
        bool DeleteEmployee(int employeeID);
    }
}