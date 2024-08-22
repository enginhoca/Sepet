using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired(false).HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Genel",
                    Description = "Genel kategorisine giren ve kategorisiz kalan kitaplar",
                    IsHome = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Bilim Kurgu",
                    Description = "Bilim Kurgu Kitapları",
                    IsHome = true
                },
                new Category
                {
                    Id = 3,
                    Name = "Bilim ve Mühendislik",
                    Description = "Bilim ve Mühendislik Kitapları",
                    IsHome = true
                },
                new Category
                {
                    Id = 4,
                    Name = "Distopya",
                    Description = "Distopya Kitapları",
                    IsHome = true
                },
                new Category
                {
                    Id = 5,
                    Name = "Dünya Tarihi",
                    Description = "Dünya Tarihi Kitapları",
                    IsHome = true
                },
                new Category
                {
                    Id = 6,
                    Name = "Edebiyat",
                    Description = "Edebiyat Kitapları",
                },
                new Category
                {
                    Id = 7,
                    Name = "Fizik",
                    Description = "Fizik Kitapları"
                },
                new Category
                {
                    Id = 8,
                    Name = "İnsan ve Toplum",
                    Description = "İnsan ve Toplum Kitapları",
                },
                new Category
                {
                    Id = 9,
                    Name = "Kişisel Gelişim",
                    Description = "Kişisel Kitapları",
                },
                new Category
                {
                    Id = 10,
                    Name = "Popüler Bilim",
                    Description = "Popüler Bilim Kitapları",
                },
                new Category
                {
                    Id = 11,
                    Name = "Roman",
                    Description = "Romanlar",
                },
                new Category
                {
                    Id = 12,
                    Name = "Rus Edebiyatı",
                    Description = "Rus Edebiyatı Kitapları",
                },
                new Category
                {
                    Id = 13,
                    Name = "Söyleşi",
                    Description = "Söyleşi Kitapları",
                },
                new Category
                {
                    Id = 14,
                    Name = "Tarih",
                    Description = "Tarih Kitapları",
                },
                new Category
                {
                    Id = 15,
                    Name = "Türkiye Tarihi",
                    Description = "Türkiye Tarihi Kitapları",
                });

        }
    }
}