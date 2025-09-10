namespace BookWarms.Models
{
    public sealed class UserReadingStats
    {
        public List<YearlyStat> Yearly { get; set; } = new();
        public List<GenreStat> TopGenres { get; set; } = new();
    }

    public sealed class YearlyStat
    {
        public int Year { get; set; }
        public int BooksRead { get; set; }
        public int PagesRead { get; set; }
    }

    public sealed class GenreStat
    {
        public string Genre { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}