using ApiDevBP.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiDevBP.Data
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options)
      : base(options)
        {
        }
        public DbSet<UserEntity> UserEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");

            base.OnModelCreating(modelBuilder);
        }
    }
}
