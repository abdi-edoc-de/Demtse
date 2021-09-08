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
        public object BCrypt { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Subscribe>()
                .HasKey(c => new { c.UserId, c.ChannelId });





            modelBuilder.Entity<Channel>().HasData(
                          new Channel
                          {
                              Id = "102b566b-ba1f-404c-b2df-e2cde39ade09",
                              Name = "Everything is Alive",
                              Description = "This is a cool podcast where we interview inanimate objects",
                              ProfilePicture = "So this should be a path to profile pics",
                              UserId = "261672a7-358b-4b6c-8ff3-6f7358999f6b",

                          },
                          new Channel
                          {
                              Id = "2902b665-1190-4c70-9915-b9c2d7680450",
                              Name = "Everything is Not Alive",
                              Description = "This is a Not cool podcast where we interview inanimate objects",
                              ProfilePicture = "So this should Not be a path to profile pics",
                              UserId = "2545b40c-004f-43a7-883d-336422040b17",
                          },
                          new Channel
                          {
                              Id = "2ee49fe3-edf2-4f91-8409-3eb25ce6ca51",

                              Name="Third Channel",
                              Description="This is desc",
                              ProfilePicture="Selfie",
                              UserId= "0581520d-52f6-4f56-af85-efd6a3ca79df"
                          }

                          );







        }
    }
}
