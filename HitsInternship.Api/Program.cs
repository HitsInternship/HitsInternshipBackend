using HitsInternship.Api.Extensions.Middlewares;
using HitsInternship.Api.Extensions.Swagger;
using Shared.Extensions.ErrorHandling.Validation;
using System.Text.Json.Serialization;
using HitsInternship.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .ConfigureApiBehaviorOptions(options =>
        options.InvalidModelStateResponseFactory = FailedAnnotationValidationResponse.MakeValidationResponse);

builder.Services.AddApplicationModules(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

app.Services.UseApplicationModules();

app.AddMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();