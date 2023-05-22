using Microsoft.EntityFrameworkCore;
using ryada.Models;

namespace ryada.Services
{
    public class SearchService
    {
        private readonly AppDBContext _dbContext;
        public SearchService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Book>> SearchAsync(string word)
        {
            var expensis = await _dbContext.Books
               .Where(p => p.Category.Name.Contains(word)).ToListAsync();

            return expensis;
        }
    }
}
