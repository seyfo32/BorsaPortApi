using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
       protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x=> x.HasKey(p=> new {p.AppUserId,p.StockId}));

            builder.Entity<Portfolio>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(p=>p.AppUserId);
            
              builder.Entity<Portfolio>()
            .HasOne(u => u.stock)
            .WithMany(u => u.Porfolios)
            .HasForeignKey(p=>p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
    {
        new IdentityRole
        {
            Id = "admin-role-id",
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = "a1111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"
        },
        new IdentityRole
        {
            Id = "user-role-id",
            Name = "User",
            NormalizedName = "USER",
            ConcurrencyStamp = "b2222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"
        }
    };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}