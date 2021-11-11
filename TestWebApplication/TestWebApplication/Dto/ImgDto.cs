using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Dto
{
    public class ImgDto
    {
        [Required]
        public byte[] ImageData { get; set; }
    }
}
