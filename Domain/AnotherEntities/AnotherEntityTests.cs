using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Domain.AnotherEntities
{
    [TestFixture]
    public class AnotherEntityTests
    {
        private readonly AnotherEntity _anotherEntity;
        private const int Id = 1;
        private const string Name = "Test";


        public AnotherEntityTests()
        {
            _anotherEntity = new AnotherEntity();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _anotherEntity.Id = Id;

            Assert.That(_anotherEntity.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _anotherEntity.Name = Name;

            Assert.That(_anotherEntity.Name,
                Is.EqualTo(Name));
        }
    }
}
