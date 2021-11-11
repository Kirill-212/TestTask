using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWebApplication.Dto;
using TestWebApplication.Models;
using TestWebApplication.Services;

namespace TestWebApplication.Controllers
{
    public class CommentController : Controller
    {
        private readonly IAsyncCommentService<Comment> asyncCommentService;

        public CommentController(IAsyncCommentService<Comment> AsyncCommentService)
        {
            asyncCommentService = AsyncCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments(int page = 1, string searchParam = "")
        {
            if (string.IsNullOrEmpty(searchParam))
            {
                return View("ViewAllComment", await asyncCommentService.GetAll(page));
            }
            else
            {
                return View("ViewAllComment", await asyncCommentService.SearchComment(page, searchParam));
            }

        }

        [HttpPost("PostComment")]
        public async Task<IActionResult> PostComment([FromForm] PostCommentDto postCommentsDto)
        {
            if (ModelState.IsValid)
            {
                await asyncCommentService.Create(postCommentsDto);
                return RedirectToAction("GetAllComments");
            }
            else
            {
                ViewBag.ModelState = ModelState;
                return View("ModelErrorPage");
            }
        }

        [HttpPost("PutComment")]
        public async Task<IActionResult> PutComment([FromForm] PutCommentDto putCommentsDto)
        {
            if (ModelState.IsValid)
            {
                await asyncCommentService.Update(putCommentsDto);
                return RedirectToAction("GetAllComments");
            }
            else
            {
                ViewBag.ModelState = ModelState;
                return View("ModelErrorPage");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            await asyncCommentService.Remove(id);
            return RedirectToAction("GetAllComments");
        }

    }
}
