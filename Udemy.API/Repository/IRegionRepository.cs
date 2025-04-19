using Udemy.API.Models;

namespace Udemy.API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
