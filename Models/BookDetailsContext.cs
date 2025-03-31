using Microsoft.EntityFrameworkCore;
namespace BookStoreAPI.Models;

public class BookDetailsContext : DbContext
{
    public BookDetailsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BookDetail> BookDetails { get; set; }
}

