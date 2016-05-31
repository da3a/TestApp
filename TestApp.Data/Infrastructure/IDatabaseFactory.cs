using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;

namespace Lubrizol.IVD.Data.Infrastructure
{
    public interface IDatabaseFactory: IDisposable
    {
        TestAppContext Get();
    }
}
