using Microsoft.EntityFrameworkCore;
using notes_api.Data.Entities;

namespace notes_api.Data.Context
{
    public class InMemoryDbContext : DbContext
    {

        public InMemoryDbContext(DbContextOptions opt) : base(opt){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                        .Property(e => e.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Note>()
                        .Property(e => e.TimeStamp)
                        .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Note> Notes => Set<Note>();
    }
}
