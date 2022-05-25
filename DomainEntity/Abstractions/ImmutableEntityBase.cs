using System;
using WebApi.Common.Contracts;
using WebApi.Common.Exception;

namespace DomainEntity.Abstractions
{
    public abstract class ImmutableEntityBase<TPk>
    {
        public TPk Id { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        
        protected void Create(TPk id, DateTime createdDateTime)
        {
            Id = id;
            CreatedDateTime = createdDateTime;
        }
        
        protected void Create(TPk id)
        {
            Create(id, DateTime.UtcNow);
        }
    }
}