using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumb { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
