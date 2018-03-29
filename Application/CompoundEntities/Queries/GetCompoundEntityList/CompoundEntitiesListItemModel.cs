using System;

namespace CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntitiesList
{
    public class CompoundEntitiesListItemModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string SimpleEntityName { get; set; }

        public string AnotherEntityName { get; set; }

        public decimal A { get; set; }

        public decimal B { get; set; }

        public decimal AB { get; set; }
    }
}
