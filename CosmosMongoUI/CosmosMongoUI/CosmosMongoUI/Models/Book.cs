﻿namespace CosmosMongoUI.Models
{
    public class Book
    {
        public string? Id { get; set; }
      
        public string BookName { get; set; } = null!;
        // </snippet_BookName>

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}
