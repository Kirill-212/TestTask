using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWebApplication.Repositories
{
    public interface IAsyncRepository<T>
    {
        Task Create(T item);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> GetAll();

        Task Remove(T item);

        Task Update(T item);
    }
}
