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
    public class CabTypeService : ICabTypeService
    {
        private readonly ICabTypeRepository _cabTypeRepository;
        public CabTypeService(ICabTypeRepository cabTypeRepository)
        {
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<CabTypeResponseModel> AddCabType(CabTypeCreateRequestModel cabTypeRequestModel)
        {
            var cabType = new CabType
            {
                CabTypeName = cabTypeRequestModel.CabTypeName
            };
            var createdCabType = await _cabTypeRepository.AddAsync(cabType);
            if (createdCabType == null)
                throw new Exception("Creating CabType Failed!");
            var returnedType = new CabTypeResponseModel
            {
                CabTypeId = createdCabType.CabTypeId,
                CabTypeName = createdCabType.CabTypeName
            };
            return returnedType;
        }

        public async Task<CabTypeResponseModel> DeleteCabTypeById(int id)
        {
            var type = await _cabTypeRepository.GetById(id);
            if (type == null)
                return null;
            var deletedType = await _cabTypeRepository.DeleteAsync(type);
            var returnedType = new CabTypeResponseModel
            {
                CabTypeId = deletedType.CabTypeId,
                CabTypeName = deletedType.CabTypeName
            };
            return returnedType;
        }

        public async Task<IEnumerable<CabTypeResponseModel>> GetAllCabTypes()
        {
            var types = await _cabTypeRepository.GetAllAsync();
            var responseModels = new List<CabTypeResponseModel>();
            foreach (var type in types)
            {
                var cur = new CabTypeResponseModel
                {
                    CabTypeId = type.CabTypeId,
                    CabTypeName = type.CabTypeName
                };
                responseModels.Add(cur);
            }
            return responseModels;
        }

        public async Task<CabTypeResponseModel> GetCabTypeById(int id)
        {
            var type = await _cabTypeRepository.GetById(id);
            if (type == null)
                return null;
            var returned = new CabTypeResponseModel
            {
                CabTypeId = type.CabTypeId,
                CabTypeName = type.CabTypeName
            };
            return returned;
        }

        public async Task<CabTypeResponseModel> UpdateCabType(CabTypeUpdateRequestModel cabTypeUpdateRequestModel)
        {
            var type = new CabType
            {
                CabTypeId = cabTypeUpdateRequestModel.CabTypeId,
                CabTypeName = cabTypeUpdateRequestModel.CabTypeName
            };
            var updatedType = await _cabTypeRepository.UpdateAsync(type);
            var returnedType = new CabTypeResponseModel
            {
                CabTypeId = updatedType.CabTypeId,
                CabTypeName = updatedType.CabTypeName
            };
            return returnedType;
        }
    }
}
