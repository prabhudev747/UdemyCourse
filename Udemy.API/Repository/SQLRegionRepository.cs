using Microsoft.EntityFrameworkCore;
using Udemy.API.DBContext;
using Udemy.API.Models;

namespace Udemy.API.Repository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly UdemyDB context;
        public SQLRegionRepository(UdemyDB contex) {
            this.context = contex;
        }
        public async Task<List<Region>> GetAllAsync()
        {
           return await context.Regions.ToListAsync();
        }

    }
}
