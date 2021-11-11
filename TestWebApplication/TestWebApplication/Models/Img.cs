using System.Collections.Generic;

namespace TestWebApplication.Models
{
    public class Img
    {
        public Img() { }

        public int ImgsId { get; set; }

        public byte[] ImageData { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
