using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using CleanArchitecture.Domain.SimpleEntities;

namespace CleanArchitecture.Persistance.SimpleEntities
{
    public class SimpleEntityConfiguration : EntityTypeConfiguration<SimpleEntity>
    {
        public SimpleEntityConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
