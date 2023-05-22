using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ryada.Models;

namespace ryada
{
    public class AppDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Book>().HasData(
            //    new Book { Id = 8, Title = "أكل", Author = "Author hasn", CategoryId = 3 , Price =50,Quantity=10}
            //    );
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<order> orders { get; set; }

    }
}
