using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestWebApplication.Dto;
using TestWebApplication.Models;
using TestWebApplication.Repositories;

namespace TestWebApplication.Services
{
    public class AsyncImgService : IAsyncImgService<Img>
    {
        private readonly int pageSize = 5;
        private readonly IAsyncRepositoryImg<Img> asyncImgRepository;
        private readonly IMapper _mapper;
        public AsyncImgService(IAsyncRepositoryImg<Img> imgRepository, IMapper mapper)
        {
            _mapper = mapper;
            asyncImgRepository = imgRepository;
        }

        public async Task Create(PostImgDto item)
        {
            Img img = new();
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(item.ImageData.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)item.ImageData.Length);
            }
            img.ImageData = imageData;
            await asyncImgRepository.Create(img);
        }

        public async Task<byte[]> Export()
        {
            List<ImgDto> imgs = _mapper.Map<List<ImgDto>>(
                (await asyncImgRepository.GetAll()).ToList());
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(imgs));
        }

        public async Task<Img> FindById(int id)
        {
            return await asyncImgRepository.FindById(id);
        }

        public async Task<IndexViewModel<Img>> GetAll(int page)
        {

            IEnumerable<Img> source = await asyncImgRepository.GetAll();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new(count, page, pageSize);

            return new()
            {
                PageViewModel = pageViewModel,
                Items = items
            };
        }
        public async Task<IEnumerable<Img>> GetAll()
        {
            return await asyncImgRepository.GetAll();
        }

        public async Task<IEnumerable<int>> GetAllId()
        {
            return (await asyncImgRepository.GetAll()).Select(u => u.ImgsId);
        }

        public async Task<byte[]> GetImage(int id)
        {
            Img img = await asyncImgRepository.FindById(id);
            if (img!=null) return img.ImageData;
            throw new Exception("Id img is not valid");
        }

        public async Task Import(IFormFile item)
        {
            byte[] Data = null;
            using (var binaryReader = new BinaryReader(item.OpenReadStream()))
            {
                Data = binaryReader.ReadBytes((int)item.Length);
            }
            List<Img> imgs = _mapper.Map<List<Img>>(
                JsonSerializer.Deserialize<List<Img>>(Encoding.UTF8.GetString(Data)));
            await asyncImgRepository.AddRange(imgs);
        }

        public async Task Remove(int id)
        {
            Img remove_imgs = await FindById(id);
            if(remove_imgs==null) throw new Exception("Id img is not valid");
            await asyncImgRepository.Remove(remove_imgs);       
        }

        public async Task RemoveRange(int[] items)
        {

            await asyncImgRepository.RemoveRange(
                await asyncImgRepository.FindAllById(items));
        }

        public async Task Update(PutImgDto item)
        {
            Img img = new();
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(item.ImageData.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)item.ImageData.Length);
            }
            img.ImageData = imageData;
            img.ImgsId = item.ImgsId;
            await asyncImgRepository.Update(img);
        }
    }
}
