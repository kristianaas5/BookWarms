namespace BookWarms.Models
{

    public enum ShelfType
    {
        Want,
        Reading,
        Read
    }

    public class Shelf
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public ShelfType ShelfType { get; set; }
    }

}
