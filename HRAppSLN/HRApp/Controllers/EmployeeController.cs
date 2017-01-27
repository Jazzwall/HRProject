using HRApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HRApp.Controllers
{
    public class EmployeeController : Controller
    {
        protected IHRAppContext context;
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            context = HRAppContextFactory.GetContext(connStr);
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = context.GetAllEmployees();
            return View(employees);
        }
    }
}