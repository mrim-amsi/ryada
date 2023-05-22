using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ryada.Models;

namespace ryada.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;



        public OrdersController(UserManager<IdentityUser> userManager, AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            List<order> posts = _context.orders.Include(x=> x.Post)
                .ToList();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Book> books = _context.Books.ToList();

            OrderDTO addOrder = new OrderDTO();
            addOrder.Books = new SelectList(books, "Id", "Title");
            return View(addOrder);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(order post)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            post.InsertById = userId;
            var book = await _context.Books.FindAsync(post.BookId);

            post.TotalPrice = (int)(post.Quantity* book.Price);
            _context.orders.Add(post);
            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            TempData["stats"] = "success";

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Remove(int id)
        {
            var order = await _context.orders.FindAsync(id);
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));        
        }

        public async Task<IActionResult> Edit(int id)
        {

            order addOrder = await _context.orders.SingleOrDefaultAsync(x => x.Id == id);
            List<Book> books = _context.Books.ToList();

            ViewBag.listBooks = new SelectList(books, "Id", "Title");

            return View(addOrder);
        }
        public async Task<IActionResult> EditSubmit(order myOrder, int id)
        {
            var Exsit = await _context.orders.SingleOrDefaultAsync(x => x.Id == id);
            Exsit.Quantity = myOrder.Quantity;
            Exsit.BookId = myOrder.BookId;
            _context.orders.Update(Exsit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            ;
        }
    }
}
