namespace WebApi.Common.Exception.Contracts
{
    public interface IExceptionStore
    {
        string GetMessage(string key);
    }
}