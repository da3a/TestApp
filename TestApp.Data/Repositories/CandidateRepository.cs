using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubrizol.IVD.Data.Infrastructure;
using TestApp.Entities;

namespace TestApp.Data.Repositories
{
    public class CandidateRepository: GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }

    public interface ICandidateRepository : IGenericRepository<Candidate>
    {

     }
}
