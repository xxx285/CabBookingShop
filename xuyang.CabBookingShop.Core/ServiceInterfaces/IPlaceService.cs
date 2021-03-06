using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Models.Request;
using xuyang.CabBookingShop.Core.Models.Response;

namespace xuyang.CabBookingShop.Core.ServiceInterfaces
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceResponseModel>> GetAllPlaces();
        Task<PlaceResponseModel> AddPlace(PlaceCreateRequestModel placeCreateRequestModel);
        Task<PlaceResponseModel> DeletePlaceById(int id);
        Task<PlaceResponseModel> UpdatePlace(PlaceUpdateRequestModel placeUpdateRequestModel);
    }
}
