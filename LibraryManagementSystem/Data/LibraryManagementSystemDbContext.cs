
using LibraryManagementSystem.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryManagementSystemDbContext : DbContext
    {
       
         public DbSet<Book> Book { get; set; }
         public DbSet<BookDetails> BookDetail { get; set; }
        public DbSet<Library> Librarie { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public string ConnectionString => "Server=DESKTOP-107VU66;Database=LibraryManagementSystemDb;Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Server=DESKTOP-107VU66;Database=LibraryManagementSystemDb;Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True"
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
