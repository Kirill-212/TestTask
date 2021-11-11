using System.Collections.Generic;

namespace TestWebApplication.Models
{
    public class IndexViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
