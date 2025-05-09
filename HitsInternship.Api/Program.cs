using CompanyModule.Controllers;
using DeanModule.Controllers;
using DocumentModule.Controllers;
using HitsInternship.Api.Extensions.Middlewares;
using HitsInternship.Api.Extensions.Swagger;
using Shared.Extensions;
using Shared.Extensions.Validation;
using System.Text.Json.Serialization;
using UserModule.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

<<<<<<< HEAD
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = FailedAnnotationValidationResponse.MakeValidationResponse);

builder.Services.AddSharedModule(builder.Configuration);
//builder.Services.AddDeanModule(builder.Configuration);
builder.Services.AddDocumentModule(builder.Configuration);
builder.Services.AddUserModule(builder.Configuration);
=======
builder.Services.AddSharedModule();
//builder.Services.AddDeanModule(builder.Configuration);
>>>>>>> f7116892c871c6e26e81efd7ffdcd0bb2698baa8
builder.Services.AddCompanyModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

<<<<<<< HEAD
app.UseUserModule();
//app.Services.UseDeanModule();
app.UseCompanyModule();

app.AddMiddleware();
=======
//app.UseDeanModule();
app.UseCompanyModule();
>>>>>>> f7116892c871c6e26e81efd7ffdcd0bb2698baa8

app.UseHttpsRedirection();

app.MapControllers();

app.Run();