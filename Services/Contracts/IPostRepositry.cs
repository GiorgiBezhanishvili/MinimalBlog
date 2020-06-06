using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IPostRepositry : IBaseRepository<Post>
    {
        public IEnumerable<Post> GetAllPostsByAuthorId(string authorId);
    }
}
