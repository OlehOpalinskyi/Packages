using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApi.Common.Exception
{
    public static class BusinessRuleExceptionHandler
    {
        public static void UseBusinessRuleExceptions(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();
                    var errorModel = new ErrorModel(500, "Internal server error");

                    if (exceptionHandlerPathFeature.Error is BusinessRuleException businessRuleException)
                        errorModel = new ErrorModel(businessRuleException.Code, businessRuleException.Message);
                    else
                        context.Response.StatusCode = 500;
                    
                    var response = JsonConvert.SerializeObject(errorModel);
                    await context.Response.WriteAsync(response);
                });
            });
        }
    }
}