using Shared.Extensions;

using Shared.Extensions;
using Shared.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSharedModule();

builder.Services.AddSwaggerConfig();

builder.Services.AddSharedModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.Run();