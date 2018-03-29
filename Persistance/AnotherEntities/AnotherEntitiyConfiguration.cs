using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using CleanArchitecture.Domain.AnotherEntities;

namespace CleanArchitecture.Persistance.AnotherEntities
{
    public class AnotherEntitiyConfiguration
           : EntityTypeConfiguration<AnotherEntity>
    {
        public AnotherEntitiyConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
