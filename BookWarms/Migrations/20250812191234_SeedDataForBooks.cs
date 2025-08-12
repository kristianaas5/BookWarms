using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWarms.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "PageCount", "Title" },
                values: new object[,]
                {
                    { 3, "Jane Austen", "A witty exploration of manners, morality, and love.", "Romance", 279, "Pride and Prejudice" },
                    { 4, "Harper Lee", "A young girl's perspective on racial injustice in the Deep South.", "Classic", 324, "To Kill a Mockingbird" },
                    { 5, "Herman Melville", "The obsessive quest for revenge against the white whale.", "Adventure", 635, "Moby Dick" },
                    { 6, "Leo Tolstoy", "A sweeping narrative of love and conflict during Napoleon's invasion of Russia.", "Historical", 1225, "War and Peace" },
                    { 7, "J.R.R. Tolkien", "Bilbo Baggins' journey to help dwarves reclaim their homeland.", "Fantasy", 310, "The Hobbit" },
                    { 8, "J.R.R. Tolkien", "The first part of the epic quest to destroy the One Ring.", "Fantasy", 423, "The Fellowship of the Ring" },
                    { 9, "J.R.R. Tolkien", "The fellowship is broken, and the war for Middle-earth begins.", "Fantasy", 352, "The Two Towers" },
                    { 10, "J.R.R. Tolkien", "The final battle for Middle-earth.", "Fantasy", 416, "The Return of the King" },
                    { 11, "J.K. Rowling", "A boy discovers he is a wizard and attends Hogwarts.", "Fantasy", 309, "Harry Potter and the Sorcerer's Stone" },
                    { 12, "J.K. Rowling", "A mysterious chamber holds a deadly secret.", "Fantasy", 341, "Harry Potter and the Chamber of Secrets" },
                    { 13, "J.K. Rowling", "A dangerous prisoner escapes from Azkaban.", "Fantasy", 435, "Harry Potter and the Prisoner of Azkaban" },
                    { 14, "J.K. Rowling", "The Triwizard Tournament brings new dangers.", "Fantasy", 734, "Harry Potter and the Goblet of Fire" },
                    { 15, "J.K. Rowling", "Dark forces rise, and Dumbledore's Army is formed.", "Fantasy", 870, "Harry Potter and the Order of the Phoenix" },
                    { 16, "J.K. Rowling", "Secrets of Voldemort's past come to light.", "Fantasy", 652, "Harry Potter and the Half-Blood Prince" },
                    { 17, "J.K. Rowling", "The final battle between Harry and Voldemort.", "Fantasy", 759, "Harry Potter and the Deathly Hallows" },
                    { 18, "J.D. Salinger", "Holden Caulfield's story of teenage rebellion.", "Classic", 277, "The Catcher in the Rye" },
                    { 19, "Paulo Coelho", "A shepherd's journey to find his personal legend.", "Fiction", 208, "The Alchemist" },
                    { 20, "Aldous Huxley", "A futuristic world shaped by genetic engineering.", "Dystopian", 288, "Brave New World" },
                    { 21, "Fyodor Dostoevsky", "A psychological exploration of morality and guilt.", "Classic", 671, "Crime and Punishment" },
                    { 22, "Leo Tolstoy", "A tragic love affair in 19th century Russia.", "Romance", 864, "Anna Karenina" },
                    { 23, "Fyodor Dostoevsky", "A profound exploration of faith, doubt, and morality.", "Philosophical", 796, "The Brothers Karamazov" },
                    { 24, "Victor Hugo", "A sweeping story of redemption and revolution in France.", "Historical", 1232, "Les Misérables" },
                    { 25, "Alexandre Dumas", "A tale of betrayal, revenge, and justice.", "Adventure", 1276, "The Count of Monte Cristo" },
                    { 26, "Bram Stoker", "The iconic vampire story.", "Horror", 418, "Dracula" },
                    { 27, "Mary Shelley", "A scientist creates life with tragic consequences.", "Horror", 280, "Frankenstein" },
                    { 28, "Charlotte Brontë", "A governess's journey to love and independence.", "Classic", 532, "Jane Eyre" },
                    { 29, "Emily Brontë", "A dark tale of passion and revenge on the Yorkshire moors.", "Classic", 416, "Wuthering Heights" },
                    { 30, "Oscar Wilde", "A man remains young while his portrait ages.", "Philosophical", 254, "The Picture of Dorian Gray" },
                    { 31, "Charles Dickens", "A story of love and sacrifice set during the French Revolution.", "Historical", 489, "A Tale of Two Cities" },
                    { 32, "Charles Dickens", "The journey of an orphan named Pip towards self-discovery.", "Classic", 505, "Great Expectations" },
                    { 33, "Charles Dickens", "A semi-autobiographical tale of growth and perseverance.", "Classic", 882, "David Copperfield" },
                    { 34, "Charles Dickens", "The hardships of an orphan in Victorian London.", "Classic", 554, "Oliver Twist" },
                    { 35, "Ernest Hemingway", "An aging fisherman's struggle with a giant marlin.", "Fiction", 127, "The Old Man and the Sea" },
                    { 36, "Ernest Hemingway", "A tale of love and sacrifice during the Spanish Civil War.", "Historical", 480, "For Whom the Bell Tolls" },
                    { 37, "Ernest Hemingway", "A tragic romance set in World War I.", "Romance", 332, "A Farewell to Arms" },
                    { 38, "Ernest Hemingway", "A group of expatriates in post-war Europe.", "Fiction", 251, "The Sun Also Rises" },
                    { 39, "Joseph Heller", "The absurdities of war through the eyes of a bomber pilot.", "Satire", 453, "Catch-22" },
                    { 40, "Kurt Vonnegut", "A soldier's journey through time and space after WWII.", "Science Fiction", 275, "Slaughterhouse-Five" },
                    { 41, "John Steinbeck", "A family's migration during the Great Depression.", "Historical", 464, "The Grapes of Wrath" },
                    { 42, "John Steinbeck", "The tragic story of two migrant workers during the Depression.", "Classic", 187, "Of Mice and Men" },
                    { 43, "John Steinbeck", "A multigenerational story of love, jealousy, and betrayal.", "Fiction", 601, "East of Eden" },
                    { 44, "John Steinbeck", "A slice of life in a small California community.", "Fiction", 208, "Cannery Row" },
                    { 45, "Miguel de Cervantes", "The adventures of a delusional knight and his loyal squire.", "Classic", 982, "Don Quixote" },
                    { 46, "Dante Alighieri", "A journey through Hell, Purgatory, and Paradise.", "Epic Poetry", 798, "The Divine Comedy" },
                    { 47, "Homer", "Odysseus' long journey home from the Trojan War.", "Epic Poetry", 541, "The Odyssey" },
                    { 48, "Homer", "The final weeks of the Trojan War.", "Epic Poetry", 683, "The Iliad" },
                    { 49, "Marcus Aurelius", "The Stoic reflections of a Roman emperor.", "Philosophy", 254, "Meditations" },
                    { 50, "Niccolò Machiavelli", "A treatise on political power and leadership.", "Political", 140, "The Prince" },
                    { 51, "Friedrich Nietzsche", "A philosophical novel introducing the idea of the Übermensch.", "Philosophy", 327, "Thus Spoke Zarathustra" },
                    { 52, "Friedrich Nietzsche", "A critique of traditional morality.", "Philosophy", 240, "Beyond Good and Evil" },
                    { 53, "Sun Tzu", "Ancient Chinese military strategy and tactics.", "Strategy", 273, "The Art of War" },
                    { 54, "Charles Darwin", "The foundation of evolutionary biology.", "Science", 502, "On the Origin of Species" },
                    { 55, "Rachel Carson", "An environmental science book that sparked change.", "Science", 378, "Silent Spring" },
                    { 56, "Stephen Hawking", "An exploration of cosmology and black holes.", "Science", 212, "A Brief History of Time" },
                    { 57, "Richard Dawkins", "An influential work on evolutionary biology.", "Science", 360, "The Selfish Gene" },
                    { 58, "Yuval Noah Harari", "A sweeping history of humanity from ancient times to today.", "History", 443, "Sapiens: A Brief History of Humankind" },
                    { 59, "Yuval Noah Harari", "Speculations about the future of humanity.", "History", 450, "Homo Deus: A Brief History of Tomorrow" },
                    { 60, "Yuval Noah Harari", "Insights into the modern challenges of our world.", "Nonfiction", 372, "21 Lessons for the 21st Century" },
                    { 61, "Daniel Kahneman", "An analysis of the two systems that drive our thinking.", "Psychology", 499, "Thinking, Fast and Slow" },
                    { 62, "Viktor E. Frankl", "A Holocaust survivor's reflections on purpose and resilience.", "Psychology", 200, "Man's Search for Meaning" },
                    { 63, "Cormac McCarthy", "A father and son's journey in a desolate world.", "Post-Apocalyptic", 287, "The Road" },
                    { 64, "Cormac McCarthy", "A violent tale set in the 19th-century American West.", "Western", 351, "Blood Meridian" },
                    { 65, "Cormac McCarthy", "A brutal chase after stolen drug money.", "Thriller", 309, "No Country for Old Men" },
                    { 66, "Cormac McCarthy", "A young cowboy's journey into Mexico.", "Western", 302, "All the Pretty Horses" },
                    { 67, "Stephen King", "A haunted hotel turns a man into a danger to his family.", "Horror", 447, "The Shining" },
                    { 68, "Stephen King", "A group of friends face an ancient evil in their town.", "Horror", 1138, "It" },
                    { 69, "Stephen King", "An author is held captive by a deranged fan.", "Thriller", 320, "Misery" },
                    { 70, "Stephen King", "A deadly plague leads to a battle between good and evil.", "Post-Apocalyptic", 1153, "The Stand" },
                    { 71, "Stephen King", "A burial ground with the power to resurrect the dead.", "Horror", 374, "Pet Sematary" },
                    { 72, "Stephen King", "A bullied girl develops terrifying powers.", "Horror", 199, "Carrie" },
                    { 73, "Andy Weir", "An astronaut stranded on Mars must survive against all odds.", "Science Fiction", 369, "The Martian" },
                    { 74, "Andy Weir", "A lone astronaut's mission to save humanity.", "Science Fiction", 496, "Project Hail Mary" },
                    { 75, "Andy Weir", "A heist on the Moon goes wrong.", "Science Fiction", 305, "Artemis" },
                    { 76, "Frank Herbert", "The epic saga of politics, prophecy, and sandworms.", "Science Fiction", 688, "Dune" },
                    { 77, "Frank Herbert", "The sequel to Dune, exploring Paul Atreides' reign.", "Science Fiction", 336, "Dune Messiah" },
                    { 78, "Frank Herbert", "The struggle for control of Arrakis continues.", "Science Fiction", 408, "Children of Dune" },
                    { 79, "Frank Herbert", "A millennia-spanning tale of transformation and tyranny.", "Science Fiction", 496, "God Emperor of Dune" },
                    { 80, "Frank Herbert", "Political intrigue and rebellion on Arrakis.", "Science Fiction", 480, "Heretics of Dune" },
                    { 81, "Frank Herbert", "The Bene Gesserit's fight for survival.", "Science Fiction", 464, "Chapterhouse: Dune" },
                    { 82, "William Gibson", "A washed-up hacker hired for a final job.", "Cyberpunk", 271, "Neuromancer" },
                    { 83, "William Gibson", "Corporate intrigue and cyberspace adventures.", "Cyberpunk", 246, "Count Zero" },
                    { 84, "William Gibson", "The conclusion to Gibson's Sprawl trilogy.", "Cyberpunk", 288, "Mona Lisa Overdrive" },
                    { 85, "Neal Stephenson", "A pizza delivery man/hacker uncovers a deadly virus.", "Cyberpunk", 440, "Snow Crash" },
                    { 86, "Neal Stephenson", "A complex tale of codebreakers and treasure hunters.", "Historical Fiction", 918, "Cryptonomicon" },
                    { 87, "Neal Stephenson", "Humanity fights to survive after the moon shatters.", "Science Fiction", 880, "Seveneves" },
                    { 88, "Neal Stephenson", "A monk-like scholar is thrust into a cosmic mystery.", "Science Fiction", 935, "Anathem" },
                    { 89, "Ursula K. Le Guin", "A diplomat's mission to a world with ambisexual inhabitants.", "Science Fiction", 304, "The Left Hand of Darkness" },
                    { 90, "Ursula K. Le Guin", "A young wizard's journey of self-discovery.", "Fantasy", 183, "A Wizard of Earthsea" },
                    { 91, "Ursula K. Le Guin", "A priestess meets the wizard Ged in an ancient tomb.", "Fantasy", 180, "The Tombs of Atuan" },
                    { 92, "Ursula K. Le Guin", "Ged and a prince confront a threat to magic itself.", "Fantasy", 246, "The Farthest Shore" },
                    { 93, "Ursula K. Le Guin", "A quiet but powerful continuation of Earthsea's story.", "Fantasy", 256, "Tehanu" },
                    { 94, "Ursula K. Le Guin", "A physicist bridges two very different worlds.", "Science Fiction", 387, "The Dispossessed" },
                    { 95, "Isaac Asimov", "A mathematician predicts the fall of a galactic empire.", "Science Fiction", 255, "Foundation" },
                    { 96, "Isaac Asimov", "The Foundation faces new challenges as it grows.", "Science Fiction", 282, "Foundation and Empire" },
                    { 97, "Isaac Asimov", "The search for the mysterious Second Foundation.", "Science Fiction", 240, "Second Foundation" },
                    { 98, "Isaac Asimov", "A collection of short stories exploring robotics.", "Science Fiction", 253, "I, Robot" },
                    { 99, "Isaac Asimov", "A detective and his robot partner investigate a murder.", "Science Fiction", 270, "The Caves of Steel" },
                    { 100, "Isaac Asimov", "A detective investigates a murder on a distant world.", "Science Fiction", 288, "The Naked Sun" }
                });

            migrationBuilder.InsertData(
                table: "ReadingStats",
                columns: new[] { "Id", "BooksRead", "PagesRead", "UserId", "Year" },
                values: new object[,]
                {
                    { 2, 1, 279, 2, 2025 },
                    { 3, 1, 324, 3, 2025 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Date", "Rating", "ReviewText", "UserId" },
                values: new object[,]
                {
                    { 2, 3, new DateTime(2025, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "A delightful read!", 2 },
                    { 3, 4, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "A powerful story about justice.", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ReadingStats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReadingStats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
