using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    // Normal bir db context den miras almadık çünkü user işlemleri de yapıcaz bu yüzden 
    // IdentityDbContext'den miras aldık.
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        protected AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);


            base.OnModelCreating(builder);
        }


    }



}
