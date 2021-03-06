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
    public class CabTypeRepository : ICabTypeRepository
    {
        private readonly CabBookingShopDbContext _dbContext;
        public CabTypeRepository(CabBookingShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CabType> AddAsync(CabType cabType)
        {
            _dbContext.Set<CabType>().Add(cabType);
            await _dbContext.SaveChangesAsync();
            return cabType;
        }

        public async Task<CabType> DeleteAsync(CabType cabType)
        {
            _dbContext.Remove(cabType);
            await _dbContext.SaveChangesAsync();
            return cabType;
        }

        public async Task<IEnumerable<CabType>> GetAllAsync()
        {
            return await _dbContext.Set<CabType>().ToListAsync();
        }

        public async Task<CabType> GetById(int id)
        {
            return await _dbContext.Set<CabType>().FindAsync(id);
        }

        public async Task<CabType> UpdateAsync(CabType cabType)
        {
            //var toUpdateType = await GetById(cabType.CabTypeId);
            //if (toUpdateType == null)
            //    throw new Exception("No such record in the database");
            //toUpdateType.CabTypeName = cabType.CabTypeName;
            //await _dbContext.SaveChangesAsync();
            //return toUpdateType;
            _dbContext.Entry(cabType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return cabType;
        }
    }
}
