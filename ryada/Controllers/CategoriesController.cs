using Microsoft.AspNetCore.Mvc;
using ryada.Models;
using Microsoft.EntityFrameworkCore;

namespace ryada.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoriesController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Category> categories =
                _context.Categories.ToList();

            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {

            CategoryDTO categoryDTO = new CategoryDTO();


            return View(categoryDTO);
        }
        [HttpPost]
        public IActionResult Add(CategoryDTO category)
        {
            var categoryAdded = new Category
            {
                Name = category.Name,
                InsertById= "cc9c29e3-87b0-4dc2-80d0-bcf1cef9f5d5",
            };
            _context.Categories.Add(categoryAdded);

            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Remove(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            List<Book> restaurants = _context.Books.Where(x=> x.CategoryId==id).ToList();

            if (restaurants.Count>0)
            {
                TempData["Message"] = "لا يمكن حدف لانه مرتبط بجداول اخرى ";
                TempData["stats"] = "danger";

            }
            else
            {
                TempData["Message"] = "تم الحدف بنجاح";
                TempData["stats"] = "success";
                _context.Categories.Remove(categories);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));

        }
    }
}
