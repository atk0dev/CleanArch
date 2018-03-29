using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList
{
    public class GetSimpleEntitiesListQuery: IGetSimpleEntitiesListQuery
    {
        private readonly IDatabaseService _database;

        public GetSimpleEntitiesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<SimpleEntityModel> Execute()
        {
            var simpleEntities = _database.SimpleEntities
                .Select(p => new SimpleEntityModel()
                {
                    Id = p.Id, 
                    Name = p.Name
                });

            return simpleEntities.ToList();
        }
    }
}
