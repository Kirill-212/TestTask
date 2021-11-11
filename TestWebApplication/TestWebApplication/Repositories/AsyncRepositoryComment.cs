using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.ContextDB;
using TestWebApplication.Models;

namespace TestWebApplication.Repositories
{
    public class AsyncRepositoryComment : IAsyncRepositoryComment<Comment>
    {
        private readonly ContextDb context;

        public AsyncRepositoryComment(ContextDb context)
        {
            this.context = context;
        }

        public async Task Create(Comment item)
        {
            await context.Comments.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task<Comment> FindById(int id)
        {
            return await context.Comments.Where(u => u.CommentsId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await context.Comments.Include(u => u.Img).ToListAsync();
        }

        public async Task Remove(Comment item)
        {
            context.Comments.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> SearchComment(string searchParam)
        {
            return await context.Comments.Include(u => u.Img).Where(p => p.Title.Contains(searchParam)).ToListAsync();
        }

        public async Task Update(Comment item)
        {
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
