using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.SimpleEntities
{
    public class SimpleEntity : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
