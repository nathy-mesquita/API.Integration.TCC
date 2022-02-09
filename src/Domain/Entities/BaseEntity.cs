using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }

        public int Id { get; protected set; }


    }
}