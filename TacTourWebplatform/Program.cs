using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Application.Dashboard;
using TacTourWebplatform.Application.Destinos;
using TacTourWebplatform.Application.Equipa;
using TacTourWebplatform.Application.Pacotes;
using TacTourWebplatform.Application.Reservas;
using TacTourWebplatform.Application.TiposDestino;
using TacTourWebplatform.Domain.Interfaces;
using TacTourWebplatform.Infrastructure.Data;
using TacTourWebplatform.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? builder.Configuration.GetConnectionString("ConexaoLocal");

if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Connection string não configurada.");

builder.Services.AddDbContext<TacTourDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ITipoDestinoRepository, TipoDestinoRepository>();
builder.Services.AddScoped<IDestinoRepository, DestinoRepository>();
builder.Services.AddScoped<IPacoteRepository, PacoteRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<TipoDestinoService>();
builder.Services.AddScoped<DestinoService>();
builder.Services.AddScoped<PacoteService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<EquipaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "TacTour API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseCors("Frontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
