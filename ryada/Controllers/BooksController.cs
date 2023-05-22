using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ryada.Models;
using ryada.Services;

namespace ryada.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly BookService _bookService;
        private readonly UserManager<IdentityUser> _userManager;


        public BooksController(UserManager<IdentityUser> userManager,AppDBContext postDbContext,
            IWebHostEnvironment webHostEnvironment,BookService bookService)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
            _bookService = bookService;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index(string? search)
        {
         
            return View(await _bookService.GetBooksAsync(search ?? ""));
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categories = _context.Categories.ToList();

            BookDTO addPostVM = new BookDTO();
            addPostVM.categories = new SelectList(categories, "Id", "Name");


            return View(addPostVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(BookDTO post)
        {

            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var Added = new Book
                {
                Title = post.Title,
                CategoryId = post.CategoryId,
                Price = post.Price,
                Quantity = post.Quantity,
                Author = post.Author,
                InsertById = userId,

            };


            _context.Books.Add(Added);

            _context.SaveChanges();


            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Remove(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
