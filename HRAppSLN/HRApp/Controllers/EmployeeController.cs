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
            
            var evmResults = from e in context.Employees.AsParallel()
                             join p in context.People.AsParallel()
                             on e.BusinessEntityID equals p.BusinessEntityID
                             orderby e.BusinessEntityID
                             select new EmployeeViewModel()
                             {
                                 BusinessEntityID = e.BusinessEntityID,
                                 JobTitle = e.JobTitle,
                                 LoginID = e.LoginID,
                                 SalariedFlag = e.SalariedFlag,
                                 SickLeaveHours = e.SickLeaveHours,
                                 VacationHours = e.VacationHours,
                                 FirstName = p.FirstName,
                                 LastName = p.LastName
                             };
            return View(evmResults);
        }

        public ActionResult Edit(int id)
        {
            var e = (from emp in context.Employees
                     where emp.BusinessEntityID == id
                     select emp).Single();
            var p = (from per in context.People
                     where per.BusinessEntityID == id
                     select per).Single();
            var evm = new EmployeeViewModel()
            {
                BusinessEntityID = e.BusinessEntityID,
                JobTitle = e.JobTitle,
                LoginID = e.LoginID,
                SalariedFlag = e.SalariedFlag,
                SickLeaveHours = e.SickLeaveHours,
                VacationHours = e.VacationHours,
                FirstName = p.FirstName,
                LastName = p.LastName
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel evm)
        {
            var e = (from emp in context.Employees
                     where emp.BusinessEntityID == evm.BusinessEntityID
                     select emp).Single();
            var p = (from per in context.People
                     where per.BusinessEntityID == evm.BusinessEntityID
                     select per).Single();

            //update the employee entity from evm
            e.BusinessEntityID = evm.BusinessEntityID;
            e.JobTitle = evm.JobTitle;
            e.LoginID = evm.LoginID;
            e.SalariedFlag = evm.SalariedFlag;
            e.SickLeaveHours = evm.SickLeaveHours;
            e.VacationHours = evm.VacationHours;

            //update the person entity from evm
            p.FirstName = evm.FirstName;
            p.LastName = evm.LastName;

            //sync changes back to the database
            context.SaveChanges();

            //return to the list view
            return RedirectToAction("Index");
        }
    }
}