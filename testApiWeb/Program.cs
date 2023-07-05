using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;

namespace testApiWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options => {});
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
            });
            app.UseCors();

            app.MapGet("/", () => "Hello World!");

            Data dataInstance = new Data();

            app.MapGet("/items", () =>
            {
                List<string> items = dataInstance.Items;

                return Results.Json(items);
            });
            app.Run();
        }
    }
}  