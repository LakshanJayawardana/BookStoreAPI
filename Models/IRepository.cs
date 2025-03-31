namespace BookStoreAPI.Models
{
    public interface IRepository<T> where T : class
    {
        //Task<IEnumerable<T>> GetBookDetails();
        Task<T> GetBookDetail(int id);
        Task<T> PutBookDetail(int id, T bookDetail);
        Task<T> PostBookDetail(T bookDetail);
        Task<T> DeleteBookDetail(int id);

    }
}
