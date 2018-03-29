using CleanArchitecture.Presentation.CompoundEntities.Models;

namespace CleanArchitecture.Presentation.CompoundEntities.Services
{
    public interface ICreateCompoundEntityViewModelFactory
    {
        CreateCompoundEntityViewModel Create();
    }
}