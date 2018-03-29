using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMoq;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail;
using CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntitiesList;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Service.CompoundEntities
{
    [TestFixture]
    public class CompoundEntitiesControllerTests
    {
        private CompoundEntitiesController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<CompoundEntitiesController>();
        }

        [Test]
        public void TestGetShouldReturnListOfCompoundEntities()
        {
            var item = new CompoundEntitiesListItemModel();

            _mocker.GetMock<IGetCompoundEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<CompoundEntitiesListItemModel> {item} );

            var result = _controller.Get();

            Assert.That(result, 
                Contains.Item(item));
        }

        [Test]
        public void TestGetShouldReturnCompoundEntityDetails()
        {
            var entity = new CompoundEntityDetailModel();

            _mocker.GetMock<IGetCompoundEntityDetailQuery>()
                .Setup(p => p.Execute(1))
                .Returns(entity);

            var result = _controller.Get(1);

            Assert.That(result,
                Is.EqualTo(entity));
        }

        [Test]
        public void TestCreateCompoundEntityShouldCreateCompoundEntity()
        {
            var item = new CreateCompoundEntityModel();

            var result = _controller.Create(item);

            _mocker.GetMock<ICreateCompoundEntityCommand>()
                .Verify(p => p.Execute(item),
                    Times.Once);

            Assert.That(result.StatusCode, 
                Is.EqualTo(HttpStatusCode.Created));
        }
    }
}