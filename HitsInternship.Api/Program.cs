using DeanModule.Controllers;
using Shared.Extensions;
using Shared.Extensions.Swagger;
using StudentModule.Controllers;
using UserModule.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSwaggerConfig();
builder.Services.AddControllers();

builder.Services.AddSharedModule();
//builder.Services.AddDeanModule(builder.Configuration);
builder.Services.AddStudentModule(builder.Configuration);
builder.Services.AddUserModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerConfiguration();
}

app.UseDeanModule();
app.Services.UseStudentModule();
app.UseUserModule();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();