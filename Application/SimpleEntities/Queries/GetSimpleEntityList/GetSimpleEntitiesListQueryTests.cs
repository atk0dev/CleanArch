using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Mocks;
using CleanArchitecture.Domain.SimpleEntities;
using NUnit.Framework;

namespace CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList
{
    [TestFixture]
    public class GetSimpleEntitiesListQueryTests
    {
        private GetSimpleEntitiesListQuery _query;
        private AutoMoqer _mocker;
        private SimpleEntity _simpleEntity;

        private const int Id = 1;
        private const string Name = "SimpleEntity 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _simpleEntity = new SimpleEntity()
            {
                Id = Id,
                Name = Name
            };

            _mocker.GetMock<IDbSet<SimpleEntity>>()
                .SetUpDbSet(new List<SimpleEntity> { _simpleEntity });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.SimpleEntities)
                .Returns(_mocker.GetMock<IDbSet<SimpleEntity>>().Object);

            _query = _mocker.Create<GetSimpleEntitiesListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfSimpleEntities()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
