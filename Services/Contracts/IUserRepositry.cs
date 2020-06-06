using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUserRepositry : IBaseRepository<User>
    {
        public string GetUserFullName(string id);
        public User GetUserById(string id);
    }
}
