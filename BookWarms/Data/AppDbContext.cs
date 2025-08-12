using Microsoft.EntityFrameworkCore;
using BookWarms.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using static System.Reflection.Metadata.BlobBuilder;

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
                Username = "Admin: Kristiana Stoyanova",
                Email = "krisistoyanova2008@gmail.com"
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


            modelBuilder.Entity<User>().HasData(
                new User { Id = 2, Username = "Ivan Petrov", Email = "ivan@example.com" },
                new User { Id = 3, Username = "Maria Georgieva", Email = "maria@example.com" },
                new User { Id = 4, Username = "Petar Dimitrov", Email = "petar@example.com" },
                new User { Id = 5, Username = "Elena Koleva", Email = "elena@example.com" },
                new User { Id = 6, Username = "Stoyan Stoyanov", Email = "stoyan@example.com" },
                new User { Id = 7, Username = "Katerina Todorova", Email = "katerina@example.com" },
                new User { Id = 8, Username = "Nikolay Ivanov", Email = "nikolay@example.com" },
                new User { Id = 9, Username = "Hristo Hristov", Email = "hristo@example.com" },
                new User { Id = 10, Username = "Desislava Petrova", Email = "desislava@example.com" },
                new User { Id = 11, Username = "Dimitar Dimitrov", Email = "dimitar@example.com" },
                new User { Id = 12, Username = "Viktoria Mihaylova", Email = "viktoria@example.com" },
                new User { Id = 13, Username = "Aleksandar Angelov", Email = "aleksandar@example.com" },
                new User { Id = 14, Username = "Yana Stoyanova", Email = "yana@example.com" },
                new User { Id = 15, Username = "Georgi Georgiev", Email = "georgi@example.com" }
            );

            modelBuilder.Entity<Book>().HasData(

    new Book { Id = 3, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", Description = "A witty exploration of manners, morality, and love.", PageCount = 279 },
    new Book { Id = 4, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classic", Description = "A young girl's perspective on racial injustice in the Deep South.", PageCount = 324 },
    new Book { Id = 5, Title = "Moby Dick", Author = "Herman Melville", Genre = "Adventure", Description = "The obsessive quest for revenge against the white whale.", PageCount = 635 },
    new Book { Id = 6, Title = "War and Peace", Author = "Leo Tolstoy", Genre = "Historical", Description = "A sweeping narrative of love and conflict during Napoleon's invasion of Russia.", PageCount = 1225 },
    new Book { Id = 7, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Description = "Bilbo Baggins' journey to help dwarves reclaim their homeland.", PageCount = 310 },
    new Book { Id = 8, Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien", Genre = "Fantasy", Description = "The first part of the epic quest to destroy the One Ring.", PageCount = 423 },
    new Book { Id = 9, Title = "The Two Towers", Author = "J.R.R. Tolkien", Genre = "Fantasy", Description = "The fellowship is broken, and the war for Middle-earth begins.", PageCount = 352 },
    new Book { Id = 10, Title = "The Return of the King", Author = "J.R.R. Tolkien", Genre = "Fantasy", Description = "The final battle for Middle-earth.", PageCount = 416 },
    new Book { Id = 11, Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Genre = "Fantasy", Description = "A boy discovers he is a wizard and attends Hogwarts.", PageCount = 309 },
    new Book { Id = 12, Title = "Harry Potter and the Chamber of Secrets", Author = "J.K. Rowling", Genre = "Fantasy", Description = "A mysterious chamber holds a deadly secret.", PageCount = 341 },
    new Book { Id = 13, Title = "Harry Potter and the Prisoner of Azkaban", Author = "J.K. Rowling", Genre = "Fantasy", Description = "A dangerous prisoner escapes from Azkaban.", PageCount = 435 },
    new Book { Id = 14, Title = "Harry Potter and the Goblet of Fire", Author = "J.K. Rowling", Genre = "Fantasy", Description = "The Triwizard Tournament brings new dangers.", PageCount = 734 },
    new Book { Id = 15, Title = "Harry Potter and the Order of the Phoenix", Author = "J.K. Rowling", Genre = "Fantasy", Description = "Dark forces rise, and Dumbledore's Army is formed.", PageCount = 870 },
    new Book { Id = 16, Title = "Harry Potter and the Half-Blood Prince", Author = "J.K. Rowling", Genre = "Fantasy", Description = "Secrets of Voldemort's past come to light.", PageCount = 652 },
    new Book { Id = 17, Title = "Harry Potter and the Deathly Hallows", Author = "J.K. Rowling", Genre = "Fantasy", Description = "The final battle between Harry and Voldemort.", PageCount = 759 },
    new Book { Id = 18, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Classic", Description = "Holden Caulfield's story of teenage rebellion.", PageCount = 277 },
    new Book { Id = 19, Title = "The Alchemist", Author = "Paulo Coelho", Genre = "Fiction", Description = "A shepherd's journey to find his personal legend.", PageCount = 208 },
    new Book { Id = 20, Title = "Brave New World", Author = "Aldous Huxley", Genre = "Dystopian", Description = "A futuristic world shaped by genetic engineering.", PageCount = 288 },
    new Book { Id = 21, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Genre = "Classic", Description = "A psychological exploration of morality and guilt.", PageCount = 671 },
    new Book { Id = 22, Title = "Anna Karenina", Author = "Leo Tolstoy", Genre = "Romance", Description = "A tragic love affair in 19th century Russia.", PageCount = 864 },
    new Book { Id = 23, Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", Genre = "Philosophical", Description = "A profound exploration of faith, doubt, and morality.", PageCount = 796 },
    new Book { Id = 24, Title = "Les Misérables", Author = "Victor Hugo", Genre = "Historical", Description = "A sweeping story of redemption and revolution in France.", PageCount = 1232 },
    new Book { Id = 25, Title = "The Count of Monte Cristo", Author = "Alexandre Dumas", Genre = "Adventure", Description = "A tale of betrayal, revenge, and justice.", PageCount = 1276 },
    new Book { Id = 26, Title = "Dracula", Author = "Bram Stoker", Genre = "Horror", Description = "The iconic vampire story.", PageCount = 418 },
    new Book { Id = 27, Title = "Frankenstein", Author = "Mary Shelley", Genre = "Horror", Description = "A scientist creates life with tragic consequences.", PageCount = 280 },
    new Book { Id = 28, Title = "Jane Eyre", Author = "Charlotte Brontë", Genre = "Classic", Description = "A governess's journey to love and independence.", PageCount = 532 },
    new Book { Id = 29, Title = "Wuthering Heights", Author = "Emily Brontë", Genre = "Classic", Description = "A dark tale of passion and revenge on the Yorkshire moors.", PageCount = 416 },
    new Book { Id = 30, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", Genre = "Philosophical", Description = "A man remains young while his portrait ages.", PageCount = 254 },
    new Book { Id = 31, Title = "A Tale of Two Cities", Author = "Charles Dickens", Genre = "Historical", Description = "A story of love and sacrifice set during the French Revolution.", PageCount = 489 },
new Book { Id = 32, Title = "Great Expectations", Author = "Charles Dickens", Genre = "Classic", Description = "The journey of an orphan named Pip towards self-discovery.", PageCount = 505 },
new Book { Id = 33, Title = "David Copperfield", Author = "Charles Dickens", Genre = "Classic", Description = "A semi-autobiographical tale of growth and perseverance.", PageCount = 882 },
new Book { Id = 34, Title = "Oliver Twist", Author = "Charles Dickens", Genre = "Classic", Description = "The hardships of an orphan in Victorian London.", PageCount = 554 },
new Book { Id = 35, Title = "The Old Man and the Sea", Author = "Ernest Hemingway", Genre = "Fiction", Description = "An aging fisherman's struggle with a giant marlin.", PageCount = 127 },
new Book { Id = 36, Title = "For Whom the Bell Tolls", Author = "Ernest Hemingway", Genre = "Historical", Description = "A tale of love and sacrifice during the Spanish Civil War.", PageCount = 480 },
new Book { Id = 37, Title = "A Farewell to Arms", Author = "Ernest Hemingway", Genre = "Romance", Description = "A tragic romance set in World War I.", PageCount = 332 },
new Book { Id = 38, Title = "The Sun Also Rises", Author = "Ernest Hemingway", Genre = "Fiction", Description = "A group of expatriates in post-war Europe.", PageCount = 251 },
new Book { Id = 39, Title = "Catch-22", Author = "Joseph Heller", Genre = "Satire", Description = "The absurdities of war through the eyes of a bomber pilot.", PageCount = 453 },
new Book { Id = 40, Title = "Slaughterhouse-Five", Author = "Kurt Vonnegut", Genre = "Science Fiction", Description = "A soldier's journey through time and space after WWII.", PageCount = 275 },
new Book { Id = 41, Title = "The Grapes of Wrath", Author = "John Steinbeck", Genre = "Historical", Description = "A family's migration during the Great Depression.", PageCount = 464 },
new Book { Id = 42, Title = "Of Mice and Men", Author = "John Steinbeck", Genre = "Classic", Description = "The tragic story of two migrant workers during the Depression.", PageCount = 187 },
new Book { Id = 43, Title = "East of Eden", Author = "John Steinbeck", Genre = "Fiction", Description = "A multigenerational story of love, jealousy, and betrayal.", PageCount = 601 },
new Book { Id = 44, Title = "Cannery Row", Author = "John Steinbeck", Genre = "Fiction", Description = "A slice of life in a small California community.", PageCount = 208 },
new Book { Id = 45, Title = "Don Quixote", Author = "Miguel de Cervantes", Genre = "Classic", Description = "The adventures of a delusional knight and his loyal squire.", PageCount = 982 },
new Book { Id = 46, Title = "The Divine Comedy", Author = "Dante Alighieri", Genre = "Epic Poetry", Description = "A journey through Hell, Purgatory, and Paradise.", PageCount = 798 },
new Book { Id = 47, Title = "The Odyssey", Author = "Homer", Genre = "Epic Poetry", Description = "Odysseus' long journey home from the Trojan War.", PageCount = 541 },
new Book { Id = 48, Title = "The Iliad", Author = "Homer", Genre = "Epic Poetry", Description = "The final weeks of the Trojan War.", PageCount = 683 },
new Book { Id = 49, Title = "Meditations", Author = "Marcus Aurelius", Genre = "Philosophy", Description = "The Stoic reflections of a Roman emperor.", PageCount = 254 },
new Book { Id = 50, Title = "The Prince", Author = "Niccolò Machiavelli", Genre = "Political", Description = "A treatise on political power and leadership.", PageCount = 140 },
new Book { Id = 51, Title = "Thus Spoke Zarathustra", Author = "Friedrich Nietzsche", Genre = "Philosophy", Description = "A philosophical novel introducing the idea of the Übermensch.", PageCount = 327 },
new Book { Id = 52, Title = "Beyond Good and Evil", Author = "Friedrich Nietzsche", Genre = "Philosophy", Description = "A critique of traditional morality.", PageCount = 240 },
new Book { Id = 53, Title = "The Art of War", Author = "Sun Tzu", Genre = "Strategy", Description = "Ancient Chinese military strategy and tactics.", PageCount = 273 },
new Book { Id = 54, Title = "On the Origin of Species", Author = "Charles Darwin", Genre = "Science", Description = "The foundation of evolutionary biology.", PageCount = 502 },
new Book { Id = 55, Title = "Silent Spring", Author = "Rachel Carson", Genre = "Science", Description = "An environmental science book that sparked change.", PageCount = 378 },
new Book { Id = 56, Title = "A Brief History of Time", Author = "Stephen Hawking", Genre = "Science", Description = "An exploration of cosmology and black holes.", PageCount = 212 },
new Book { Id = 57, Title = "The Selfish Gene", Author = "Richard Dawkins", Genre = "Science", Description = "An influential work on evolutionary biology.", PageCount = 360 },
new Book { Id = 58, Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", Genre = "History", Description = "A sweeping history of humanity from ancient times to today.", PageCount = 443 },
new Book { Id = 59, Title = "Homo Deus: A Brief History of Tomorrow", Author = "Yuval Noah Harari", Genre = "History", Description = "Speculations about the future of humanity.", PageCount = 450 },
new Book { Id = 60, Title = "21 Lessons for the 21st Century", Author = "Yuval Noah Harari", Genre = "Nonfiction", Description = "Insights into the modern challenges of our world.", PageCount = 372 },
new Book { Id = 61, Title = "Thinking, Fast and Slow", Author = "Daniel Kahneman", Genre = "Psychology", Description = "An analysis of the two systems that drive our thinking.", PageCount = 499 },
new Book { Id = 62, Title = "Man's Search for Meaning", Author = "Viktor E. Frankl", Genre = "Psychology", Description = "A Holocaust survivor's reflections on purpose and resilience.", PageCount = 200 },
new Book { Id = 63, Title = "The Road", Author = "Cormac McCarthy", Genre = "Post-Apocalyptic", Description = "A father and son's journey in a desolate world.", PageCount = 287 },
new Book { Id = 64, Title = "Blood Meridian", Author = "Cormac McCarthy", Genre = "Western", Description = "A violent tale set in the 19th-century American West.", PageCount = 351 },
new Book { Id = 65, Title = "No Country for Old Men", Author = "Cormac McCarthy", Genre = "Thriller", Description = "A brutal chase after stolen drug money.", PageCount = 309 },
new Book { Id = 66, Title = "All the Pretty Horses", Author = "Cormac McCarthy", Genre = "Western", Description = "A young cowboy's journey into Mexico.", PageCount = 302 },
new Book { Id = 67, Title = "The Shining", Author = "Stephen King", Genre = "Horror", Description = "A haunted hotel turns a man into a danger to his family.", PageCount = 447 },
new Book { Id = 68, Title = "It", Author = "Stephen King", Genre = "Horror", Description = "A group of friends face an ancient evil in their town.", PageCount = 1138 },
new Book { Id = 69, Title = "Misery", Author = "Stephen King", Genre = "Thriller", Description = "An author is held captive by a deranged fan.", PageCount = 320 },
new Book { Id = 70, Title = "The Stand", Author = "Stephen King", Genre = "Post-Apocalyptic", Description = "A deadly plague leads to a battle between good and evil.", PageCount = 1153 },
new Book { Id = 71, Title = "Pet Sematary", Author = "Stephen King", Genre = "Horror", Description = "A burial ground with the power to resurrect the dead.", PageCount = 374 },
new Book { Id = 72, Title = "Carrie", Author = "Stephen King", Genre = "Horror", Description = "A bullied girl develops terrifying powers.", PageCount = 199 },
new Book { Id = 73, Title = "The Martian", Author = "Andy Weir", Genre = "Science Fiction", Description = "An astronaut stranded on Mars must survive against all odds.", PageCount = 369 },
new Book { Id = 74, Title = "Project Hail Mary", Author = "Andy Weir", Genre = "Science Fiction", Description = "A lone astronaut's mission to save humanity.", PageCount = 496 },
new Book { Id = 75, Title = "Artemis", Author = "Andy Weir", Genre = "Science Fiction", Description = "A heist on the Moon goes wrong.", PageCount = 305 },
new Book { Id = 76, Title = "Dune", Author = "Frank Herbert", Genre = "Science Fiction", Description = "The epic saga of politics, prophecy, and sandworms.", PageCount = 688 },
new Book { Id = 77, Title = "Dune Messiah", Author = "Frank Herbert", Genre = "Science Fiction", Description = "The sequel to Dune, exploring Paul Atreides' reign.", PageCount = 336 },
new Book { Id = 78, Title = "Children of Dune", Author = "Frank Herbert", Genre = "Science Fiction", Description = "The struggle for control of Arrakis continues.", PageCount = 408 },
new Book { Id = 79, Title = "God Emperor of Dune", Author = "Frank Herbert", Genre = "Science Fiction", Description = "A millennia-spanning tale of transformation and tyranny.", PageCount = 496 },
new Book { Id = 80, Title = "Heretics of Dune", Author = "Frank Herbert", Genre = "Science Fiction", Description = "Political intrigue and rebellion on Arrakis.", PageCount = 480 },
new Book { Id = 81, Title = "Chapterhouse: Dune", Author = "Frank Herbert", Genre = "Science Fiction", Description = "The Bene Gesserit's fight for survival.", PageCount = 464 },
new Book { Id = 82, Title = "Neuromancer", Author = "William Gibson", Genre = "Cyberpunk", Description = "A washed-up hacker hired for a final job.", PageCount = 271 },
new Book { Id = 83, Title = "Count Zero", Author = "William Gibson", Genre = "Cyberpunk", Description = "Corporate intrigue and cyberspace adventures.", PageCount = 246 },
new Book { Id = 84, Title = "Mona Lisa Overdrive", Author = "William Gibson", Genre = "Cyberpunk", Description = "The conclusion to Gibson's Sprawl trilogy.", PageCount = 288 },
new Book { Id = 85, Title = "Snow Crash", Author = "Neal Stephenson", Genre = "Cyberpunk", Description = "A pizza delivery man/hacker uncovers a deadly virus.", PageCount = 440 },
new Book { Id = 86, Title = "Cryptonomicon", Author = "Neal Stephenson", Genre = "Historical Fiction", Description = "A complex tale of codebreakers and treasure hunters.", PageCount = 918 },
new Book { Id = 87, Title = "Seveneves", Author = "Neal Stephenson", Genre = "Science Fiction", Description = "Humanity fights to survive after the moon shatters.", PageCount = 880 },
new Book { Id = 88, Title = "Anathem", Author = "Neal Stephenson", Genre = "Science Fiction", Description = "A monk-like scholar is thrust into a cosmic mystery.", PageCount = 935 },
new Book { Id = 89, Title = "The Left Hand of Darkness", Author = "Ursula K. Le Guin", Genre = "Science Fiction", Description = "A diplomat's mission to a world with ambisexual inhabitants.", PageCount = 304 },
new Book { Id = 90, Title = "A Wizard of Earthsea", Author = "Ursula K. Le Guin", Genre = "Fantasy", Description = "A young wizard's journey of self-discovery.", PageCount = 183 },
new Book { Id = 91, Title = "The Tombs of Atuan", Author = "Ursula K. Le Guin", Genre = "Fantasy", Description = "A priestess meets the wizard Ged in an ancient tomb.", PageCount = 180 },
new Book { Id = 92, Title = "The Farthest Shore", Author = "Ursula K. Le Guin", Genre = "Fantasy", Description = "Ged and a prince confront a threat to magic itself.", PageCount = 246 },
new Book { Id = 93, Title = "Tehanu", Author = "Ursula K. Le Guin", Genre = "Fantasy", Description = "A quiet but powerful continuation of Earthsea's story.", PageCount = 256 },
new Book { Id = 94, Title = "The Dispossessed", Author = "Ursula K. Le Guin", Genre = "Science Fiction", Description = "A physicist bridges two very different worlds.", PageCount = 387 },
new Book { Id = 95, Title = "Foundation", Author = "Isaac Asimov", Genre = "Science Fiction", Description = "A mathematician predicts the fall of a galactic empire.", PageCount = 255 },
new Book { Id = 96, Title = "Foundation and Empire", Author = "Isaac Asimov", Genre = "Science Fiction", Description = "The Foundation faces new challenges as it grows.", PageCount = 282 },
new Book { Id = 97, Title = "Second Foundation", Author = "Isaac Asimov", Genre = "Science Fiction", Description = "The search for the mysterious Second Foundation.", PageCount = 240 },
new Book { Id = 98, Title = "I, Robot", Author = "Isaac Asimov", Genre = "Science Fiction", Description = "A collection of short stories exploring robotics.", PageCount = 253 },
new Book { Id = 99, Title = "The Caves of Steel", Author = "Isaac Asimov", Genre = "Science Fiction", Description = "A detective and his robot partner investigate a murder.", PageCount = 270 },
new Book { Id = 100, Title = "The Naked Sun", Author = "Isaac Asimov", Genre = "Science Fiction", Description = "A detective investigates a murder on a distant world.", PageCount = 288 }

            );




            //not added: 

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 2, UserId = 2, BookId = 3, Rating = 4, ReviewText = "A delightful read!", Date = new DateTime(2025, 7, 9) },
                new Review { Id = 3, UserId = 3, BookId = 4, Rating = 5, ReviewText = "A powerful story about justice.", Date = new DateTime(2025, 7, 10) }
            );
            modelBuilder.Entity<ReadingStat>().HasData(
                new ReadingStat { Id = 2, UserId = 2, Year = 2025, BooksRead = 1, PagesRead = 279 },
                new ReadingStat { Id = 3, UserId = 3, Year = 2025, BooksRead = 1, PagesRead = 324 }
            );


        }
    }
}
