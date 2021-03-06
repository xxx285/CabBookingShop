using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Entities;
using xuyang.CabBookingShop.Core.RepositoryInterfaces;
using xuyang.CabBookingShop.Infrastructure.Data;

namespace xuyang.CabBookingShop.Infrastructure.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly CabBookingShopDbContext _dbContext;
        public PlaceRepository(CabBookingShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Place> AddAsync(Place place)
        {
            _dbContext.Set<Place>().Add(place);
            await _dbContext.SaveChangesAsync();
            return place;
        }

        public async Task<Place> DeleteAsync(Place place)
        {
            _dbContext.Remove(place);
            await _dbContext.SaveChangesAsync();
            return place;
        }

        public async Task<IEnumerable<Place>> GetAllAsync()
        {
            return await _dbContext.Set<Place>().ToListAsync();
        }

        public async Task<Place> GetById(int id)
        {
            return await _dbContext.Set<Place>().FindAsync(id);
        }

        public async Task<Place> UpdateAsync(Place place)
        {
            _dbContext.Entry(place).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return place;
        }
    }
}
