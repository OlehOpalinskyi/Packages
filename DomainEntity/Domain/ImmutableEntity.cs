using System;
using DomainEntity.Abstractions;

namespace DomainEntity.Domain
{
    public  abstract class ImmutableEntity : ImmutableEntityBase<Guid>
    {
    }
}