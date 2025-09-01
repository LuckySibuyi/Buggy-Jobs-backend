using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JobSystemAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Configure JSON options (fully qualified to avoid ambiguity)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Use routing and map controllers directly (no UseEndpoints)
app.MapControllers();

app.Run();
