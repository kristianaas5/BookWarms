namespace BookWarms.Models
{
    public enum ShelfType
    {
        WantToRead,
        CurrentlyReading,
        Read
    }

    public class Library
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int BookId { get; set; }

        public ShelfType ShelfType { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

