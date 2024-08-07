
using BookCatalogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogApi.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Rental> Rentals {get; set;}
}