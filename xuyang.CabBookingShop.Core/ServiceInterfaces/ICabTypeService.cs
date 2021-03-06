using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Entities;
using xuyang.CabBookingShop.Core.Models.Request;
using xuyang.CabBookingShop.Core.Models.Response;

namespace xuyang.CabBookingShop.Core.ServiceInterfaces
{
    public interface ICabTypeService
    {
        Task<IEnumerable<CabTypeResponseModel>> GetAllCabTypes();
        Task<CabTypeResponseModel> UpdateCabType(CabTypeUpdateRequestModel cabTypeUpdateRequestModel);
        Task<CabTypeResponseModel> DeleteCabTypeById(int id);
        Task<CabTypeResponseModel> AddCabType(CabTypeCreateRequestModel cabTypeRequestModel);
    }
}
