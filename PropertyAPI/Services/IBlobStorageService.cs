using RealEstateApi.Models;

namespace RealEstateApi.Services
{
    public interface IBlobStorageService
    {
        Task<(List<Property>?, string?)> GetPropertiesAsync();

    }
}
