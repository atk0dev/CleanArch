using System;
using System.Web.Mvc;
using CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList;

namespace CleanArchitecture.Presentation.SimpleEntities
{
    public class SimpleEntitiesController : Controller
    {
        private readonly IGetSimpleEntitiesListQuery _query;

        public SimpleEntitiesController(IGetSimpleEntitiesListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var simpleEntities = _query.Execute();

            return View(simpleEntities);
        }
    }
}