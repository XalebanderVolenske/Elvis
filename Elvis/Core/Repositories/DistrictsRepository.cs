using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elvis.Core.Repositories
{
    public class DistrictsRepository : Repository<Districts>, IDistrictsRepository
    {
        public DistrictsRepository(ElvisModel context)
            :base(context)
        {
        }

        public ElvisModel ElvisContext { get => Context as ElvisModel; }

        public IEnumerable<Districts> GetDistrictsByCode(int code)
        {
            yield return ElvisContext.Districts.Find(code);
        }

        public IEnumerable<Districts> GetDistricts()
        {
            return ElvisContext.Districts.ToList();
        }
}