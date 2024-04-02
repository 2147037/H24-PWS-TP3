using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlappyBird.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FlappyBird.Data
{
    public class FlappyBirdContext : IdentityDbContext<User>
    {
        public FlappyBirdContext (DbContextOptions<FlappyBirdContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Utilisateur

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User Paul = new User
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "Paul",
                Email = "paul@mail.com",
                NormalizedEmail = "PAUL@MAIL.COM",
                NormalizedUserName = "PAUL"
            };
            Paul.PasswordHash = hasher.HashPassword(Paul, "12345");
            builder.Entity<User>().HasData(Paul);
            User Ezat = new User
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "Ezat",
                Email = "Ezat@mail.com",
                NormalizedEmail = "EZAT@MAIL.COM",
                NormalizedUserName = "EZAT"
            };
            Ezat.PasswordHash = hasher.HashPassword(Ezat, "12345");
            builder.Entity<User>().HasData(Ezat);


            //Score
            builder.Entity<Score>().HasData(new
            {
                Id = 1,
                ScoreValue = 14,
                TimeInSeconds = 3.21,
                Date = DateTime.Now,
                IsPublic = false,
                UserId = "11111111-1111-1111-1111-111111111111"

            }, new
            {
                Id = 2,
                ScoreValue = 144,
                TimeInSeconds = 32.11,
                Date = DateTime.Now,
                IsPublic = true,
                UserId = "11111111-1111-1111-1111-111111111111"
            }, new
            {
                Id = 3,
                ScoreValue = 432,
                TimeInSeconds = 70.23,
                Date = DateTime.Now,
                IsPublic = true,
                UserId = "11111111-1111-1111-1111-111111111112"
            }, new
            {
                Id = 4,
                ScoreValue = 1,
                TimeInSeconds = 12.43,
                Date = DateTime.Now,
                IsPublic = false,
                UserId = "11111111-1111-1111-1111-111111111112"
            }); 
        }

        public DbSet<FlappyBird.Models.Score> Score { get; set; } = default!;
    }
}
