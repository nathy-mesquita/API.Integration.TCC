namespace API.Integration.TCC.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
        }

        public int Id { get; protected set; }
        
        
    }
}