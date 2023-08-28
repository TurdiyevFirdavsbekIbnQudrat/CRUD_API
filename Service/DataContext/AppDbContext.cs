using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Service.DataContext
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Company> Companies { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Staff> Staffs { get; set; }
        }
    }
