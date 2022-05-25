namespace WebApi.Common.Exception
{
    public class ErrorModel
    {
        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public int Code { get; }
        public string Message { get; }
    }
}