using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail
{
    public class GetCompoundEntityDetailQuery : IGetCompoundEntityDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetCompoundEntityDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public CompoundEntityDetailModel Execute(int id)
        {
            var entity = _database.CompoundEntities
                .Where(p => p.Id == id)
                .Select(p => new CompoundEntityDetailModel()
                {
                    Id = p.Id, 
                    Date = p.Date,
                    SimpleEntityName = p.SimpleEntity.Name,
                    AnotherEntitiyName = p.AnotherEntity.Name,
                    A = p.A,
                    B = p.B,
                    AB = p.AB
                })
                .Single();

            return entity;
        }
    }
}
