using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
