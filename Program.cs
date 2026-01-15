using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using BSBESales.Data;
using BSBESales.Middlewares;
using BSBESales.Services.SdoService;
using BSBESales.Services.StandardsServices;
using BSBESales.Services.StandardSearch;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Esales");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString)
);

// Add services to the container.
builder.Services.AddScoped<ISdoService, SdoService>();
builder.Services.AddScoped<IStandardServices,StandardServices>();
builder.Services.AddScoped<IStandardSearchService, StandardSearchService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();