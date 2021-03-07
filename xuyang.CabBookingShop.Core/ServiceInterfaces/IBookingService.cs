using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Models.Request;
using xuyang.CabBookingShop.Core.Models.Response;

namespace xuyang.CabBookingShop.Core.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingSummaryResponseModel>> GetAllBookings();
        Task<BookingDetailResponseModel> DeleteBookingById(int id);
        Task<BookingDetailResponseModel> AddBooking(BookingCreateRequestModel bookingCreateRequestModel);
        Task<BookingDetailResponseModel> UpdateBooking(BookingUpdateRequestModel bookingUpdateRequestModel);
        Task<BookingDetailResponseModel> GetBookingById(int id);
    }
}
