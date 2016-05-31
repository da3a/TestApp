using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;

namespace Lubrizol.IVD.Data.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private TestAppContext context;
        private readonly IDatabaseFactory databaseFactory;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;

        }

        protected TestAppContext Context
        {
            get { return context ?? (context = (TestAppContext)databaseFactory.Get()); }
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
