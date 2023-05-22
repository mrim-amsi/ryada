using Microsoft.AspNetCore.Mvc.Rendering;

namespace ryada.Models
{
    public class OrderDTO
    {
        public string InsertById { get; set; }
        public int BookId { get; set; }
        public Book Post { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public IEnumerable<SelectListItem> Books { get; set; }
    }
}
