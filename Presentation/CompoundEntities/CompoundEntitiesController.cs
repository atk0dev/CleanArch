using System;
using System.Linq;
using System.Web.Mvc;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntitiesList;
using CleanArchitecture.Presentation.CompoundEntities.Models;
using CleanArchitecture.Presentation.CompoundEntities.Services;

namespace CleanArchitecture.Presentation.CompoundEntities
{
    [RoutePrefix("CompoundEntities")]
    public class CompoundEntitiesController : Controller
    {
        private readonly IGetCompoundEntitiesListQuery _compoundEntitiesListQuery;
        private readonly IGetCompoundEntityDetailQuery _compoundEntityDetailQuery;
        private readonly ICreateCompoundEntityViewModelFactory _factory;
        private readonly ICreateCompoundEntityCommand _createCommand;

        public CompoundEntitiesController(
            IGetCompoundEntitiesListQuery compoundEntitiesListQuery,
            IGetCompoundEntityDetailQuery compoundEntityDetailQuery,
            ICreateCompoundEntityViewModelFactory factory,
            ICreateCompoundEntityCommand createCommand)
        {
            _compoundEntitiesListQuery = compoundEntitiesListQuery;
            _compoundEntityDetailQuery = compoundEntityDetailQuery;
            _factory = factory;
            _createCommand = createCommand;
        }

        [Route("")]
        public ViewResult Index()
        {
            var compoundntities = _compoundEntitiesListQuery.Execute();

            return View(compoundntities);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var compoundEntity = _compoundEntityDetailQuery.Execute(id);

            return View(compoundEntity);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public RedirectToRouteResult Create(CreateCompoundEntityViewModel viewModel)
        {
            var model = viewModel.CompoundEntity;            

            _createCommand.Execute(model);

            return RedirectToAction("index", "CompoundEntities");
        }
    }
}