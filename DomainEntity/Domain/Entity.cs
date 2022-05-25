using System;
using DomainEntity.Abstractions;

namespace DomainEntity.Domain
{
    public abstract class Entity : EntityBase<Guid>
    {
    }
}