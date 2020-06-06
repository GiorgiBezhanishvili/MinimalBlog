using DAL.Context;
using DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories
{
    public class PostRepositry : BaseRepository<Post>, IPostRepositry
    {
        public PostRepositry(MinimalBlogDBContext context) : base(context)
        {
        }

        public IEnumerable<Post> GetAllPostsByAuthorId(string authorId)
        {
            var data = Context.Post.Where(a => a.AuthorId == authorId).AsEnumerable();
            return data;
        }
    }
}
