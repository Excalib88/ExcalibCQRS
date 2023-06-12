using ExcalibCQRS.Application.Commands;
using ExcalibCQRS.Application.Repositories;
using ExcalibCQRS.Infrastructure;
using ExcalibCQRS.Infrastructure.Commands;
using ExcalibCQRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Db")));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddMediatR(x => 
    x.RegisterServicesFromAssemblies(typeof(AddUserHandler).Assembly, typeof(AddUserCommand).Assembly));

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Excalib CQRS API", Version = "v1" });
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();