using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntitiesList;
using CleanArchitecture.Presentation.CompoundEntities.Models;
using CleanArchitecture.Presentation.CompoundEntities.Services;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.CompoundEntities
{
    [TestFixture]
    public class CompoundEntitiesControllerTests
    {
        private CompoundEntitiesController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<CompoundEntitiesController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfCompoundEntities()
        {
            var model = new CompoundEntitiesListItemModel();

            _mocker.GetMock<IGetCompoundEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<CompoundEntitiesListItemModel> { model });

            var viewResult = _controller.Index();

            var results = (List<CompoundEntitiesListItemModel>) viewResult.Model;

            Assert.That(results.Single(), Is.EqualTo(model));
        }

        [Test]
        public void TestGetDetailShouldReturnCompoundEntityDetail()
        {
            var id = 1;

            var model = new CompoundEntityDetailModel();

            _mocker.GetMock<IGetCompoundEntityDetailQuery>()
                .Setup(p => p.Execute(id))
                .Returns(model);

            var viewResult = _controller.Detail(id);

            var result = (CompoundEntityDetailModel) viewResult.Model;

            Assert.That(result, Is.EqualTo(model));
        }

        [Test]
        public void TestGetCreateShouldReturnCreateCompoundEntityViewModel()
        {
            var viewModel = new CreateCompoundEntityViewModel();

            _mocker.GetMock<ICreateCompoundEntityViewModelFactory>()
                .Setup(p => p.Create())
                .Returns(viewModel);

            var viewResult = _controller.Create();

            var result = (CreateCompoundEntityViewModel) viewResult.Model;

            Assert.That(result, Is.EqualTo(viewModel));
        }

        [Test]
        public void TestPostCreateShouldReturnExecuteCreateCompoundEntityCommand()
        {
            var model = new CreateCompoundEntityModel();

            var viewModel = new CreateCompoundEntityViewModel()
            {
                CompoundEntity = model
            };

            _controller.Create(viewModel);

            _mocker.GetMock<ICreateCompoundEntityCommand>()
                .Verify(p => p.Execute(model));
        }
    }
}