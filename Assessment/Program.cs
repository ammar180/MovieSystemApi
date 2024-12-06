using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assessment.Data;
using Assessment.Repositories;
using Assessment.Repositories.Implementations;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AssessmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefualConnection") ?? throw new InvalidOperationException("Connection string 'DefualConnection' not found.")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Project Servicies
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<INationalityRepository, NationlityRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
// New Branch