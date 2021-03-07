using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Entities;
using xuyang.CabBookingShop.Core.Models.Request;
using xuyang.CabBookingShop.Core.Models.Response;
using xuyang.CabBookingShop.Core.RepositoryInterfaces;
using xuyang.CabBookingShop.Core.ServiceInterfaces;

namespace xuyang.CabBookingShop.Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<BookingDetailResponseModel> AddBooking(BookingCreateRequestModel bookingCreateRequestModel)
        {
            var booking = new Booking
            {
                PickUpAddress = bookingCreateRequestModel.PickUpAddress,
                BookingDate = bookingCreateRequestModel.BookingDate,
                BookingTime = bookingCreateRequestModel.BookingTime,
                CabTypeId = bookingCreateRequestModel.CabTypeId,
                ContactNo = bookingCreateRequestModel.ContactNo,
                Email = bookingCreateRequestModel.Email,
                FromPlaceId = bookingCreateRequestModel.FromPlaceId,
                Landmark = bookingCreateRequestModel.Landmark,
                PickupDate = bookingCreateRequestModel.PickupDate,
                PickupTime = bookingCreateRequestModel.PickupTime,
                Status = bookingCreateRequestModel.Status,
                ToPlaceId = bookingCreateRequestModel.ToPlaceId
            };
            var createdBooking = await _bookingRepository.AddAsync(booking);
            if (createdBooking == null)
                throw new Exception("Creating Booking Failed!");
            var responseModel = new BookingDetailResponseModel
            {
                PickUpAddress = createdBooking.PickUpAddress,
                BookingDate = createdBooking.BookingDate,
                BookingTime = createdBooking.BookingTime,
                CabTypeId = createdBooking.CabTypeId,
                ContactNo = createdBooking.ContactNo,
                Email = createdBooking.Email,
                FromPlaceId = createdBooking.FromPlaceId,
                Landmark = createdBooking.Landmark,
                PickupDate = createdBooking.PickupDate,
                PickupTime = createdBooking.PickupTime,
                Status = createdBooking.Status,
                ToPlaceId = createdBooking.ToPlaceId,
                Id = createdBooking.Id
            };
            return responseModel;
        }

        public async Task<BookingDetailResponseModel> DeleteBookingById(int id)
        {
            var toDeleteBooking = await _bookingRepository.GetById(id);
            if (toDeleteBooking == null)
                return null;
            var deletedBooking = await _bookingRepository.DeleteAsync(toDeleteBooking);
            var returnedBooking = new BookingDetailResponseModel
            {
                PickUpAddress = deletedBooking.PickUpAddress,
                BookingDate = deletedBooking.BookingDate,
                BookingTime = deletedBooking.BookingTime,
                CabTypeId = deletedBooking.CabTypeId,
                ContactNo = deletedBooking.ContactNo,
                Email = deletedBooking.Email,
                FromPlaceId = deletedBooking.FromPlaceId,
                Landmark = deletedBooking.Landmark,
                PickupDate = deletedBooking.PickupDate,
                PickupTime = deletedBooking.PickupTime,
                Status = deletedBooking.Status,
                ToPlaceId = deletedBooking.ToPlaceId,
                Id = deletedBooking.Id
            };
            return returnedBooking;
        }

        public async Task<IEnumerable<BookingSummaryResponseModel>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            var summaries = new List<BookingSummaryResponseModel>();
            foreach (var booking in bookings)
            {
                var cur = new BookingSummaryResponseModel
                {
                    BookingDate = booking.BookingDate,
                    CabType = new CabTypeResponseModel
                    {
                        CabTypeId = booking.CabType.CabTypeId,
                        CabTypeName = booking.CabType.CabTypeName
                    },
                    CabTypeId = booking.CabTypeId,
                    FromPlace = new PlaceResponseModel
                    {
                        PlaceId = booking.FromPlace.PlaceId,
                        PlaceName = booking.FromPlace.PlaceName
                    },
                    FromPlaceId = booking.FromPlaceId,
                    Id = booking.Id,
                    PickupDate = booking.PickupDate,
                    Status = booking.Status,
                    ToPlace = new PlaceResponseModel
                    {
                        PlaceId = booking.ToPlace.PlaceId,
                        PlaceName = booking.ToPlace.PlaceName
                    },
                    ToPlaceId = booking.ToPlaceId
                };
                summaries.Add(cur);
            }
            return summaries;
        }

        public async Task<BookingDetailResponseModel> GetBookingById(int id)
        {
            var history = await _bookingRepository.GetById(id);
            if (history == null)
                return null;
            var returnedBooking = new BookingDetailResponseModel
            {
                PickUpAddress = history.PickUpAddress,
                BookingDate = history.BookingDate,
                BookingTime = history.BookingTime,
                CabTypeId = history.CabTypeId,
                ContactNo = history.ContactNo,
                Email = history.Email,
                FromPlaceId = history.FromPlaceId,
                Landmark = history.Landmark,
                PickupDate = history.PickupDate,
                PickupTime = history.PickupTime,
                Status = history.Status,
                ToPlaceId = history.ToPlaceId,
                Id = history.Id,
                CabType = new CabTypeResponseModel
                {
                    CabTypeId = history.CabType.CabTypeId,
                    CabTypeName = history.CabType.CabTypeName
                },
                FromPlace = new PlaceResponseModel
                {
                    PlaceId = history.FromPlace.PlaceId,
                    PlaceName = history.FromPlace.PlaceName
                },
                ToPlace = new PlaceResponseModel
                {
                    PlaceId = history.ToPlace.PlaceId,
                    PlaceName = history.ToPlace.PlaceName
                }
            };
            return returnedBooking;
        }

        public async Task<BookingDetailResponseModel> UpdateBooking(BookingUpdateRequestModel bookingUpdateRequestModel)
        {
            var booking = new Booking
            {
                PickUpAddress = bookingUpdateRequestModel.PickUpAddress,
                BookingDate = bookingUpdateRequestModel.BookingDate,
                BookingTime = bookingUpdateRequestModel.BookingTime,
                CabTypeId = bookingUpdateRequestModel.CabTypeId,
                ContactNo = bookingUpdateRequestModel.ContactNo,
                Email = bookingUpdateRequestModel.Email,
                FromPlaceId = bookingUpdateRequestModel.FromPlaceId,
                Landmark = bookingUpdateRequestModel.Landmark,
                PickupDate = bookingUpdateRequestModel.PickupDate,
                PickupTime = bookingUpdateRequestModel.PickupTime,
                Status = bookingUpdateRequestModel.Status,
                ToPlaceId = bookingUpdateRequestModel.ToPlaceId,
                Id = bookingUpdateRequestModel.Id,
            };
            var updatedBooking = await _bookingRepository.UpdateAsync(booking);
            if (updatedBooking == null)
                throw new Exception("Update Booking Failed!");
            var responseModel = new BookingDetailResponseModel
            {
                PickUpAddress = updatedBooking.PickUpAddress,
                BookingDate = updatedBooking.BookingDate,
                BookingTime = updatedBooking.BookingTime,
                CabTypeId = updatedBooking.CabTypeId,
                ContactNo = updatedBooking.ContactNo,
                Email = updatedBooking.Email,
                FromPlaceId = updatedBooking.FromPlaceId,
                Landmark = updatedBooking.Landmark,
                PickupDate = updatedBooking.PickupDate,
                PickupTime = updatedBooking.PickupTime,
                Status = updatedBooking.Status,
                ToPlaceId = updatedBooking.ToPlaceId,
                Id = updatedBooking.Id,
            };
            return responseModel;
        }
    }
}
