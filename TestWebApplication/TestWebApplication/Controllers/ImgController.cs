using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApplication.Dto;
using TestWebApplication.Models;
using TestWebApplication.Services;

namespace TestWebApplication.Controllers
{
    public class ImgController : Controller
    {
        private readonly IAsyncImgService<Img> asyncImgService;

        public ImgController(IAsyncImgService<Img> AsyncImgService)
        {
            asyncImgService = AsyncImgService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImgs(int page = 1)
        {
            return View("ViewAllImg", await asyncImgService.GetAll(page));
        }

        [HttpGet]
        public async Task<IEnumerable<int>> GetAllID()
        {
            return await asyncImgService.GetAllId();
        }

        public async Task<IActionResult> GetImage(int id)
        {
            return File(await asyncImgService.GetImage(id), "image/png");
        }

        [HttpPost("PostImg")]
        public async Task<IActionResult> PostImg([FromForm] PostImgDto postImgDto)
        {
            await asyncImgService.Create(postImgDto);
            return RedirectToAction("GetAllImgs");
        }

        [HttpPost("PutImg")]
        public async Task<IActionResult> PutImg([FromForm] PutImgDto putImgDto)
        {
            await asyncImgService.Update(putImgDto);
            return RedirectToAction("GetAllImgs");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await asyncImgService.Remove(id);
            return RedirectToAction("GetAllImgs");
        }

        public async Task<IActionResult> DeleteArrayItems([FromBody] DeleteArrayImgsDto items)
        {
            await asyncImgService.RemoveRange(items.Items);
            return RedirectToAction("GetAllImgs");
        }

        [HttpPost("PostExport")]
        public async Task<FileResult> PostExport()
        {
            return File(await asyncImgService.Export(), "application/json", "imgs.json");
        }

        [HttpPost("PostImport")]
        public async Task<IActionResult> PostImport([FromForm] IFormFile file)
        {
            await asyncImgService.Import(file);
            return RedirectToAction("GetAllImgs");
        }

    }
}
