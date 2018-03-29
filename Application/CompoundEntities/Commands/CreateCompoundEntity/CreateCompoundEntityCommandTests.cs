using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity.Factory;
using CleanArchitecture.Common.Dates;
using CleanArchitecture.Common.Mocks;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using CleanArchitecture.Domain.CompoundEntities;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity
{
    [TestFixture]
    public class CreateCompoundEntityCommandTests
    {
        private CreateCompoundEntityCommand _command;
        private AutoMoqer _mocker;
        private CreateCompoundEntityModel _model;
        private CompoundEntity _compoundEntity;

        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const int SimpleEntityId = 1;
        private const int AnotherEntityId = 2;
        private const decimal B = 3;
        private const decimal A = 4;

        [SetUp]
        public void SetUp()
        {
            var simpleEntity = new SimpleEntity
            {
                Id = SimpleEntityId
            };

            var anotherEntitiy = new AnotherEntity
            {
                Id = AnotherEntityId
            };

            _model = new CreateCompoundEntityModel()
            {
                SimpleEntityId = SimpleEntityId,
                AnotherEntitiyId = AnotherEntityId,
                A = A
            };

            _compoundEntity = new CompoundEntity();
            
            _mocker = new AutoMoqer();

            _mocker.GetMock<IDateService>()
                .Setup(p => p.GetDate())
                .Returns(Date);

            SetUpDbSet(p => p.SimpleEntities, simpleEntity);
            SetUpDbSet(p => p.AnotherEntities, anotherEntitiy);
            SetUpDbSet(p => p.CompoundEntities);

            _mocker.GetMock<ICompoundEntityFactory>()
                .Setup(p => p.Create(
                    Date,
                    simpleEntity,
                    anotherEntitiy,
                    A, B))
                .Returns(_compoundEntity);
            
            _command = _mocker.Create<CreateCompoundEntityCommand>();
        }

        
        [Test]
        public void TestExecuteShouldSaveChangesToDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDatabaseService>()
                .Verify(p => p.Save(),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldNotifyInventoryThatCompoundEntityOccurred()
        {
            _command.Execute(_model);

            _mocker.GetMock<IOtherService>()
                .Verify(p => p.NotifyDataChanged(
                        1,
                        A),
                    Times.Once);
        }

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property, T entity)
            where T : class
        {
            _mocker.GetMock<IDbSet<T>>()
               .SetUpDbSet(new List<T> { entity });

            _mocker.GetMock<IDatabaseService>()
               .Setup(property)
               .Returns(_mocker.GetMock<IDbSet<T>>().Object);
        }

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property)
           where T : class
        {
            _mocker.GetMock<IDbSet<T>>()
               .SetUpDbSet(new List<T>());

            _mocker.GetMock<IDatabaseService>()
               .Setup(property)
               .Returns(_mocker.GetMock<IDbSet<T>>().Object);
        }
    }
}
