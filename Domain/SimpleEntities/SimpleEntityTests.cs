using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Domain.SimpleEntities
{
    [TestFixture]
    public class SimpleEntityTests
    {
        private readonly SimpleEntity _simpleEntity;
        private const int Id = 1;
        private const string Name = "Test";


        public SimpleEntityTests()
        {
            _simpleEntity = new SimpleEntity();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _simpleEntity.Id = Id;

            Assert.That(_simpleEntity.Id, 
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _simpleEntity.Name = Name;

            Assert.That(_simpleEntity.Name, 
                Is.EqualTo(Name));
        }
    }
}
