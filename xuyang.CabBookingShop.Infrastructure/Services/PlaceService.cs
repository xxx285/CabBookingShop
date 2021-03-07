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
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<PlaceResponseModel> AddPlace(PlaceCreateRequestModel placeCreateRequestModel)
        {
            var newPlace = new Place
            {
                PlaceName = placeCreateRequestModel.PlaceName
            };
            var createdPlace = await _placeRepository.AddAsync(newPlace);
            if (createdPlace == null)
                throw new Exception("Creating Place Failed!");
            var responseModel = new PlaceResponseModel
            {
                PlaceId = createdPlace.PlaceId,
                PlaceName = createdPlace.PlaceName
            };
            return responseModel;
        }

        public async Task<PlaceResponseModel> DeletePlaceById(int id)
        {
            var place = await _placeRepository.GetById(id);
            if (place == null)
                return null;
            var deletedPlace = await _placeRepository.DeleteAsync(place);
            var returnedPlace = new PlaceResponseModel
            {
                PlaceId = deletedPlace.PlaceId,
                PlaceName = deletedPlace.PlaceName
            };
            return returnedPlace;
        }

        public async Task<IEnumerable<PlaceResponseModel>> GetAllPlaces()
        {
            var places = await _placeRepository.GetAllAsync();
            var responseModels = new List<PlaceResponseModel>();
            foreach (var place in places)
            {
                var cur = new PlaceResponseModel
                {
                    PlaceId = place.PlaceId,
                    PlaceName = place.PlaceName
                };
                responseModels.Add(cur);
            }
            return responseModels;
        }

        public async Task<PlaceResponseModel> GetPlaceById(int id)
        {
            var place = await _placeRepository.GetById(id);
            if (place == null)
                return null;
            var returnedPlace = new PlaceResponseModel
            {
                PlaceId = place.PlaceId,
                PlaceName = place.PlaceName
            };
            return returnedPlace;
        }

        public async Task<PlaceResponseModel> UpdatePlace(PlaceUpdateRequestModel placeUpdateRequestModel)
        {
            var place = new Place
            {
                PlaceId = placeUpdateRequestModel.PlaceId,
                PlaceName = placeUpdateRequestModel.PlaceName
            };
            var updatedPlace = await _placeRepository.UpdateAsync(place);
            var returnedPlace = new PlaceResponseModel
            {
                PlaceId = updatedPlace.PlaceId,
                PlaceName = updatedPlace.PlaceName
            };
            return returnedPlace;
        }
    }
}
