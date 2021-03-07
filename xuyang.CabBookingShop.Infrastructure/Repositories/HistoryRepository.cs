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
    public class HistoryRepository : IHistoryRepository
    {
        private readonly CabBookingShopDbContext _dbContext;
        public HistoryRepository(CabBookingShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookingHistory> AddAsync(BookingHistory bookingHistory)
        {
            _dbContext.Set<BookingHistory>().Add(bookingHistory);
            await _dbContext.SaveChangesAsync();
            return bookingHistory;
        }

        public async Task<BookingHistory> DeleteAsync(BookingHistory bookingHistory)
        {
            _dbContext.Remove(bookingHistory);
            await _dbContext.SaveChangesAsync();
            return bookingHistory;
        }

        public async Task<IEnumerable<BookingHistory>> GetAllAsync()
        {
            return await _dbContext.BookingHistories.Include(h => h.CabType)
                .Include(h => h.ToPlace).Include(h => h.FromPlace).ToListAsync();
        }

        public async Task<BookingHistory> GetById(int id)
        {
            return await _dbContext.BookingHistories.Include(h => h.CabType)
                .Include(h => h.ToPlace).Include(h => h.FromPlace).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<BookingHistory> UpdateAsync(BookingHistory bookingHistory)
        {
            _dbContext.Entry(bookingHistory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return bookingHistory;
        }
    }
}
