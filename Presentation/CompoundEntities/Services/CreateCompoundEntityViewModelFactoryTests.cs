using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.SimpleEntities.Queries.GetSimpleEntityList;
using CleanArchitecture.Application.AnotherEntities.Queries.GetAnotherEntitiesList;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.CompoundEntities.Services
{
    [TestFixture]
    public class CreateCompoundEntityViewModelFactoryTests
    {
        private CreateCompoundEntityViewModelFactory _factory;
        private AutoMoqer _mocker;

        private const int SimpleEntityId = 1;
        private const string SimpleEntityName = "SimpleEntity 1";
        private const int AnotherEntitiyId = 2;
        private const string AnotherEntitiyName = "AnotherEntity 2";
        
        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            var simpleEntity = new SimpleEntityModel
            {
                Id = SimpleEntityId,
                Name = SimpleEntityName,
            };

            var anotherEntitiy = new AnotherEntitiyModel()
            {
                Id = AnotherEntitiyId,
                Name = AnotherEntitiyName
            };

            _mocker.GetMock<IGetSimpleEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<SimpleEntityModel> { simpleEntity });

            _mocker.GetMock<IGetAnotherEntitiesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<AnotherEntitiyModel> { anotherEntitiy });

            _factory = _mocker.Create<CreateCompoundEntityViewModelFactory>();
        }

        [Test]
        public void TestCreateShouldSetSimpleEntities()
        {
            var viewModel = _factory.Create();

            var result = viewModel.SimpleEntities.Single();

            Assert.That(result.Value, 
                Is.EqualTo(SimpleEntityId.ToString()));
            
            Assert.That(result.Text, 
                Is.EqualTo(SimpleEntityName));            
        }

        [Test]
        public void TestCreateShouldSetAnotherEntities()
        {
            var viewModel = _factory.Create();

            var result = viewModel.AnotherEntities.Single();

            Assert.That(result.Value, 
                Is.EqualTo(AnotherEntitiyId.ToString()));
            
            Assert.That(result.Text, 
                Is.EqualTo(AnotherEntitiyName));
        }

        [Test]
        public void TestCreateShouldCreateEmptyCompoundEntityModel()
        {
            var viewModel = _factory.Create();

            var result = viewModel.CompoundEntity;

            Assert.That(result, Is.Not.Null);
        }
    }
}