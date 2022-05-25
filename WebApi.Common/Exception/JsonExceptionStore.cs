using Microsoft.Extensions.Configuration;
using WebApi.Common.Exception.Contracts;

namespace WebApi.Common.Exception
{
    public class JsonExceptionStore : IExceptionStore
    {
        private static readonly IConfiguration Configuration;

        static JsonExceptionStore()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("Exceptions.json");
            Configuration = builder.Build();
        }
        
        public string GetMessage(string key) => Configuration[key];
    }
}