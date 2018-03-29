using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList
{
    public class GetAnotherEntitiesListQuery
        : IGetAnotherEntitiesListQuery
    {
        private readonly IDatabaseService _database;

        public GetAnotherEntitiesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<AnotherEntitiyModel> Execute()
        {
            var anotherEntities = _database.AnotherEntities
                .Select(p => new AnotherEntitiyModel
                {
                    Id = p.Id,
                    Name = p.Name
                });               

            return anotherEntities.ToList();
        }
    }
}
