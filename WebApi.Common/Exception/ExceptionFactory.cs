using System;
using WebApi.Common.Exception.Contracts;

namespace WebApi.Common.Exception
{
    public class ExceptionFactory : IExceptionFactory
    {
        private const string DefaultMessage = "Something went wrong.";
        private const int DefaultStatusCode = 409;
        
        private readonly IExceptionStore _exceptionStore;

        public ExceptionFactory(IExceptionStore exceptionStore)
        {
            _exceptionStore = exceptionStore;
        }

        public void ThrowBusinessRuleException(Enum code)
        {
            var codeNumber = Convert.ToInt32(code);
            
            ThrowBusinessRuleException(codeNumber);
        }
        
        public void ThrowBusinessRuleException(Enum code, params object[] args)
        {
            var codeNumber = Convert.ToInt32(code);

            ThrowBusinessRuleException(codeNumber, args);
        }
        
        public void ThrowBusinessRuleException(int code)
        {
            var message = _exceptionStore.GetMessage(code.ToString()) ?? DefaultMessage;
            throw new BusinessRuleException(code, message);
        }

        public void ThrowBusinessRuleException(int code, params object[] args)
        {
            var messageTemplate = _exceptionStore.GetMessage(code.ToString()) ?? DefaultMessage;

            var message = string.IsNullOrEmpty(messageTemplate)
                ? DefaultMessage
                : string.Format(messageTemplate, args);
            throw new BusinessRuleException(code, message);
        }

        public static void ThrowBusinessRuleException(int code, string message) =>
            throw new BusinessRuleException(code, message);

        public static void ThrowBusinessRuleException(string message) =>
            throw new BusinessRuleException(DefaultStatusCode, message);
    }
}