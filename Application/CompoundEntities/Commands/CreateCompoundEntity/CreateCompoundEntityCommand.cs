using System;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity.Factory;
using CleanArchitecture.Common.Dates;

namespace CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity
{
    public class CreateCompoundEntityCommand : ICreateCompoundEntityCommand
    {
        private readonly IDateService _dateService;
        private readonly IDatabaseService _database;
        private readonly ICompoundEntityFactory _factory;
        private readonly IOtherService _inventory;

        public CreateCompoundEntityCommand(
            IDateService dateService,
            IDatabaseService database,
            ICompoundEntityFactory factory,
            IOtherService inventory)
        {
            _dateService = dateService;
            _database = database;
            _factory = factory;
            _inventory = inventory;
        }

        public void Execute(CreateCompoundEntityModel model)
        {
            var date = _dateService.GetDate();

            var simpleEntity = _database.SimpleEntities
                .Single(p => p.Id == model.SimpleEntityId);

            var anotherEntitiy = _database.AnotherEntities
                .Single(p => p.Id == model.AnotherEntitiyId);

            var a = model.A;
            var b = model.B;

            var compoundEntity = _factory.Create(
                date,
                simpleEntity, 
                anotherEntitiy, 
                a, b);

            _database.CompoundEntities.Add(compoundEntity);

            _database.Save();

            _inventory.NotifyDataChanged(1, a);
        }
    }
}
