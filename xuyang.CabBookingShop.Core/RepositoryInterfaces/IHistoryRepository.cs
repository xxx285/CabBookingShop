using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Entities;

namespace xuyang.CabBookingShop.Core.RepositoryInterfaces
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<BookingHistory>> GetAllAsync();
        Task<BookingHistory> GetById(int id);
        Task<BookingHistory> DeleteAsync(BookingHistory bookingHistory);
        Task<BookingHistory> AddAsync(BookingHistory bookingHistory);
        Task<BookingHistory> UpdateAsync(BookingHistory bookingHistory);
    }
}
