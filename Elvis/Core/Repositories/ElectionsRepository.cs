using Elvis.Core.RepositoryInterfaces;
using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Elvis.Core.Repositories
{
    public class ElectionsRepository : Repository<Elections>, IElectionsRepository
    {
        public ElectionsRepository(ElvisModel context)
            : base(context)
        {
        }
        public ElvisModel ElvisContext { get => Context as ElvisModel; }

        public IEnumerable<Elections> GetElectionsByCode(int code)
        {
            yield return ElvisContext.Elections.Find(code);
        }

        public IEnumerable<Elections> GetElections()
        {
            return ElvisContext.Elections.ToList();
        }
    }
}