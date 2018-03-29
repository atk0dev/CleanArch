using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using NUnit.Framework;

namespace CleanArchitecture.Domain.CompoundEntities
{
    [TestFixture]
    public class CompoundEntityTests
    {
        private CompoundEntity _compoundEntity;
        private SimpleEntity _simpleEntity;
        private AnotherEntity _anotherEntity;

        private const int Id = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const decimal A = 2;
        private const decimal B = 4;

        [SetUp]
        public void SetUp()
        {
            _simpleEntity = new SimpleEntity();

            _anotherEntity = new AnotherEntity();

            _compoundEntity = new CompoundEntity();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _compoundEntity.Id = Id;

            Assert.That(_compoundEntity.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetDate()
        {
            _compoundEntity.Date = Date;

            Assert.That(_compoundEntity.Date,
                Is.EqualTo(Date));
        }

        [Test]
        public void TestSetAndGetSimpleEntity()
        {
            _compoundEntity.SimpleEntity = _simpleEntity;

            Assert.That(_compoundEntity.SimpleEntity,
                Is.EqualTo(_simpleEntity));
        }

        [Test]
        public void TestSetAndGet_anotherEntity()
        {
            _compoundEntity.AnotherEntity = _anotherEntity;

            Assert.That(_compoundEntity.AnotherEntity,
                Is.EqualTo(_anotherEntity));
        }

       
        [Test]
        public void TestSetAndGetA()
        {
            _compoundEntity.A = A;

            Assert.That(_compoundEntity.A, 
                Is.EqualTo(A));
        }

        [Test]
        public void TestSetAndGetB()
        {
            _compoundEntity.B = B;

            Assert.That(_compoundEntity.B,
                Is.EqualTo(B));
        }

        [Test]
        public void TestSetAShouldRecomputeAB()
        {
            _compoundEntity.A = A;

            _compoundEntity.B = 3m;

            Assert.That(_compoundEntity.AB, 
                Is.EqualTo(6));
        }

        [Test]
        public void TestSetBShouldRecomputeAB()
        {
            _compoundEntity.B = B;

            _compoundEntity.A = 2;

            Assert.That(_compoundEntity.AB, Is.EqualTo(8));
        }
    }
}
