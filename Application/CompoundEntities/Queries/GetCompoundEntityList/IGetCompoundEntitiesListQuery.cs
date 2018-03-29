using System.Collections.Generic;

namespace CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntitiesList
{
    public interface IGetCompoundEntitiesListQuery
    {
        List<CompoundEntitiesListItemModel> Execute();
    }
}