using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApplication.Dto;
using TestWebApplication.Models;

namespace TestWebApplication.Services
{
    public interface IAsyncImgService<T>
    {
        Task Create(PostImgDto item);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<int>> GetAllId();

        Task<IndexViewModel<T>> GetAll(int page);

        Task Remove(int id);

        Task Update(PutImgDto item);

        Task<byte[]> GetImage(int id);

        Task Import(IFormFile item);

        Task<byte[]> Export();

        Task RemoveRange(int[] items);
    }
}
