using Elvis.Core.RepositoryInterfaces;
using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elvis.Core.Repositories
{
    public class CommunitiesRepository : Repository<Communities>, ICommunitiesRepository
    {
        public CommunitiesRepository(ElvisModel context)
            : base(context)
        {
        }

        public ElvisModel ElvisContext { get => Context as ElvisModel; }

        public IEnumerable<Communities> GetCommunities()
        {
            return ElvisContext.Communities.ToList();
        }

        public IEnumerable<Communities> GetCommunitiesByCode(int code)
        {
            yield return ElvisContext.Communities.Find(code);
        }
    }
}