using System.Data.Entity;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;
using CleanArchitecture.Domain.CompoundEntities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<SimpleEntity> SimpleEntities { get; set; }

        IDbSet<AnotherEntity> AnotherEntities { get; set; }
        
        IDbSet<CompoundEntity> CompoundEntities { get; set; }

        void Save();
    }
}