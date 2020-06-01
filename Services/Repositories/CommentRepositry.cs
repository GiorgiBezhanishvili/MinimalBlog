using DAL.Context;
using DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class CommentRepositry : BaseRepository<Comment>, ICommentRepositry
    {
        public CommentRepositry(MinimalBlogDBContext context) : base(context)
        {
        }
    }
}
