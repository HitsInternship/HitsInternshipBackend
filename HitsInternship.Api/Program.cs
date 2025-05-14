using System.Text;
using HitsInternship.Api.Extensions.Middlewares;
using HitsInternship.Api.Extensions.Swagger;
using Shared.Extensions.ErrorHandling.Validation;
using System.Text.Json.Serialization;
using AuthModel.Service;
using HitsInternship.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerConfig();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(AuthSettings.PrivateKey))
        };
    });
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
app.UseAuthentication();
app.UseAuthorization();

app.AddMiddleware();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();