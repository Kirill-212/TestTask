using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Dto
{
    public class PostCommentDto
    {
        [Required]
        [MaxLength(length: 10, ErrorMessage = "Max length Title is 10 symbols")]
        [MinLength(length: 2, ErrorMessage = "Min length Title is 2 symbols")]
        public string Title { get; set; }

        [Required]
        [MaxLength(length: 100, ErrorMessage = "Max length Title is 10 symbols")]
        [MinLength(length: 1, ErrorMessage = "Min length Title is 1 symbols")]
        public string Description { get; set; }

        [Required]
        public int ImgsId { get; set; }
    }
}
