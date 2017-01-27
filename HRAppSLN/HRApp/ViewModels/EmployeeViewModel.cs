using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApp.ViewModels
{
    public class EmployeeViewModel
    {
        public int BusinessEntityID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string LoginID { get; set; }
        public string JobTitle { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }

    }
}