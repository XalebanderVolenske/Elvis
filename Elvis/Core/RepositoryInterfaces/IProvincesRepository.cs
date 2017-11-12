using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elvis.Core.RepositoryInterfaces
{
    interface IProvincesRepository : IRepository<Provinces>
    {
        IEnumerable<Provinces> GetProvinces();
        IEnumerable<Provinces> GetProvinceByCode(int code);
    }
}
