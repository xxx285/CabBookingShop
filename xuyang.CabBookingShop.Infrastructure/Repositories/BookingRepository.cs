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
    public class BookingRepository : IBookingRepository
    {
        private readonly CabBookingShopDbContext _dbContext;
        public BookingRepository(CabBookingShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            _dbContext.Set<Booking>().Add(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> DeleteAsync(Booking booking)
        {
            _dbContext.Remove(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _dbContext.Bookings.Include(b => b.ToPlace).Include(b => b.FromPlace)
                .Include(b => b.CabType).ToListAsync();
        }

        public async Task<Booking> GetById(int id)
        {
            return await _dbContext.Bookings.Include(b => b.CabType).Include(b => b.ToPlace)
                .Include(b => b.FromPlace).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            _dbContext.Entry(booking).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return booking;
        }
    }
}
