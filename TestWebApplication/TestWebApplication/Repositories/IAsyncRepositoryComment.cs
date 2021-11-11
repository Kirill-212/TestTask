using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWebApplication.Repositories
{
    public interface IAsyncRepositoryComment<T> : IAsyncRepository<T>
    {
        Task<IEnumerable<T>> SearchComment(string searchParam);
    }
}
