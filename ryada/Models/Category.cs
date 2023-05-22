namespace ryada.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InsertById { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;

    }
}
