using HRApp.DataAccess;
using HRApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HRApp.DataAccess;

namespace HRApp.Controllers
{
    public class EmployeeController : Controller
    {
        protected AdventureWorks2014Entities2 context = new AdventureWorks2014Entities2();

        // GET: Employee
        public ActionResult Index()
        {
            //var employees = context.GetAllEmployees();
            //return View(employees);
            
            var evmResults = from e in context.Employees
                             select new EmployeeViewModel()
                             {
                                 BusinessEntityID = e.BusinessEntityID,
                                 JobTitle = e.JobTitle,
                                 LoginID = e.LoginID,
                                 SalariedFlag = e.SalariedFlag,
                                 SickLeaveHours = e.SickLeaveHours,
                                 VacationHours = e.VacationHours
                             };
            return View(evmResults);
        }
    }
}