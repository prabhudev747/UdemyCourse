using Microsoft.EntityFrameworkCore;
using Udemy.API.Models;

namespace Udemy.API.DBContext
{
    public class UdemyDB : DbContext
    {
        public UdemyDB(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
