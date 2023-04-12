using InvoiceTracker.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTracker.Infrastructure.Data
{
    public class InvoiceTrackerDbContext: IdentityDbContext<ApplicationUser>
    {
        public InvoiceTrackerDbContext(DbContextOptions<InvoiceTrackerDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var roles = new IdentityRole[]
            {
                new IdentityRole()
                {
                    Id = "1",
                    ConcurrencyStamp = "462f2a91-f7b8-4dbd-a17c-4d3d279c566d",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = "2",
                    ConcurrencyStamp = "462f2a91-f7b8-4dbd-a17c-4d3d279c566d",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Invoice> Invoice { get; set;}
    }
}
