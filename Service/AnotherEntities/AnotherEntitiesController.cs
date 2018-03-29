using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList;

namespace CleanArchitecture.Service.AnotherEntities
{
    public class AnotherEntitiesController : ApiController
    {
        private readonly IGetAnotherEntitiesListQuery _query;

        public AnotherEntitiesController(IGetAnotherEntitiesListQuery query)
        {
            _query = query;
        }

        public IEnumerable<AnotherEntitiyModel> Get()
        {
            return _query.Execute();
        }
    }
}