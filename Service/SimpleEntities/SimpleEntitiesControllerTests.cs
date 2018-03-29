using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMoq;
using CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList;
using NUnit.Framework;

namespace CleanArchitecture.Service.SimpleEntities
{
    [TestFixture]
    public class SimpleEntitiesControllerTests
    {
        private SimpleEntitiesController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<SimpleEntitiesController>();
        }

        [Test]
        public void TestGetSimpleEntitiesListShouldReturnListOfSimpleEntities()
        {
            var simpleEntity = new SimpleEntityModel();

            _mocker.GetMock<IGetSimpleEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<SimpleEntityModel> { simpleEntity });

            var results = _controller.Get();

            Assert.That(results,
                Contains.Item(simpleEntity));
        }
    }
}