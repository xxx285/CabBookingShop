using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Entities;

namespace xuyang.CabBookingShop.Core.RepositoryInterfaces
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> GetAllAsync();
        Task<Place> UpdateAsync(Place place);
        Task<Place> DeleteAsync(Place place);
        Task<Place> AddAsync(Place place);
        Task<Place> GetById(int id);
    }
}
