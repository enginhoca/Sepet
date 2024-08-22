using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Data.Concrete.EfCore.Configs;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data
{
    public class BooksAppDbContext : DbContext
    {
        //Bu satır sayesinde oluşturulacak ya da var olan veri tabanında Categories adında bir tablo oluşturacak. Bu tablonun kolonları, Category classının propertylerinden yaratılacak. Bu davranışa Default Convention diyoruz.

        public BooksAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Alttaki satır, primary key kullanmak istemediğimizi belirtiyor
            // modelBuilder.Entity<BookCategory>().HasNoKey();

            //Alttaki satır, BookCategory entitiysi içindeki BookId-CategoryId ikilisini kullanarak bir composite(birleşik) primary key yaratır.

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}