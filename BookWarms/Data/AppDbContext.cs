using Microsoft.EntityFrameworkCore;
using BookWarms.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;

namespace BookWarms.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReadingStat> ReadingStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Shelf>().ToTable("Shelves");
            modelBuilder.Entity<Review>().ToTable("Reviews");
            modelBuilder.Entity<ReadingStat>().ToTable("ReadingStats");

            modelBuilder.Entity<Shelf>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Shelf>()
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey(s => s.BookId);
            modelBuilder.Entity<Review>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Review>()
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "Kristiana",
                Email = "krisistoyanova2008@gmail.com",
                PasswordHash = "1234"
            });
            modelBuilder.Entity<Book>().HasData(
       new Book
       {
           Id = 1,
           Title = "The Great Gatsby",
           Author = "F. Scott Fitzgerald",
           Genre = "Classic",
           Description = "A novel set in the Roaring Twenties.",
           PageCount = 180
       },
       new Book
       {
           Id = 2,
           Title = "1984",
           Author = "George Orwell",
           Genre = "Dystopian",
           Description = "A story about a totalitarian regime.",
           PageCount = 328
       }
   );

            modelBuilder.Entity<Shelf>().HasData(
                new Shelf
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    ShelfType = ShelfType.Reading
                },
                new Shelf
                {
                    Id = 2,
                    UserId = 1,
                    BookId = 2,
                    ShelfType = ShelfType.Want
                }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    Rating = 5,
                    ReviewText = "A timeless classic!",
                    Date = new DateTime(2025, 7, 8)
                }
            );

            modelBuilder.Entity<ReadingStat>().HasData(
                new ReadingStat
                {
                    Id = 1,
                    UserId = 1,
                    Year = 2025,
                    BooksRead = 2,
                    PagesRead = 508
                }
            );
        }
    }
}
