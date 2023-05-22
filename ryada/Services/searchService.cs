namespace ryada.Services
{
    public class SearchService
    {
        private readonly AppDBContext _dbContext;
        public SearchService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
