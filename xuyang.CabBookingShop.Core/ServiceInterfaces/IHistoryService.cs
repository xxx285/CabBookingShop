using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Models.Request;
using xuyang.CabBookingShop.Core.Models.Response;

namespace xuyang.CabBookingShop.Core.ServiceInterfaces
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistorySummaryResponseModel>> GetAllBookingHistories();
        Task<HistoryDetailResponseModel> DeleteHistoryById(int id);
        Task<HistoryDetailResponseModel> AddHistory(HistoryCreateRequestModel historyCreateRequestModel);
        Task<HistoryDetailResponseModel> UpdateHistory(HistoryUpdateRequestModel historyUpdateRequestModel);
        Task<HistoryDetailResponseModel> GetHistoryById(int id);
    }
}
