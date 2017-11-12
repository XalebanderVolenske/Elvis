using Elvis.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elvis.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Elvis.Core.Repositories
{
    public class ProvincesRepository : Repository<Provinces>, IProvincesRepository
    {
        public ProvincesRepository(ElvisModel context)
            :base(context)
        {
        }

        public ElvisModel ElvisContext { get => Context as ElvisModel; }

        public IEnumerable<Provinces> GetProvinceByCode(int code)
        {
            yield return ElvisContext.Provinces.Find(code);
        }

        public IEnumerable<Provinces> GetProvinces()
        {
            return ElvisContext.Provinces.ToList();
        }
    }
}