using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Dto
{
    public class PutImgDto
    {
        [Required]
        public int ImgsId { get; set; }

        [Required]
        public IFormFile ImageData { get; set; }
    }
}
