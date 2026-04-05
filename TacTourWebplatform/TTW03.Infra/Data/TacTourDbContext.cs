using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.TTW01.Domain.Entities.Actividade;
using TacTourWebplatform.TTW01.Domain.Entities.Destino;
using TacTourWebplatform.TTW01.Domain.Entities.ImagemPacote;
using TacTourWebplatform.TTW01.Domain.Entities.Itinerario;
using TacTourWebplatform.TTW01.Domain.Entities.Notificacao;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteTuristico;
using TacTourWebplatform.TTW01.Domain.Entities.Pagamento;
using TacTourWebplatform.TTW01.Domain.Entities.Perfil;
using TacTourWebplatform.TTW01.Domain.Entities.Reserva;
using TacTourWebplatform.TTW01.Domain.Entities.ReservaDestino;
using TacTourWebplatform.TTW01.Domain.Entities.TipoDestino;
using TacTourWebplatform.TTW01.Domain.Entities.Usuario;
using TacTourWebplatform.TTW01.Domain.Entities.Senha;
using System.IO.Compression;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteInfo;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteNaoIncluido;
using TacTourWebplatform.TTW01.Domain.Entities.PacoteIncluido;

namespace TacTourWebplatform.TTW03.Infra.Data;

public class TacTourDbContext(DbContextOptions<TacTourDbContext> options) : DbContext(options)
{


    //^ TODOS OS Db_Sets QUE REFERENCIAM AS CLASSES DO C# ÀS TABELAS DO POSTGREESQL


    //* 1 - Classe UsuarioEntity(C#) mapeando a tabela usuario(PostgreeSQL) 
    public DbSet<ActividadeEntity> TabelaActividade { get; set; }

    //* 2
    public DbSet<DestinoEntity> TabelaDestino { get; set; }

    //* 3
    public DbSet<ImagemPacoteEntity> TabelaImagemPacote { get; set; }

    //* 4
    public DbSet<ItinerarioEntity> TabelaItinerario { get; set; }

    //* 5
    public DbSet<NotificacaoEntity> TabelaNotificacao { get; set; }

    //* 6
    public DbSet<PacoteEntity> TabelaPacoteTuristico { get; set; }

    //* 7
    public DbSet<PacoteIncluidoEntity> TabelaPacoteIncluidos { get; set; }

    //* 8
    public DbSet<PacoteNaoIncluidoEntity> TabelaPacoteNaoIncluidos { get; set; }

    //* 9
    public DbSet<PacoteInfoEntity> TabelaPacoteInfo { get; set; }

    //* 10
    public DbSet<PagamentoEntity> TabelaPagamento { get; set; }

    //* 11
    public DbSet<PerfilEntity> TabelaPerfil { get; set; }

    //* 12
    public DbSet<ReservaEntity> TabelaReserva { get; set; }

    //* 13
    public DbSet<ReservaDestinoEntity> TabelaReservaDestino { get; set; }

    //* 14
    public DbSet<SenhaEntity> TabelaSenha { get; set; }

    //* 15
    public DbSet<TipoDestinoEntity> TabelaTipoDestino { get; set; }

    //* 16
    public DbSet<UsuarioEntity> TabelaUsuario { get; set; }




    //^ FLUENT API

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //* 1 - CLASSE ACTIVIDADE_ENTITY ( ACTIVIDADE )
        modelBuilder.Entity<ActividadeEntity>(entity =>
        {
            //& [ACTIVIDADE] com [DESTINO]
            entity.HasOne(actividade => actividade.Destino).WithMany(destino => destino.Actividades).HasForeignKey(fk => fk.IdDestino);
        });



        //* 2 - CLASSE DESTINO_ENTITY ( DESTINO )
        modelBuilder.Entity<DestinoEntity>(entity =>
        {
            //& [DESTINO] com [TIPO_DESTINO]
            entity.HasOne(destino => destino.TipoDestino).WithMany(tipodestino => tipodestino.Destinos).HasForeignKey(fk => fk.IdTipoDestino);

            //& [DESTINO] com [ITINERÁRIO]
            entity.HasMany(destino => destino.Itinerarios).WithOne(itinerario => itinerario.Destino).HasForeignKey(fk => fk.IdDestino);

            //& [DESTINO] com [RESERVA_DESTINO]
            entity.HasMany(destino => destino.ReservaDestinos).WithOne(reservadestino => reservadestino.Destino).HasForeignKey(fk => fk.IdDestino);
        });


        //* 3 - CLASSE IMAGEM_PACOTE_ENTITY ( IMAGEM PACOTE )
        modelBuilder.Entity<ImagemPacoteEntity>(entity =>
        {
            //& [IMAGEM_PACOTE] com [PACOTE_TURISTICO]
            entity.HasOne(imagempacote => imagempacote.Pacote).WithMany(pacote => pacote.Imagens).HasForeignKey(fk => fk.IdPacote);
        });


        //* 4 - CLASSE ITINERARIO_ENTITY ( ITINERARIO )
        modelBuilder.Entity<ItinerarioEntity>(entity =>
        {
            //& [ITINERARIO] com [PACOTE_TURISTICO]
            entity.HasOne(itinerario => itinerario.Pacote).WithMany(pacote => pacote.Itinerarios).HasForeignKey(fk => fk.IdPacote);
        });


        //* 5 - CLASSE NOTIFICACAO_ENTITY ( NOTIFICACAO )
        modelBuilder.Entity<NotificacaoEntity>(entity =>
        {

            //& [NOTIFICACAO] com [USUARIO]
            entity.HasOne(notificacao => notificacao.UsuarioOrigem).WithMany(usuario => usuario.NotificacoesEnviadas).HasForeignKey(fk => fk.IdOrigem);

            //& [NOTIFICACAO] com [USUARIO]
            entity.HasOne(notificacao => notificacao.UsuarioDestino).WithMany(usuario => usuario.NotificacoesRecebidas).HasForeignKey(fk => fk.IdDestino);
        });


        //* 6 - CLASSE PACOTE_ENTITY ( PACOTE TURISTICO )
        modelBuilder.Entity<PacoteEntity>(entity =>
        {
            //& [PACOTE_TURISTICO] com [RESERVA]
            entity.HasMany(pacote => pacote.Reservas).WithOne(reserva => reserva.Pacote).HasForeignKey(fk => fk.IdPacote);

            //& [PACOTE_TURISTICO] com [USUARIO]
            entity.HasOne(pacote => pacote.Operador).WithMany(usuario => usuario.Pacotes).HasForeignKey(fk => fk.IdOperador);

            //& [PACOTE_TURISTICO] com [PACOTE_INCLUIDO]
            entity.HasMany(pacote => pacote.ItensIncluidos).WithOne(incluido => incluido.Pacote).HasForeignKey(fk => fk.IdPacote);

            //& [PACOTE_TURISTICO] com [PACOTE_NAO_INCLUIDO]
            entity.HasMany(pacote => pacote.ItensNaoIncluidos).WithOne(naoincluido => naoincluido.Pacote).HasForeignKey(fk => fk.IdPacote);

            //& [PACOTE_TURISTICO] com [PACOTE_INFO]
            entity.HasMany(pacote => pacote.InfoImportantes).WithOne(infoimportante => infoimportante.Pacote).HasForeignKey(fk => fk.IdPacote);


        });


        //* 7 - CLASSE PAGAMENTO_ENTITY ( PAGAMENTO )
        modelBuilder.Entity<PagamentoEntity>(entity =>
        {
            //!____________________________________
            //! RESOLVER ESTE PROBLEMA (modifiquei a ForeignKey com a classe. Está certo? Consultar o mentor)
            //!____________________________________
            //& [PAGAMENTO] com [RESERVA]
            entity.HasOne(pagamento => pagamento.Reserva).WithOne(reserva => reserva.Pagamento).HasForeignKey<PagamentoEntity>(fk => fk.IdReserva);
        });


        //* 8 - CLASSE PERFIL_ENTITY ( PERFIL )
        modelBuilder.Entity<PerfilEntity>(entity =>
        {
            //& [PERFIL] com [USUARIO]
            entity.HasMany(perfil => perfil.Usuarios).WithOne(usuario => usuario.Perfil).HasForeignKey(fk => fk.IdPerfil);
        });


        //* 9 - CLASSE RESERVA_ENTITY ( RESERVA )
        modelBuilder.Entity<ReservaEntity>(entity =>
        {
            //& [RESERVA] com [USUARIO]
            entity.HasOne(reserva => reserva.Usuario).WithMany(usuario => usuario.Reservas).HasForeignKey(fk => fk.IdUsuario);

            //& [RESERVA] com [RESERVA_DESTINO]
            entity.HasMany(reserva => reserva.ReservaDestinos).WithOne(reservadestino => reservadestino.Reserva).HasForeignKey(fk => fk.IdReserva);
        });


        //* 10 - CLASSE SENHA_ENTITY ( SENHA )
        modelBuilder.Entity<SenhaEntity>(entity =>
        {
            //!____________________________________
            //! RESOLVER ESTE PROBLEMA (modifiquei a ForeignKey com a classe. Está certo? Consultar o mentor)
            //!____________________________________
            //& [SENHA] com [USUARIO]
            entity.HasOne(senha => senha.Usuario).WithOne(usuario => usuario.Senha).HasForeignKey<SenhaEntity>(fk => fk.IdUsuario);
        });

    }


}
