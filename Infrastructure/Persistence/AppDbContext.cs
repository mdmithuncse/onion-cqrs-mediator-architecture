using Microsoft.EntityFrameworkCore;
using Application;
using Domain;
using System;
using System.Threading.Tasks;

namespace Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Organization> Organizations { get; set; }

        public async Task<long> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
