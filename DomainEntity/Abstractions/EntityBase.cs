using System;

namespace DomainEntity.Abstractions
{
    public abstract class EntityBase<TPk> : ImmutableEntityBase<TPk>
    {
        public DateTime ModifiedDateTime { get; private set; }
        
        protected void Update(DateTime modifiedDateTime)
        {
            ModifiedDateTime = modifiedDateTime;
        }

        protected void Update()
        {
            Update(DateTime.UtcNow);
        }
        
        protected new void Create(TPk id, DateTime modifiedDateTime)
        {
            ModifiedDateTime = modifiedDateTime;
            
            base.Create(id, DateTime.UtcNow);
        }
        
        protected new void Create(TPk id)
        {
            Create(id, DateTime.UtcNow);
        }
    }
}