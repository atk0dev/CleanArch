using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Mocks;
using CleanArchitecture.Domain.AnotherEntities;
using NUnit.Framework;

namespace CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList
{
    [TestFixture]
    public class GetAnotherEntitiesListQueryTests
    {
        private GetAnotherEntitiesListQuery _query;
        private AutoMoqer _mocker;
        private AnotherEntity _anotherEntitiy;

        private const int Id = 1;
        private const string Name = "Another Entitiy 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _anotherEntitiy = new AnotherEntity()
            {
                Id = Id,
                Name = Name
            };

            _mocker.GetMock<IDbSet<AnotherEntity>>()
                .SetUpDbSet(new List<AnotherEntity> { _anotherEntitiy });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.AnotherEntities)
                .Returns(_mocker.GetMock<IDbSet<AnotherEntity>>().Object);

            _query = _mocker.Create<GetAnotherEntitiesListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfAnotherEntities()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
