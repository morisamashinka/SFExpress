using SFExpress.EntityFrameworks;
using SFExpress.Interfaces;
using SFExpress.Logics;
using SFExpress.Models;
using SFExpress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SFExpress.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeDataBaseAdapter _employeeAdapter = new EmployeeSQLAdapter();
        private IEmployeeTaskDataBaseAdapter _employeeTaskAdapter = new EmployeeTaskSQLAdapter();
        private EmployeeDataService _provider = new EmployeeDataService();
        public List<EmployeeViewModel> Get()
        {
            return _provider.GetEmployees(_employeeAdapter).Select(x => new EmployeeViewModel(x, _employeeTaskAdapter)).ToList();
        }

        //public List<EmployeeViewModel> GetEmployeeViewModel()
        //{
        //    return _provider.GetEmployees(_employeeAdapter).Select(x => new EmployeeViewModel(x, _employeeTaskAdapter)).ToList();
        //}

        public IHttpActionResult Post(Employee employee)
        {
            var success = _employeeAdapter.SaveEmployee(employee);
            if (success)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            var success = _employeeAdapter.DeleteEmployee(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
