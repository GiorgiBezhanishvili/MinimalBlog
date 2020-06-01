using DAL.Context;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MinimalBlogDBContext _context;

        public UnitOfWork(MinimalBlogDBContext context)
        {
            _context = context;
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
