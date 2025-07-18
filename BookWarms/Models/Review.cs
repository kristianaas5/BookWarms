﻿namespace BookWarms.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
    }
}
