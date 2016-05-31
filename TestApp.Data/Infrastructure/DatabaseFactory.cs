using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;

namespace Lubrizol.IVD.Data.Infrastructure
{
    public class DatabaseFactory: IDatabaseFactory
    {
        private TestAppContext context;

        public TestAppContext Get()
        {
            //var connectionString = ConfigHelper.GetDefaultConnectionString();
            return context ?? (context = new TestAppContext());
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
