using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elvis.Core.RepositoryInterfaces
{
    interface IConstituenciesRepository : IRepository<Constituencies>
    {
        IEnumerable<Constituencies> GetConstituencies();
        IEnumerable<Constituencies> GetConstituenciesByCode(int code);
    }
}
