using System.Collections.Generic;

namespace CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList
{
    public interface IGetAnotherEntitiesListQuery
    {
        List<AnotherEntitiyModel> Execute();
    }
}