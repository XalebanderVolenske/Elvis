using Elvis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elvis.Core.RepositoryInterfaces
{
    interface IDistrictRepository : IRepository<Districts>
    {
        IEnumerable<Districts> GetDistricts();
        IEnumerable<Districts> GetDistrictsByCode(int code);
    }
}
