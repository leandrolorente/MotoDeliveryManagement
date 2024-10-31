using Microsoft.Extensions.DependencyInjection;
using MotoDelivery.Domain.Interfaces;
using MotoDelivery.Infrastructure.Interfaces;
using MotoDelivery.Infrastructure.Messages;
using MotoDelivery.Infrastructure.Persistence;
using MotoDelivery.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add the ApplicationDbContext to the service collection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IMessageBus, RabbitMqMessageBus>();
// Add other dependencies (repositories, MediatR, etc.)
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<IEntregadorRepository, EntregadorRepository>();
builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
