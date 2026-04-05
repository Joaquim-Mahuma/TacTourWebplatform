using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW03.Infra.Data;
using TacTourWebplatform.TTW03.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//* A linha abaixo vai ao arquivo [appsettings.json], procura a seção:
//*     "ConnectionStrings": {
//*         "ConexaoLocal": "..."
//*     }
//* E pega o valor da string de conexão.
//* O ponto de exclamação significa "Garanto que esse valor NÃO É NULO"
//*                 |
//*                 ↓

string conexao = builder.Configuration.GetConnectionString("ConexaoLocal")!;

//* Quando alguém precisar de TacTourDbContext, use essa configuração.E dentro de () signfica Meu DbContext vai usar PostgreSQL com essa string.
//*     |
//*     ↓
builder.Services.AddDbContext<TacTourDbContext>(options => options.UseNpgsql(conexao));


//* Pôr aqui as cenas do Repositories


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
