using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using NUnit.Framework;

namespace CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity.Factory
{
    [TestFixture]
    public class CompoundEntityFactoryTests
    {
        private CompoundEntityFactory _factory;
        private SimpleEntity _simpleEntity = new SimpleEntity();
        private AnotherEntity _anotherEntity = new AnotherEntity();

        private static readonly DateTime DateTime = new DateTime(2001, 2, 3);
        private const decimal A = 13;
        private const decimal B = 33;
        

        [SetUp]
        public void SetUp()
        {
            _simpleEntity = new SimpleEntity();

            _anotherEntity = new AnotherEntity();

            _factory = new CompoundEntityFactory();
        }

        [Test]
        public void TestCreateShouldCreateCompoundEntity()
        {
            var result = _factory.Create(DateTime, _simpleEntity, _anotherEntity, A, B);

            Assert.That(result.Date, Is.EqualTo(DateTime));
            Assert.That(result.SimpleEntity, Is.EqualTo(_simpleEntity));
            Assert.That(result.AnotherEntity, Is.EqualTo(_anotherEntity));
            Assert.That(result.A, Is.EqualTo(A));
            Assert.That(result.B, Is.EqualTo(B));
        }

    }
}
