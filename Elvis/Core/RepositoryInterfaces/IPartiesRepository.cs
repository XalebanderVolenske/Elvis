using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elvis.Core.RepositoryInterfaces
{
    interface IPartiesRepository : IRepository<Parties>
    {
        IEnumerable<Parties> GetParties();
        IEnumerable<Parties> GetPartiesByCode(int code);
    }
}
