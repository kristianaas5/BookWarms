namespace BookWarms.Models
{
    public class ReadingStat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public int BooksRead { get; set; }
        public int PagesRead { get; set; }
    }
}
