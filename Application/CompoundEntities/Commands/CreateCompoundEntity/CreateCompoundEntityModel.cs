using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity
{
    public class CreateCompoundEntityModel
    {
        public int SimpleEntityId { get; set; }

        public int AnotherEntitiyId { get; set; }

        public decimal A { get; set; }

        public decimal B { get; set; }
    }
}
