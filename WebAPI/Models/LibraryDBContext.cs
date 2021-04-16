using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
  public class LibraryDBContext : DbContext
  {
    private readonly Action<LibraryDBContext, ModelBuilder> _customizeModel;

        #region Constructors
        public LibraryDBContext()
        {
        }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) 
          : base(options) 
        {
        }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options, Action<LibraryDBContext, ModelBuilder> customizeModel)
            : base(options)
        {
            _customizeModel = customizeModel;
        }
        #endregion
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (optionsBuilder.IsConfigured){
        optionsBuilder.UseSqlServer("Server=DESKTOP-BAIITTC\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Book>()
        .HasOne<Category>(s => s.Category)
        .WithMany(g => g.Books)
        .HasForeignKey(s => s.CategoryId);
      modelBuilder.Entity<BookBorrowingRequest>()
        .HasMany(p => p.Books)
        .WithMany(p => p.RequestOrders)
        .UsingEntity<BookBorrowingRequestDetails >(
            j => j
                .HasOne(pt => pt.Book)
                .WithMany(t => t.RequestDetails)
                .HasForeignKey(pt => pt.BookId),
            j => j
                .HasOne(pt => pt.RequestOrder)
                .WithMany(p => p.RequestDetails)
                .HasForeignKey(pt => pt.RequestOrderId)
        );
      modelBuilder.Entity<BookBorrowingRequest>()
        .HasOne<User>(s => s.User)
        .WithMany(g => g.RequestOrders)
        .HasForeignKey(s => s.UserId);
      modelBuilder.Entity<User>()
        .HasOne<Role>(s => s.Role)
        .WithMany(g => g.Users)
        .HasForeignKey(s => s.RoleId);
      
    }

    public DbSet<Book> Books {get; set; }
    public DbSet<Category> Categories {get; set; }
    public DbSet<User> Users {get; set; }
    public DbSet<BookBorrowingRequestDetails > RequestDetails {get; set; }
    public DbSet<BookBorrowingRequest> RequestOrders {get; set; }
  }
}