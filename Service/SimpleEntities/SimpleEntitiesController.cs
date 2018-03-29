using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList;

namespace CleanArchitecture.Service.SimpleEntities
{
    public class SimpleEntitiesController : ApiController
    {
        private readonly IGetSimpleEntitiesListQuery _query;

        public SimpleEntitiesController(IGetSimpleEntitiesListQuery query)
        {
            _query = query;
        }

        public IEnumerable<SimpleEntityModel> Get()
        {
            return _query.Execute();
        }
    }
}