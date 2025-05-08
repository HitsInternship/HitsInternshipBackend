using DeanModule.Controllers;
using HitsInternship.Api.Extensions.Middlewares;
using HitsInternship.Api.Extensions.Swagger;
using Shared.Extensions;
using Shared.Extensions.ErrorHandling;
using Shared.Extensions.ErrorHandling.Validation;
using Shared.Extensions.Swagger;
using System.Text.Json.Serialization;
using UserModule.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = FailedAnnotationValidationResponse.MakeValidationResponse);

builder.Services.AddSharedModule(builder.Configuration);
builder.Services.AddDeanModule(builder.Configuration);
builder.Services.AddUserModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

app.UseUserModule();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Services.UseDeanModule();

app.AddMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();