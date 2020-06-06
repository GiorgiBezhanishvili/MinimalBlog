using DAL.Context;
using DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories
{
    public class UserRepositry : BaseRepository<User>, IUserRepositry
    {
        public UserRepositry(MinimalBlogDBContext context) : base(context)
        {
        }

        public User GetUserById(string id)
        {
            return Context.User.Find(id);
        }

        public string GetUserFullName(string id)
        {
            var firstName = Context.User.Find(id).FirstName;
            var lastName = Context.User.Find(id).LastName;

            return (firstName + " " + lastName);
        }
    }
}
