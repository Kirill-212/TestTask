using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Dto;
using TestWebApplication.Models;
using TestWebApplication.Repositories;

namespace TestWebApplication.Services
{
    public class AsyncCommentService : IAsyncCommentService<Comment>
    {
        private readonly int pageSize = 5;
        private readonly IAsyncRepositoryComment<Comment> asyncCommentRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncImgService<Img> asyncImgService;

        public AsyncCommentService(IAsyncRepositoryComment<Comment> asyncCommentRepository, IMapper mapper, IAsyncImgService<Img> asyncImgService)
        {
            this.asyncImgService = asyncImgService;
            _mapper = mapper;
            this.asyncCommentRepository = asyncCommentRepository;
        }

        public async Task Create(PostCommentDto item)
        {
            Comment comment = _mapper.Map<Comment>(item);
            comment.Img = await asyncImgService.FindById(item.ImgsId);
            await asyncCommentRepository.Create(comment);
        }

        public async Task<Comment> FindById(int id)
        {
            Comment comment = await asyncCommentRepository.FindById(id);
            if (comment != null) return comment;
            throw new Exception("Id comment is not valid");
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await asyncCommentRepository.GetAll();
        }

        public async Task<IndexViewModel<Comment>> GetAll(int page)
        {
            IEnumerable<Comment> source = await asyncCommentRepository.GetAll();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new(count, page, pageSize);
            return new()
            {
                PageViewModel = pageViewModel,
                Items = items
            };
        }

        public async Task Remove(int id)
        {
            Comment remove_comment = await FindById(id);
            if (remove_comment == null) throw new Exception("Id comment is not valid");
            await asyncCommentRepository.Remove(remove_comment);
        }

        public async Task<IndexViewModel<Comment>> SearchComment(int page, string serachParam)
        {
            IEnumerable<Comment> source = await asyncCommentRepository.SearchComment(serachParam);
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new(count, page, pageSize);
            return new()
            {
                PageViewModel = pageViewModel,
                Items = items
            };
        }

        public async Task Update(PutCommentDto item)
        {
            Comment comment = _mapper.Map<Comment>(item);
            comment.Img = await asyncImgService.FindById(item.ImgsId);
            await asyncCommentRepository.Update(comment);
        }
    }
}
