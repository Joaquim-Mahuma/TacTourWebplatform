using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Interface;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.Command;
using TacTourWebplatform.TTW02.Application.ActividadeUseCase.Queries;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.Command;
using TacTourWebplatform.TTW02.Application.DestinoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.Command;
using TacTourWebplatform.TTW02.Application.ImagemPacoteUseCase.Queries;
using TacTourWebplatform.TTW02.Application.Interfaces.Password;
using TacTourWebplatform.TTW02.Application.ItinerarioUseCase.Command;
using TacTourWebplatform.TTW02.Application.ItinerarioUseCase.Queries;
using TacTourWebplatform.TTW02.Application.NotificacaoUseCase.Command;
using TacTourWebplatform.TTW02.Application.NotificacaoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Command;
using TacTourWebplatform.TTW02.Application.PacoteIncluidoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Command;
using TacTourWebplatform.TTW02.Application.PacoteInfoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.Command;
using TacTourWebplatform.TTW02.Application.PacoteNaoIncluidoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.Command;
using TacTourWebplatform.TTW02.Application.PacoteTuristicoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.Command;
using TacTourWebplatform.TTW02.Application.PagamentoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.PerfilUseCase.Command;
using TacTourWebplatform.TTW02.Application.PerfilUseCase.Queries;
using TacTourWebplatform.TTW02.Application.ReservaUseCase.Command;
using TacTourWebplatform.TTW02.Application.ReservaUseCase.Queries;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Commands;
using TacTourWebplatform.TTW02.Application.TipoDestinoUseCase.Queries;
using TacTourWebplatform.TTW02.Application.UsuarioUseCase.Command;
using TacTourWebplatform.TTW03.Infra.Data;
using TacTourWebplatform.TTW03.Infra.Repositories;
using TacTourWebplatform.TTW03.Infra.Services.Password;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

string conexao = builder.Configuration.GetConnectionString("ConexaoLocal")!;

builder.Services.AddDbContext<TacTourDbContext>(options => options.UseNpgsql(conexao));

builder.Services.AddScoped<IActividadeRepository, ActividadeRepository>();
builder.Services.AddScoped<IDestinoRepository, DestinoRepository>();
builder.Services.AddScoped<IImagemPacoteRepository, ImagemPacoteRepository>();
builder.Services.AddScoped<IItinerarioRepository, ItinerarioRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<IPacoteIncluidoRepository, PacoteIncluidoRepository>();
builder.Services.AddScoped<IPacoteInfoRepository, PacoteInfoRepository>();
builder.Services.AddScoped<IPacoteNaoIncluidoRepository, PacoteNaoIncluidoRepository>();
builder.Services.AddScoped<IPacoteRepository, PacoteRepository>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ISenhaRepository, SenhaRepository>();
builder.Services.AddScoped<ITipoDestinoRepository, TipoDestinoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPasswordHash, PasswordHashService>();

builder.Services.AddTransient<CadastrarActividade>();
builder.Services.AddTransient<ActualizarActividade>();
builder.Services.AddTransient<DeletarActividade>();
builder.Services.AddTransient<ListagemActividade>();
builder.Services.AddTransient<PesquisarActividadeId>();
builder.Services.AddTransient<ListarActividadePorDestino>();

builder.Services.AddTransient<CadastrarDestino>();
builder.Services.AddTransient<ActualizarDestino>();
builder.Services.AddTransient<DeletarDestino>();
builder.Services.AddTransient<ListarDestinoPorTipo>();

builder.Services.AddTransient<CadastrarImagemPacote>();
builder.Services.AddTransient<ActualizarImagemPacote>();
builder.Services.AddTransient<DeletarImagemPacote>();
builder.Services.AddTransient<ListagemImagemPacote>();
builder.Services.AddTransient<PesquisarImagemPacoteId>();
builder.Services.AddTransient<ListarImagemPacotePorPacote>();

builder.Services.AddTransient<CadastrarItinerario>();
builder.Services.AddTransient<ActualizarItinerario>();
builder.Services.AddTransient<DeletarItinerario>();
builder.Services.AddTransient<ListagemItinerario>();
builder.Services.AddTransient<PesquisarItinerarioId>();
builder.Services.AddTransient<ListarItinerarioPorPacote>();

builder.Services.AddTransient<CadastrarNotificacao>();
builder.Services.AddTransient<ActualizarNotificacao>();
builder.Services.AddTransient<DeletarNotificacao>();
builder.Services.AddTransient<ListagemNotificacao>();
builder.Services.AddTransient<PesquisarNotificacaoId>();
builder.Services.AddTransient<ListarNotificacaoPorUsuario>();

builder.Services.AddTransient<CadastrarPacoteIncluido>();
builder.Services.AddTransient<ActualizarPacoteIncluido>();
builder.Services.AddTransient<DeletarPacoteIncluido>();
builder.Services.AddTransient<ListagemPacoteIncluido>();
builder.Services.AddTransient<PesquisarPacoteIncluidoId>();
builder.Services.AddTransient<ListarPacoteIncluidoPorPacote>();

builder.Services.AddTransient<CadastrarPacoteInfo>();
builder.Services.AddTransient<ActualizarPacoteInfo>();
builder.Services.AddTransient<DeletarPacoteInfo>();
builder.Services.AddTransient<ListagemPacoteInfo>();
builder.Services.AddTransient<PesquisarPacoteInfoId>();
builder.Services.AddTransient<ListarPacoteInfoPorPacote>();

builder.Services.AddTransient<CadastrarPacoteNaoIncluido>();
builder.Services.AddTransient<ActualizarPacoteNaoIncluido>();
builder.Services.AddTransient<DeletarPacoteNaoIncluido>();
builder.Services.AddTransient<ListagemPacoteNaoIncluido>();
builder.Services.AddTransient<PesquisarPacoteNaoIncluidoId>();
builder.Services.AddTransient<ListarPacoteNaoIncluidoPorPacote>();

builder.Services.AddTransient<CadastrarPacoteTuristico>();
builder.Services.AddTransient<ActualizarPacoteTuristico>();
builder.Services.AddTransient<DeletarPacoteTuristico>();
builder.Services.AddTransient<ListagemPacoteTuristico>();
builder.Services.AddTransient<PesquisarPacoteTuristicoId>();
builder.Services.AddTransient<ListarPacoteTuristicoActivo>();
builder.Services.AddTransient<ListarPacoteTuristicoPorDestino>();
builder.Services.AddTransient<ListarPacoteTuristicoPorNome>();
builder.Services.AddTransient<ListarPacoteTuristicoPorOperador>();

builder.Services.AddTransient<CadastrarPagamento>();
builder.Services.AddTransient<ActualizarPagamento>();
builder.Services.AddTransient<DeletarPagamento>();
builder.Services.AddTransient<ListagemPagamento>();
builder.Services.AddTransient<PesquisarPagamentoId>();
builder.Services.AddTransient<PesquisarPagamentoPorReserva>();
builder.Services.AddTransient<ListarPagamentoPorEstado>();

builder.Services.AddTransient<CadastrarPerfil>();
builder.Services.AddTransient<ActualizarPerfil>();
builder.Services.AddTransient<DeletarPerfil>();
builder.Services.AddTransient<ListagemPerfil>();
builder.Services.AddTransient<PesquisarPerfilId>();

builder.Services.AddTransient<CadastrarReserva>();
builder.Services.AddTransient<ActualizarReserva>();
builder.Services.AddTransient<DeletarReserva>();
builder.Services.AddTransient<ListagemReserva>();
builder.Services.AddTransient<PesquisarReservaId>();
builder.Services.AddTransient<ListarReservaPorUsuario>();
builder.Services.AddTransient<ListarReservaPorPacote>();
builder.Services.AddTransient<ListarReservaPorEstado>();
builder.Services.AddTransient<ListarReservaPorTipo>();

builder.Services.AddTransient<CadastrarTipoDestino>();
builder.Services.AddTransient<ActualizarTipoDestino>();
builder.Services.AddTransient<DeletarTipoDestino>();
builder.Services.AddTransient<PesquisarTipoDestinoId>();
builder.Services.AddTransient<PesquisarTipoDestinoTexto>();
builder.Services.AddTransient<ListagemTipoDestino>();

builder.Services.AddTransient<CadastrarUsuario>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TacTourWebplatform API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "API TacTourWebplatform esta a funcionar!");

app.Run();
