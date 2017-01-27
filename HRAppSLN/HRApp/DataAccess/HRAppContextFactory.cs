using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApp.DataAccess
{
    public static class HRAppContextFactory
    {
        public static IHRAppContext GetContext(string connStr, bool useProxies = true)
        {
            return new HRAppContext(connStr, useProxies);
        }
    }
}