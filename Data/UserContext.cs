using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoprofsXyn.Models;

namespace GeoprofsXyn.Data
{
    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Verlof> Verlof { get; set; }
        public DbSet<VerlofSoort> VerlofSoort { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Verlof>().ToTable("Verlof");
            modelBuilder.Entity<VerlofSoort>().ToTable("VerlofSoort");
        }
    }
}
