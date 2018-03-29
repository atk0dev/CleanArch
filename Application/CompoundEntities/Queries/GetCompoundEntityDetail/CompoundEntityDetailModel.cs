using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Application.CompoundEntities.Queries.GetCompoundEntityDetail
{
    public class CompoundEntityDetailModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string SimpleEntityName { get; set; }

        public string AnotherEntitiyName { get; set; }

        public decimal A { get; set; }

        public decimal B { get; set; }

        public decimal AB { get; set; }
    }
}