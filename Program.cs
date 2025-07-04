
using System.Diagnostics;

namespace TodoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "Open API V1");
                });

                // Automatically open browser at /swagger when using dotnet run while using Kestrel (via CLI)
                Process.Start(new ProcessStartInfo
                {
                    FileName = "http://localhost:5083/swagger",
                    UseShellExecute = true
                });

                // Add redirect from root ("/") to Swagger while using Kestrel (via CLI)
                app.Use(async (context, next) =>
                {
                    if (context.Request.Path == "/")
                    {
                        context.Response.Redirect("/swagger");
                        return;
                    }
                    await next();
                });
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
