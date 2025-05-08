using DeanModule.Controllers;
using HitsInternship.Api.Extensions.Middlewares;
using HitsInternship.Api.Extensions.Swagger;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

builder.Services.AddSharedModule(builder.Configuration);
builder.Services.AddDeanModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

app.Services.UseDeanModule();

app.AddMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();