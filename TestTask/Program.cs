using Autofac;
using BL.Services;
using DA;
using DA.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(

    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")
    ));

builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IIncidentService, IncidentService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ISaveChangerService, SaveChangerService>();
builder.Services.AddScoped<ISaveChanger, SaveChanger>();
//var containerBuilder = new ContainerBuilder();

//containerBuilder.RegisterType<DataContext>().AsSelf().SingleInstance();
//containerBuilder.RegisterType<ContactRepository>().As<IContactRepository>();
//containerBuilder.RegisterType<AccountRepository>().As<IAccountRepository>();
//containerBuilder.RegisterType<IncidentRepository>().As<IIncidentRepository>();
//containerBuilder.RegisterType<AccountService>().As<IAccountService>();
//containerBuilder.RegisterType<IncidentService>().As<IIncidentService>();
//containerBuilder.RegisterType<ContactService>().As<IContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
