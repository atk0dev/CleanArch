using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using CleanArchitecture.Domain.CompoundEntities;

namespace CleanArchitecture.Persistance.CompoundEntities
{
    public class CompoundEntityConfiguration : EntityTypeConfiguration<CompoundEntity>
    {
        public CompoundEntityConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Date)
                .IsRequired();

            HasRequired(p => p.SimpleEntity);

            HasRequired(p => p.AnotherEntity);

            Property(p => p.AB)
                .IsRequired()
                .HasPrecision(5, 2);
        }
    }
}
