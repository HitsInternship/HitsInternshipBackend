using DeanModule.Controllers;
using Shared.Extensions;
using Shared.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSwaggerConfig();

builder.Services.AddSharedModule();
builder.Services.AddDeanModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

app.UseDeanModule();

app.UseHttpsRedirection();

app.Run();