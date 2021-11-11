using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApplication.Dto;
using TestWebApplication.Models;

namespace TestWebApplication.Services
{
    public interface IAsyncCommentService<T>
    {
        Task Create(PostCommentDto item);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IndexViewModel<T>> GetAll(int page);

        Task Remove(int id);

        Task Update(PutCommentDto item);

        Task<IndexViewModel<T>> SearchComment(int page, string serachParam);
    }
}
