using SFExpress.EntityFrameworks;
using SFExpress.Interfaces;
using SFExpress.Logics;
using SFExpress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SFExpress.Controllers
{
    public class EmployeeTaskController : ApiController
    {
        private IEmployeeTaskDataBaseAdapter _adapter = new EmployeeTaskSQLAdapter();
        private EmployeeDataService _provider = new EmployeeDataService();
        public List<EmployeeTask> Get()
        {
            return _provider.GetEmployeeTasks(_adapter);
        }

        public IHttpActionResult Post(EmployeeTask employeeTask)
        {
            var success = _adapter.CreateEmployeeTask(employeeTask);
            if (success)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(EmployeeTask employeeTask)
        {
            var success = _adapter.UpdateEmployeeTask(employeeTask);
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
            var success = _adapter.DeleteEmployeeTask(id);
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
