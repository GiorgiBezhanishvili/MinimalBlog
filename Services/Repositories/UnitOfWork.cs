using DAL.Context;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private MinimalBlogDBContext _context;
        private IPostRepositry _postRepositry;
        private IUserRepositry _userRepositry;

        public UnitOfWork(MinimalBlogDBContext context)
        {
            _context = context;
        }

        public IPostRepositry Post 
        {
            get 
            {
                if (_postRepositry == null)
                    _postRepositry = new PostRepositry(_context);
                return _postRepositry;
            }
        }

        public IUserRepositry User 
        {
            get 
            {
                if (_userRepositry == null)
                    _userRepositry = new UserRepositry(_context);
                return _userRepositry;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
