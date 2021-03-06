using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Entities;

namespace xuyang.CabBookingShop.Core.RepositoryInterfaces
{
    public interface ICabTypeRepository
    {
        Task<IEnumerable<CabType>> GetAllAsync();
        Task<CabType> UpdateAsync(CabType cabType);
        Task<CabType> DeleteAsync(CabType cabType);
        Task<CabType> AddAsync(CabType cabType);
        Task<CabType> GetById(int id);

    }
}
