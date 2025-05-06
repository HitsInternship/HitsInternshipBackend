using CompanyModule.Controllers;
using DeanModule.Controllers;
using Shared.Extensions;
using Shared.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSwaggerConfig();

builder.Services.AddSharedModule();
//builder.Services.AddDeanModule(builder.Configuration);
builder.Services.AddCompanyModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

//app.UseDeanModule();
app.UseCompanyModule();

app.UseHttpsRedirection();

app.Run();