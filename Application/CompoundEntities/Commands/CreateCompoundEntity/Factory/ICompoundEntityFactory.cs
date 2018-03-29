using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using CleanArchitecture.Domain.CompoundEntities;

namespace CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity.Factory
{
    public interface ICompoundEntityFactory
    {
        CompoundEntity Create(DateTime date, SimpleEntity simpleEntity, AnotherEntity anotherEntity, decimal a, decimal b);
    }
}