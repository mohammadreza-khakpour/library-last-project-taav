using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Application
{
    public interface UnitOfWork
    {
        void Complete();
    }
}
