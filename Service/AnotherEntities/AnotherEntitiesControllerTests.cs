using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMoq;
using CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList;
using NUnit.Framework;

namespace CleanArchitecture.Service.AnotherEntities
{
    [TestFixture]
    public class AnotherEntitiesControllerTests
    {
        private AnotherEntitiesController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<AnotherEntitiesController>();
        }

        [Test]
        public void TestGetAnotherEntitiesListShouldReturnListOfAnotherEntities()
        {
            var anotherEntitiy = new AnotherEntitiyModel();

            _mocker.GetMock<IGetAnotherEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<AnotherEntitiyModel> {anotherEntitiy});

            var results = _controller.Get();

            Assert.That(results,
                Contains.Item(anotherEntitiy));
        }
    }
}