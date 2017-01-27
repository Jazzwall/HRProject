using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRApp.DataAccess
{
    public class HRAppContext : DbContext, IHRAppContext
    {
        public HRAppContext(string connStr, bool useProxies = true)
            : base(connStr) 
        {
            Configuration.ProxyCreationEnabled = useProxies;
        }

        public DbSet<Employee> Employees { get; set; }
        //public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        //public DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }

        public IQueryable<Employee> GetAllEmployees()
        {
            return Employees;
        }

        //public IQueryable<Department> GetAllDepartments()
        //{
        //    return Departments;
        //}

        //public IQueryable<Instructor> GetAllInstructors()
        //{
        //    return Instructors;
        //}

        public void MarkAsModified(object obj)
        {
            Entry(obj).State = EntityState.Modified;
        }

        public void MarkAsAdded(object obj)
        {
            Entry(obj).State = EntityState.Added;
        }

        void IHRAppContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}