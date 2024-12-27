using Application.Extensions;

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

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCustomMiddleware();

app.MapControllers();

app.Run();