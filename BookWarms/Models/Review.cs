namespace BookWarms.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
        public Library Library { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

}
