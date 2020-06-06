using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalBlog.ViewModels
{
    public class ReviewPostVM
    {
        public string Title { get; set; }
        public string ContentPrew { get; set; }
        public string Thumb { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string FullName { get; set; }
    }
}
