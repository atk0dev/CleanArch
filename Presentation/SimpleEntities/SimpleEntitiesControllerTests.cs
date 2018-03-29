using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.SimpleEntities
{
    [TestFixture]
    public class SimpleEntitiesControllerTests
    {
        private SimpleEntitiesController _controller;
        private AutoMoqer _mocker;
        private SimpleEntityModel _model;

        [SetUp]
        public void SetUp()
        {
            _model = new SimpleEntityModel();

            _mocker = new AutoMoqer();

            _mocker.GetMock<IGetSimpleEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<SimpleEntityModel> { _model });

            _controller = _mocker.Create<SimpleEntitiesController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfSimpleEntities()
        {
            var viewResult = _controller.Index();

            var result = (List<SimpleEntityModel>) viewResult.Model;

            Assert.That(result.Single(), Is.EqualTo(_model));
        }
    }
}