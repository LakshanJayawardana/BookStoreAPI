using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookDetailsContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(BookDetailsContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public Task<T> DeleteBookDetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetBookDetail(int id)
        {
            throw new NotImplementedException();
        }

        /*public Task<IEnumerable<T>> GetBookDetails()
        {
            return _context.BookDetails.ToList();
        }*/

        public Task<T> PostBookDetail(T bookDetail)
        {
            throw new NotImplementedException();
        }

        public Task<T> PutBookDetail(int id, T bookDetail)
        {
            throw new NotImplementedException();
        }
    }
}
