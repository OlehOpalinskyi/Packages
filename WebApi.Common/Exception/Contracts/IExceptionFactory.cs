using System;

namespace WebApi.Common.Exception.Contracts
{
    public interface IExceptionFactory
    {
        void ThrowBusinessRuleException(Enum code);
        void ThrowBusinessRuleException(Enum code, params object[] args);
        void ThrowBusinessRuleException(int code);
        void ThrowBusinessRuleException(int code, params object[] args);
    }
}