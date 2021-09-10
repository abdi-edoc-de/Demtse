using Demጽ.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.DbContexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Subscribe> Subscribtions { get; set; }

        public DbSet<RecentlyPlayed> RecentlyPlayeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Subscribe>()
                .HasKey(c => new { c.UserId, c.ChannelId });
           
            
            
            





        }
    }
}
