using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Mocks;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using CleanArchitecture.Domain.CompoundEntities;
using NUnit.Framework;

namespace CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail
{
    [TestFixture]
    public class GetCompoundEntityDetailQueryTests
    {
        private GetCompoundEntityDetailQuery _query;
        private AutoMoqer _mocker;
        private CompoundEntity _compoundEntity;

        private const int id = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const string SimpleEntityName = "SimpleEntity 1";
        private const string AnotherEntityName = "AnotherEntity 1";
        private const decimal A = 3;
        private const decimal B = 2;
        private const decimal AB = 6;

        [SetUp]
        public void SetUp()
        {
            var simpleEntity = new SimpleEntity
            {
                Name = SimpleEntityName
            };

            var anotherEntitiy = new AnotherEntity
            {
                Name = AnotherEntityName
            };

            _compoundEntity = new CompoundEntity()
            {
                Id = id,
                Date = Date,
                SimpleEntity = simpleEntity,
                AnotherEntity = anotherEntitiy,
                A = A,
                B = B
            };

            _mocker = new AutoMoqer();

            _query = _mocker.Create<GetCompoundEntityDetailQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnCompoundEntityDetail()
        {
            _mocker.GetMock<IDbSet<CompoundEntity>>()
                .SetUpDbSet(new List<CompoundEntity> {_compoundEntity });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.CompoundEntities)
                .Returns(_mocker.GetMock<IDbSet<CompoundEntity>>().Object);

            var result = _query.Execute(id);

            Assert.That(result.Id, 
                Is.EqualTo(id));

            Assert.That(result.Date, 
                Is.EqualTo(Date));

            Assert.That(result.SimpleEntityName, 
                Is.EqualTo(SimpleEntityName));

            Assert.That(result.AnotherEntitiyName, 
                Is.EqualTo(AnotherEntityName));

            Assert.That(result.A, 
                Is.EqualTo(A));

            Assert.That(result.B, 
                Is.EqualTo(B));

            Assert.That(result.AB, 
                Is.EqualTo(AB));
        }
    }
}
