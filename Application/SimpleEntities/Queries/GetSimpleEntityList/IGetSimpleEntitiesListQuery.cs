using System.Collections.Generic;

namespace CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList
{
    public interface IGetSimpleEntitiesListQuery
    {
        List<SimpleEntityModel> Execute();
    }
}