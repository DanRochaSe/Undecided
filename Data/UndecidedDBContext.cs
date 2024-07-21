using Microsoft.EntityFrameworkCore;
using UndecidedApp.Data.Models.PostModels;

namespace UndecidedApp.Data
{
    public class UndecidedDBContext : DbContext
    {
            public UndecidedDBContext(DbContextOptions<UndecidedDBContext> options) : base(options) { }

            public DbSet<Post> Post => Set<Post>();
            public DbSet<Comment> Comment => Set<Comment>();


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

            }


        

    }
}
