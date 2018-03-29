using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using CleanArchitecture.Domain.CompoundEntities;

namespace CleanArchitecture.Persistance
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);

            CreateSimpleEntities(database);

            CreateAnotherEntities(database);

            CreateCompoundEntities(database);
        }

        private void CreateSimpleEntities(DatabaseService database)
        {
            database.SimpleEntities.Add(new SimpleEntity() { Name = "SimpleEntity 1" });

            database.SimpleEntities.Add(new SimpleEntity() { Name = "SimpleEntity 2" });

            database.SimpleEntities.Add(new SimpleEntity() { Name = "SimpleEntity 3" });

            database.SaveChanges();
        }

        private void CreateAnotherEntities(DatabaseService database)
        {
            database.AnotherEntities.Add(new AnotherEntity() { Name = "Another Entitiy 1" });

            database.AnotherEntities.Add(new AnotherEntity() { Name = "Another Entitiy 2" });

            database.AnotherEntities.Add(new AnotherEntity() { Name = "Another Entitiy 3" });

            database.SaveChanges();
        }

        private void CreateCompoundEntities(DatabaseService database)
        {
            var simpleEntities = database.SimpleEntities.ToList();

            var anotherEntities = database.AnotherEntities.ToList();

            database.CompoundEntities.Add(new CompoundEntity()
            {
                Date = DateTime.Now.Date.AddDays(-3),
                SimpleEntity = simpleEntities[0],
                AnotherEntity = anotherEntities[0],
                A = 5,
                B = 3
            });

            database.CompoundEntities.Add(new CompoundEntity()
            {
                Date = DateTime.Now.Date.AddDays(-2),
                SimpleEntity = simpleEntities[1],
                AnotherEntity = anotherEntities[1],
                A = 3,
                B = 2
            });

            database.CompoundEntities.Add(new CompoundEntity()
            {
                Date = DateTime.Now.Date.AddDays(-1),
                SimpleEntity = simpleEntities[2],
                AnotherEntity = anotherEntities[2],
                A = 4,
                B = 3
            });

            database.SaveChanges();
        }
    }
}
