using DAL.Context;
using DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class PostRepositry : BaseRepository<Post>, IPostRepositry
    {
        public PostRepositry(MinimalBlogDBContext context) : base(context)
        {
        }
    }
}
