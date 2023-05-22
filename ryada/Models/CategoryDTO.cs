using Microsoft.AspNetCore.Mvc.Rendering;
using ryada.Models;

namespace ryada
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public string InsertById { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.Now;

    }
}
