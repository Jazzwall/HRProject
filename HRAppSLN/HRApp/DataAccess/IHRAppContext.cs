using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApp.DataAccess
{
    public interface IHRAppContext
    {
        //IQueryable<Course> GetAllCourses();
        //IQueryable<Department> GetAllDepartments();
        //IQueryable<Instructor> GetAllInstructors();

        void MarkAsModified(object obj);
        void MarkAsAdded(object obj);

        void SaveChanges();
    }
}