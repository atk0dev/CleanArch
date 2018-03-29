namespace CleanArchitecture.Domain.AnotherEntities
{
    using CleanArchitecture.Domain.Common;

    public class AnotherEntity : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
