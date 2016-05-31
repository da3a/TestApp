using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;

namespace TestApp.Batch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TestApp Test...");
            using (var context = new TestAppContext())
            {
                context.Database.Initialize(true);

                var candidates = context.Candidates.ToList();
            }
        }
    }
}
