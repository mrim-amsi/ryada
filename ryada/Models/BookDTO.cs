using Microsoft.AspNetCore.Mvc.Rendering;
using ryada.Models;

namespace ryada
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public Double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string? InsertById { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }

    }
}
