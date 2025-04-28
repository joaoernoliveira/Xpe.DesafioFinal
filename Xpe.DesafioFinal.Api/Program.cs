using Arquitetura.Teste.EntityDDD.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using Xpe.DesafioFinal.Data.Config;
using Xpe.DesafioFinal.Domain.Construtores;
using Xpe.DesafioFinal.Domain.Interfaces;
using Xpe.DesafioFinal.Service;
using Xpe.DesafioFinal.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//builder.Services.AddConfig();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteBuilder, ClienteBuilder>();

// Resposta objeto = JsonSerializer.Deserialize<Resposta>(conn);


builder.Services.AddDbContext<SqlServerContext>(opt =>
{
    //  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    var conn = "Server=DESKTOP-2CU4HVV\\SQLEXPRESS;Database=DesafioFinalDb;User Id=sa;Password=mqpoqtj;TrustServerCertificate=true";
    opt.UseSqlServer(conn);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();


public class Resposta
{
    public string clientId { get; set; }

    public string clientSecret { get; set; }
}