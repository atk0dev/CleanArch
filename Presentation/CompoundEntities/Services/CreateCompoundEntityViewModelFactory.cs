using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList;
using CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity;
using CleanArchitecture.Presentation.CompoundEntities.Models;

namespace CleanArchitecture.Presentation.CompoundEntities.Services
{
    public class CreateCompoundEntityViewModelFactory : ICreateCompoundEntityViewModelFactory
    {
        private readonly IGetSimpleEntitiesListQuery _simpleEntitiesQuery;
        private readonly IGetAnotherEntitiesListQuery _anotherEntitiesQuery;

        public CreateCompoundEntityViewModelFactory(
            IGetSimpleEntitiesListQuery simpleEntitiesQuery,
            IGetAnotherEntitiesListQuery anotherEntitiesQuery)
        {
            _simpleEntitiesQuery = simpleEntitiesQuery;
            _anotherEntitiesQuery = anotherEntitiesQuery;
        }

        public CreateCompoundEntityViewModel Create()
        {
            var anotherEntities = _anotherEntitiesQuery.Execute();

            var simpleEntities = _simpleEntitiesQuery.Execute();

            var viewModel = new CreateCompoundEntityViewModel();

            viewModel.AnotherEntities = anotherEntities
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            viewModel.SimpleEntities = simpleEntities
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            viewModel.CompoundEntity = new CreateCompoundEntityModel();

            return viewModel;
        }
    }
}