namespace ryada.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public Double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string? InsertById { get; set; }
    }
}
