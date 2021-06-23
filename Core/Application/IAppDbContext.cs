using Microsoft.EntityFrameworkCore;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAppDbContext
    {
        DbSet<Organization> Organizations { get; set; }
        Task<long> SaveChangesAsync();
    }
}
