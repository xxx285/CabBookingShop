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
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<HistoryDetailResponseModel> AddHistory(HistoryCreateRequestModel historyCreateRequestModel)
        {
            var history = new BookingHistory
            {
                PickUpAddress = historyCreateRequestModel.PickUpAddress,
                BookingDate = historyCreateRequestModel.BookingDate,
                BookingTime = historyCreateRequestModel.BookingTime,
                CabTypeId = historyCreateRequestModel.CabTypeId,
                Charge = historyCreateRequestModel.Charge,
                CompTime = historyCreateRequestModel.CompTime,
                ContactNo = historyCreateRequestModel.ContactNo,
                Email = historyCreateRequestModel.Email,
                Feedback = historyCreateRequestModel.Feedback,
                FromPlaceId = historyCreateRequestModel.FromPlaceId,
                Landmark = historyCreateRequestModel.Landmark,
                PickupDate = historyCreateRequestModel.PickupDate,
                PickupTime = historyCreateRequestModel.PickupTime,
                Status = historyCreateRequestModel.Status,
                ToPlaceId = historyCreateRequestModel.ToPlaceId
            };
            var createdHistory = await _historyRepository.AddAsync(history);
            if (createdHistory == null)
                throw new Exception("Booking History Creation Failed!");
            var returnedHistory = new HistoryDetailResponseModel
            {
                PickUpAddress = createdHistory.PickUpAddress,
                BookingDate = createdHistory.BookingDate,
                BookingTime = createdHistory.BookingTime,
                CabTypeId = createdHistory.CabTypeId,
                Charge = createdHistory.Charge,
                CompTime = createdHistory.CompTime,
                ContactNo = createdHistory.ContactNo,
                Email = createdHistory.Email,
                Feedback = createdHistory.Feedback,
                FromPlaceId = createdHistory.FromPlaceId,
                Id = createdHistory.Id,
                Landmark = createdHistory.Landmark,
                PickupDate = createdHistory.PickupDate,
                PickupTime = createdHistory.PickupTime,
                Status = createdHistory.Status,
                ToPlaceId = createdHistory.ToPlaceId,
            };
            return returnedHistory;
        }

        public async Task<HistoryDetailResponseModel> DeleteHistoryById(int id)
        {
            var toDeleteHistory = await _historyRepository.GetById(id);
            if (toDeleteHistory == null)
                return null;
            var deletedHistory = await _historyRepository.DeleteAsync(toDeleteHistory);
            var returnedHistory = new HistoryDetailResponseModel
            {
                PickUpAddress = deletedHistory.PickUpAddress,
                BookingDate = deletedHistory.BookingDate,
                BookingTime = deletedHistory.BookingTime,
                CabTypeId = deletedHistory.CabTypeId,
                Charge = deletedHistory.Charge,
                CompTime = deletedHistory.CompTime,
                ContactNo = deletedHistory.ContactNo,
                Email = deletedHistory.Email,
                Feedback = deletedHistory.Feedback,
                FromPlaceId = deletedHistory.FromPlaceId,
                Id = deletedHistory.Id,
                Landmark = deletedHistory.Landmark,
                PickupDate = deletedHistory.PickupDate,
                PickupTime = deletedHistory.PickupTime,
                Status = deletedHistory.Status,
                ToPlaceId = deletedHistory.ToPlaceId,
            };
            return returnedHistory;
        }

        public async Task<IEnumerable<HistorySummaryResponseModel>> GetAllBookingHistories()
        {
            var historySummaries = await _historyRepository.GetAllAsync();
            var responseModels = new List<HistorySummaryResponseModel>();
            foreach (var summary in historySummaries)
            {
                var cur = new HistorySummaryResponseModel
                {
                    Id = summary.Id,
                    BookingDate = summary.BookingDate,
                    CabType = new CabTypeResponseModel
                    {
                        CabTypeId = summary.CabType.CabTypeId,
                        CabTypeName = summary.CabType.CabTypeName
                    },
                    CabTypeId = summary.CabTypeId,
                    CompTime = summary.CompTime,
                    FromPlace = new PlaceResponseModel
                    {
                        PlaceId = summary.FromPlace.PlaceId,
                        PlaceName = summary.FromPlace.PlaceName
                    },
                    FromPlaceId = summary.FromPlaceId,
                    ToPlace = new PlaceResponseModel
                    {
                        PlaceId = summary.ToPlace.PlaceId,
                        PlaceName = summary.ToPlace.PlaceName
                    },
                    ToPlaceId = summary.ToPlaceId
                };
                responseModels.Add(cur);
            }
            return responseModels;
        }

        public async Task<HistoryDetailResponseModel> UpdateHistory(HistoryUpdateRequestModel historyUpdateRequestModel)
        {
            var history = new BookingHistory
            {
                PickUpAddress = historyUpdateRequestModel.PickUpAddress,
                BookingDate = historyUpdateRequestModel.BookingDate,
                BookingTime = historyUpdateRequestModel.BookingTime,
                CabTypeId = historyUpdateRequestModel.CabTypeId,
                Charge = historyUpdateRequestModel.Charge,
                CompTime = historyUpdateRequestModel.CompTime,
                ContactNo = historyUpdateRequestModel.ContactNo,
                Email = historyUpdateRequestModel.Email,
                Feedback = historyUpdateRequestModel.Feedback,
                FromPlaceId = historyUpdateRequestModel.FromPlaceId,
                Id = historyUpdateRequestModel.Id,
                Landmark = historyUpdateRequestModel.Landmark,
                PickupDate = historyUpdateRequestModel.PickupDate,
                PickupTime = historyUpdateRequestModel.PickupTime,
                Status = historyUpdateRequestModel.Status,
                ToPlaceId = historyUpdateRequestModel.ToPlaceId,
            };
            var updatedHistory = await _historyRepository.UpdateAsync(history);
            if (updatedHistory == null)
                throw new Exception("Update History Failed!");
            var responseModel = new HistoryDetailResponseModel
            {
                PickUpAddress = updatedHistory.PickUpAddress,
                BookingDate = updatedHistory.BookingDate,
                BookingTime = updatedHistory.BookingTime,
                CabTypeId = updatedHistory.CabTypeId,
                Charge = updatedHistory.Charge,
                CompTime = updatedHistory.CompTime,
                ContactNo = updatedHistory.ContactNo,
                Email = updatedHistory.Email,
                Feedback = updatedHistory.Feedback,
                FromPlaceId = updatedHistory.FromPlaceId,
                Id = updatedHistory.Id,
                Landmark = updatedHistory.Landmark,
                PickupDate = updatedHistory.PickupDate,
                PickupTime = updatedHistory.PickupTime,
                Status = updatedHistory.Status,
                ToPlaceId = updatedHistory.ToPlaceId,
            };
            return responseModel;
        }
    }
}
