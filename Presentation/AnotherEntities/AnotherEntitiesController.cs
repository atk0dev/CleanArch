using System;
using System.Web.Mvc;
using CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList;

namespace CleanArchitecture.Presentation.AnotherEntities
{
    public class AnotherEntitiesController : Controller
    {
        private readonly IGetAnotherEntitiesListQuery _query;

        public AnotherEntitiesController(IGetAnotherEntitiesListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var anotherEntities = _query.Execute();

            return View(anotherEntities);
        }
    }
}