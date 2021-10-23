using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorYoutubeDl.Domain.Models.Identity;
using BlazorYoutubeDl.Domain.Models.Videos;

namespace BlazorYoutubeDl.API.Context
{
    public class YoutubeDlContext : DbContext
    {
        public YoutubeDlContext(DbContextOptions<YoutubeDlContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                .HasOne(v => v.User)
                .WithMany(u => u.Videos)
                .HasForeignKey(v => v.UserId);
        }
    }
}
