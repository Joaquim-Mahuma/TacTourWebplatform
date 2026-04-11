using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Queries;
using TacTourWebplatform.TTW03.Infra.Data;
using TacTourWebplatform.TTW03.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();  // Para gerar o documento OpenAPI



//* DbContext
string conexao = builder.Configuration.GetConnectionString("ConexaoLocal")!;

builder.Services.AddDbContext<TacTourDbContext>(options => options.UseNpgsql(conexao));


//* Repositories
builder.Services.AddScoped<ITipoDestinoRepository, TipoDestinoRepository>();
builder.Services.AddScoped<IDestinoRepository, DestinoRepository>();


//* Uses Cases
builder.Services.AddTransient<CadastrarTipoDestino>();
builder.Services.AddTransient<ActualizarTipoDestino>();
builder.Services.AddTransient<DeletarTipoDestino>();
builder.Services.AddTransient<PesquisarTipoDestinoId>();
builder.Services.AddTransient<PesquisarTipoDestinoTexto>();
builder.Services.AddTransient<ListagemTipoDestino>();



// ========== App ==========

var app = builder.Build();

// Configuração para Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();       // Gera o documento /openapi/v1.json

    // === IMPORTANTE: Isto ativa a interface Swagger UI ===
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TacTourWebplatform API v1");
        options.RoutePrefix = "swagger";   // Para aceder em /swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Endpoint de teste simples (para confirmar que a API está viva)
app.MapGet("/", () => "✅ API TacTourWebplatform está a funcionar!");

app.Run();