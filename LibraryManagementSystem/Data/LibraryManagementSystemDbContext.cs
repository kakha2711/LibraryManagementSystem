
using LibraryManagementSystem.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class LibraryManagementSystemDbContext : DbContext
    {
       
         public DbSet<Book> Book { get; set; }
         public DbSet<BookDetails> BookDetail { get; set; }
        public DbSet<Library> Library { get; set; }
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


            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(4,2)");

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookGenre",
                    j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                    j =>
                    {
                        j.HasKey("BookId", "GenreId");
                        j.ToTable("BookGenres");
                    });
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookDetails)
                .WithOne(d => d.Book)
                .HasForeignKey<BookDetails>(d => d.Id);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Library)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LibraryId);



            modelBuilder.Entity<BookDetails>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<BookDetails>()
                .Property(d => d.ISBN)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<BookDetails>()
                .ToTable(d => d.HasCheckConstraint(
                                                    "CK_BookDetails_PageCount",
                                                    "PageCount > 0"))
                .Property(d => d.PageCount)
                .IsRequired()
                .HasColumnType("int");
            modelBuilder.Entity<BookDetails>()
                .ToTable(d => d.HasCheckConstraint(
                                                    "CK_BookDetails_PublishedYear",
                                                    "PublishedYear >= 1000 AND PublishedYear <= 2023"))
                .Property(d => d.PublishedYear)
                .IsRequired()
                .HasColumnType("int");
            modelBuilder.Entity<BookDetails>()
                .HasOne(d => d.Book)
                .WithOne(b => b.BookDetails)
                .HasForeignKey<BookDetails>(d => d.Id);


            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Genre>()
                .Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "BookGenre",
                    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                    j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    j =>
                    {
                        j.HasKey("BookId", "GenreId");
                        j.ToTable("BookGenres");
                    });

            modelBuilder.Entity<Library>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<Library>()
                .Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Library>()
                .Property(l => l.Address)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Library>()
                .HasMany(l => l.Books)
                .WithOne(b => b.Library)
                .HasForeignKey(b => b.LibraryId);
        }
    }
}
