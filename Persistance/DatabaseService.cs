using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using CleanArchitecture.Domain.CompoundEntities;
using CleanArchitecture.Persistance.SimpleEntities;
using CleanArchitecture.Persistance.AnotherEntities;
using CleanArchitecture.Persistance.CompoundEntities;


namespace CleanArchitecture.Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<SimpleEntity> SimpleEntities { get; set; }

        public IDbSet<AnotherEntity> AnotherEntities { get; set; }

        public IDbSet<CompoundEntity> CompoundEntities { get; set; }

        public DatabaseService() : base("CleanArchitecture")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new SimpleEntityConfiguration());
            modelBuilder.Configurations.Add(new AnotherEntitiyConfiguration());
            modelBuilder.Configurations.Add(new CompoundEntityConfiguration());
        }
    }
}
