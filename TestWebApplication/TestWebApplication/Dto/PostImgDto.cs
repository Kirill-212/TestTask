using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Dto
{
    public class PostImgDto
    {
        [Required]
        public IFormFile ImageData { get; set; }
    }
}
