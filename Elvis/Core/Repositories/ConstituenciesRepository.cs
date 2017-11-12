using Elvis.Core.RepositoryInterfaces;
using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elvis.Core.Repositories
{
    public class ConstituenciesRepository : Repository<Constituencies>, IConstituenciesRepository
    {
        public ConstituenciesRepository(ElvisModel context)
            : base(context)
        {
        }

        public ElvisModel ElvisContext { get => Context as ElvisModel; }

        public IEnumerable<Constituencies> GetConstituencies()
        {
            return ElvisContext.Constituencies.ToList();
        }

        public IEnumerable<Constituencies> GetConstituenciesByCode(int code)
        {
            yield return ElvisContext.Constituencies.Find(code);
        }
    }
}