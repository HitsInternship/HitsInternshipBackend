using CompanyModule.Controllers;
using DeanModule.Controllers;
using DocumentModule.Controllers;
using HitsInternship.Api.Extensions.Middlewares;
using HitsInternship.Api.Extensions.Swagger;
using Shared.Extensions;
using Shared.Extensions.Validation;
using Shared.Extensions.ErrorHandling.Validation;
using System.Text.Json.Serialization;
using HitsInternship.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


builder.Services.AddSwaggerConfig();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .ConfigureApiBehaviorOptions(options =>
        options.InvalidModelStateResponseFactory = FailedAnnotationValidationResponse.MakeValidationResponse);
builder.Services.AddApplicationModules(builder.Configuration);
builder.Services.AddSharedModule(builder.Configuration);
//builder.Services.AddDeanModule(builder.Configuration);
builder.Services.AddDocumentModule(builder.Configuration);
builder.Services.AddUserModule(builder.Configuration);
builder.Services.AddCompanyModule(builder.Configuration);
builder.Services.AddUserModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}
app.UseCors("AllowAllOrigins");

app.UseUserModule();
//app.Services.UseDeanModule();
app.UseCompanyModule();

app.Services.UseApplicationModules();

app.AddMiddleware();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();