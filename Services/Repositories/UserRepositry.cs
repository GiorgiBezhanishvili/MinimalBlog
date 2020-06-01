using DAL.Context;
using DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class UserRepositry : BaseRepository<User>, IUserRepositry
    {
        public UserRepositry(MinimalBlogDBContext context) : base(context)
        {
        }
    }
}
