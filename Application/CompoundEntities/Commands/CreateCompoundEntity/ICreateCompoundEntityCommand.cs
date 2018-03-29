namespace CleanArchitecture.Application.CompoundEntities.Commands.CreateCompoundEntity
{
    public interface ICreateCompoundEntityCommand
    {
        void Execute(CreateCompoundEntityModel model);
    }
}