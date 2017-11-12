using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elvis.Core.RepositoryInterfaces
{
    interface IElectionsRepository : IRepository<Elections>
    {
        IEnumerable<Elections> GetElections();
        IEnumerable<Elections> GetElectionsByCode(int code);
    }
}
