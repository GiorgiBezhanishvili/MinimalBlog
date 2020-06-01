using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUnitOfWork : IDisposable
    {

        void Commit();
    }
}
