using Microsoft.EntityFrameworkCore;

namespace BookAPI;

public class BookDbContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookAuthor> BookAuthors { get; set; }
    public virtual DbSet<BookCategory> BookCategories { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }
    public virtual DbSet<Reviewer> Reviewers { get; set; }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookCategory>()
            .HasKey(bc => new { bc.BookId, bc.CategoryId });
        modelBuilder.Entity<BookCategory>()
            .HasOne(bc => bc.Book)
            .WithMany(b => b.BookCategories)
            .HasForeignKey(bc => bc.BookId);
        modelBuilder.Entity<BookCategory>()
            .HasOne(bc => bc.Category)
            .WithMany(c => c.BookCategories)
            .HasForeignKey(bc => bc.CategoryId);
        
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new {ba.AuthorId, ba.BookId});
        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);
        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);
    }
}
