using Microsoft.EntityFrameworkCore;
using ryada.Models;

namespace ryada.Services
{
    public class BookService 
    {
        private readonly AppDBContext _context;

        public BookService(AppDBContext context)
        {
            _context = context;
        }


        public async Task<List<Book>> GetBooksAsync(string? search)
        {
            var query =  _context.Books.Include(n => n.Category).AsQueryable();
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Title.Contains(search));
            }

            return await query .ToListAsync();
        }
    }
}
