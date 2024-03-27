using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlappyBird.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FlappyBird.Data
{
    public class FlappyBirdContext : IdentityDbContext<User>
    {
        public FlappyBirdContext (DbContextOptions<FlappyBirdContext> options)
            : base(options)
        {
        }

        public DbSet<FlappyBird.Models.Score> Score { get; set; } = default!;
    }
}
