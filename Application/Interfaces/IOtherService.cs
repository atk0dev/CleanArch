using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IOtherService
    {
        void NotifyDataChanged(int id, decimal a);
    }
}
