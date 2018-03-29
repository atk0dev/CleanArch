using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail
{
    public interface IGetCompoundEntityDetailQuery
    {
        CompoundEntityDetailModel Execute(int id);
    }
}