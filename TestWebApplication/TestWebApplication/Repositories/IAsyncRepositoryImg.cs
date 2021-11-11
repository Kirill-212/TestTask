using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWebApplication.Repositories
{
    public interface IAsyncRepositoryImg<T> : IAsyncRepository<T>
    {
        Task AddRange(List<T> items);

        Task RemoveRange(IEnumerable<T> items);

        Task<IEnumerable<T>> FindAllById(int[] items);
    }
}
