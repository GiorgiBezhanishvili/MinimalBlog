using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepositry Post { get; }
        IUserRepositry User { get; }
        void Commit();
    }
}
