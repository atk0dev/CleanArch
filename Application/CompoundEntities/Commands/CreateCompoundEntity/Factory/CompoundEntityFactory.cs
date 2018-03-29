using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using CleanArchitecture.Domain.CompoundEntities;

namespace CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity.Factory
{
    public class CompoundEntityFactory : ICompoundEntityFactory
    {
        public CompoundEntity Create(DateTime date, SimpleEntity simpleEntity, AnotherEntity anotherEntity, decimal a, decimal b)
        {
            var compoundEntity = new CompoundEntity();

            compoundEntity.Date = date;

            compoundEntity.SimpleEntity = simpleEntity;

            compoundEntity.AnotherEntity = anotherEntity;

            compoundEntity.B = b;

            compoundEntity.A = a;
            
            return compoundEntity;
        }
    }
}
