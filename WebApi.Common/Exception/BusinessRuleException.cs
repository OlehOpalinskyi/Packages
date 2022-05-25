using System;

namespace WebApi.Common.Exception
{
    public class BusinessRuleException : System.Exception
    {
        public int Code { get; }

        public BusinessRuleException(int code, string message)
            : base(message)
        {
            Code = code;
        }
        
        public BusinessRuleException(Enum code, string message)
            : base(message)
        {
            Code = Convert.ToInt32(code);
        }
    }
}