using Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(); 

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddDomains();

var app = builder.Build();

app.UseSwagger(); 

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = string.Empty;
});
app.UseCustomMiddleware();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication(); 


app.MapControllers();

app.Run();