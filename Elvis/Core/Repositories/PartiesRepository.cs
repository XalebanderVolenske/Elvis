using Elvis.Core.RepositoryInterfaces;
using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elvis.Core.Repositories
{
    public class PartiesRepository : Repository<Parties>, IPartiesRepository
    {
        public PartiesRepository(ElvisModel context)
            : base(context)
        {
        }

        public ElvisModel ElvisContext { get => Context as ElvisModel; }

        public IEnumerable<Parties> GetParties()
        {
            return ElvisContext.Parties.ToList();
        }

        public IEnumerable<Parties> GetPartiesByCode(int code)
        {
            yield return ElvisContext.Parties.Find(code);
        }
    }
}