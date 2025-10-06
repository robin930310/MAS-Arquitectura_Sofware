using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using UsabanaAPIrest.Datos;
using UsabanaAPIrest.Extensions.Swagger;
using UsabanaAPIrest.Servicios;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();
    builder.Services.AddProblemDetails();

    builder.ConfigureOpenApi();

    builder.Services.AddCors(opt =>
    {
        opt.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

    builder.Services.AddRateLimiter(opc =>
    {
        opc.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        opc.OnRejected = async (context, token) =>
        {
            ProblemDetails problem = new()
            {
                Status = StatusCodes.Status429TooManyRequests,
                Title = "Demasiadas solicitudes",
                Detail = "Has excedido el número permitido de llamadas. Por favor, intenta nuevamente más tarde.",
                Type = "https://httpstatuses.com/429",
                Instance = context.HttpContext.Request.Path
            };

            context.HttpContext.Response.ContentType = "application/problem+json";
            context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

            await context.HttpContext.Response.WriteAsJsonAsync(problem, token);
        };

        opc.AddTokenBucketLimiter("General", limiterOptions =>
        {
            limiterOptions.TokensPerPeriod = 2;
            limiterOptions.TokenLimit = 10;
            limiterOptions.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
            limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        });
    });

    builder.Services
        .AddDbContext<AppDbContext>(opc => opc.UseInMemoryDatabase("TestDb"))
        .AddScoped<IProductService, ProductService>();
}

WebApplication app = builder.Build();
{
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider
        .GetRequiredService<AppDbContext>()
        .Database.EnsureCreated();


    app.UseStaticFiles();
    app.UseOpenApi();

    app.UseHttpsRedirection();
    app.UseRateLimiter();
    app.UseCors();
    app.MapControllers()
        .RequireRateLimiting("General");
    app.UseExceptionHandler();
    app.UseStatusCodePages();
}

app.Run();
