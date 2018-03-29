using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.AnotherEntities
{
    [TestFixture]
    public class AnotherEntitiesControllerTests
    {
        private AnotherEntitiesController _controller;
        private AutoMoqer _mocker;
        private AnotherEntitiyModel _model;

        [SetUp]
        public void SetUp()
        {
            _model = new AnotherEntitiyModel();

            _mocker = new AutoMoqer();

            _mocker.GetMock<IGetAnotherEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<AnotherEntitiyModel> { _model });

            _controller = _mocker.Create<AnotherEntitiesController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfAnotherEntities()
        {
            var viewResult = _controller.Index();

            var result = (List<AnotherEntitiyModel>) viewResult.Model;

            Assert.That(result.Single(), Is.EqualTo(_model));
        }
    }
}