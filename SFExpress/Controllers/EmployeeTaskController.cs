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

        public Employee Get(string fullName)
        {
            throw new NotImplementedException();
        }
    }
}
