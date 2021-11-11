using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.ContextDB;
using TestWebApplication.Models;

namespace TestWebApplication.Repositories
{
    public class AsyncRepositoryImg : IAsyncRepositoryImg<Img>
    {
        private readonly ContextDb context;

        public AsyncRepositoryImg(ContextDb context)
        {
            this.context = context;
        }

        public async Task AddRange(List<Img> items)
        {
            await context.AddRangeAsync(items);
            await context.SaveChangesAsync();
        }

        public async Task Create(Img item)
        {
            await context.Imgs.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Img>> FindAllById(int[] items)
        {
            return await context.Imgs.Where(i => items.Contains(i.ImgsId)).ToListAsync();
        }

        public async Task<Img> FindById(int id)
        {
            return await context.Imgs.Where(u => u.ImgsId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Img>> GetAll()
        {
            return await context.Imgs.ToListAsync();
        }

        public async Task Remove(Img item)
        {
            context.Imgs.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<Img> items)
        {
            context.RemoveRange(items);
            await context.SaveChangesAsync();
        }

        public async Task Update(Img item)
        {
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
