using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Entities;

namespace TestApp.Data
{
    public class TestAppContext:DbContext
    {

        public TestAppContext():base("server=.;database=TestApp;Trusted_Connection=Yes")
        {
            Initialize();
        }

        private void Initialize()
        {
            Database.SetInitializer<TestAppContext>(new IVDInitializer());

            this.Database.Log = sql => Debug.WriteLine(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Candidate> Candidates { get; set; }
    }

    public class IVDInitializer : CreateDatabaseIfNotExists<TestAppContext>
    {
        protected override void Seed(TestAppContext context)
        {
            var candidates = new List<Candidate>()
            {
                new Candidate() {FirstName = "David", LastName = "Wallwin", DateOfBirth = DateTime.Now.AddYears(-30), FirstTelephone = "111111", CreatedDate = DateTime.Now, CreatedBy = "dawa", ModifiedDate = DateTime.Now, ModifiedBy = "dawa"},
                new Candidate() {FirstName = "Laura", LastName = "Cazorla", DateOfBirth = DateTime.Now.AddYears(-21), FirstTelephone = "22222", CreatedDate = DateTime.Now, CreatedBy = "dawa", ModifiedDate = DateTime.Now, ModifiedBy = "dawa"},
                new Candidate() {FirstName = "Natalia", LastName = "Crespo", DateOfBirth = DateTime.Now.AddYears(-19), FirstTelephone = "33333", CreatedDate = DateTime.Now, CreatedBy = "dawa", ModifiedDate = DateTime.Now, ModifiedBy = "dawa" }
            };

            candidates.ForEach(x => context.Candidates.Add(x));

            context.SaveChanges();
            base.Seed(context);
        }
    }

}
