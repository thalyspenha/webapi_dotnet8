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

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portifolio> Portifolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Portifolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));
            builder.Entity<Portifolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portifolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portifolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portifolios)
                .HasForeignKey(p => p.StockId);    




            List<IdentityRole> roles =
            [
                new IdentityRole{
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}