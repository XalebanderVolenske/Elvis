using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elvis.Core.RepositoryInterfaces
{
    interface ICommunitiesRepository : IRepository<Communities>
    {
        IEnumerable<Communities> GetCommunities();
        IEnumerable<Communities> GetCommunitiesByCode(int code);
    }
}
