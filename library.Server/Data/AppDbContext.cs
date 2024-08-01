using library.Server.Data;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    public void SeedData()
    {
        if (!Books.Any())
        {
            var dataGenerator = new DataGenerator();
            List<Book> librarybooks = dataGenerator.GenerateBooks(100);
            Books.AddRange(librarybooks);
            SaveChanges();
        }
    }

}