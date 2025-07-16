using FluentValidation.AspNetCore;
using MarkupApi.Application;
using MarkupApi.Application.Markup.Commands;
using MarkupApi.Infrastructure;
using MarkupApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("MarkupApi.Infrastructure")
    ));
builder.Services.AddScoped<IMarkupRepository, MarkupRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMarkupCommand).Assembly));
builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // React frontend origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp"); // Enable the CORS policy
app.UseAuthorization();

app.MapControllers();

app.Run();