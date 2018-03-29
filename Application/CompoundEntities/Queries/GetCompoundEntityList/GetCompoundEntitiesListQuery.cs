using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntitiesList
{
    public class GetCompoundEntitiesListQuery
        : IGetCompoundEntitiesListQuery
    {
        private readonly IDatabaseService _database;

        public GetCompoundEntitiesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<CompoundEntitiesListItemModel> Execute()
        {
            var compoundEntities = _database.CompoundEntities
                .Select(p => new CompoundEntitiesListItemModel()
                {
                    Id = p.Id, 
                    Date = p.Date,
                    SimpleEntityName = p.SimpleEntity.Name,
                    AnotherEntityName = p.AnotherEntity.Name,
                    A = p.A,
                    B = p.B,
                    AB = p.AB
                });

            return compoundEntities.ToList();
        }
    }
}
