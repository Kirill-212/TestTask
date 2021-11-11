using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Dto
{
    public class DeleteArrayImgsDto
    {
        [Required]
        public int[] Items { get; set; }
    }
}
