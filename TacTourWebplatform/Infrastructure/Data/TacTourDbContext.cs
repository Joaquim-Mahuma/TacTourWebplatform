using Microsoft.EntityFrameworkCore;
using TacTourWebplatform.Domain.Entities;

namespace TacTourWebplatform.Infrastructure.Data;

public class TacTourDbContext(DbContextOptions<TacTourDbContext> options) : DbContext(options)
{
    public DbSet<Actividade> Actividades { get; set; } = null!;

    public DbSet<Destino> Destinos { get; set; } = null!;

    public DbSet<ImagemPacote> ImagensPacote { get; set; } = null!;

    public DbSet<Itinerario> Itinerarios { get; set; } = null!;

    public DbSet<Notificacao> Notificacoes { get; set; } = null!;

    public DbSet<Pacote> Pacotes { get; set; } = null!;

    public DbSet<PacoteIncluido> PacotesIncluidos { get; set; } = null!;

    public DbSet<PacoteNaoIncluido> PacotesNaoIncluidos { get; set; } = null!;

    public DbSet<PacoteInfo> PacotesInfo { get; set; } = null!;

    public DbSet<Pagamento> Pagamentos { get; set; } = null!;

    public DbSet<Perfil> Perfis { get; set; } = null!;

    public DbSet<Reserva> Reservas { get; set; } = null!;

    public DbSet<Senha> Senhas { get; set; } = null!;

    public DbSet<TipoDestino> TiposDestino { get; set; } = null!;

    public DbSet<Usuario> Usuarios { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=tactourwebplatform-joaquimmahuma14-b205.d.aivencloud.com;Port=14344;Database=defaultdb;Username=avnadmin;Password=AVNS_6KiaHjz60cS4OnQNeBh;SSL Mode=Require;Trust Server Certificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasOne(a => a.Destino).WithMany(d => d.Actividades).HasForeignKey(a => a.IdDestino);
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasOne(d => d.TipoDestino).WithMany(t => t.Destinos).HasForeignKey(d => d.IdTipoDestino);
            entity.HasMany(d => d.Itinerarios).WithOne(i => i.Destino).HasForeignKey(i => i.IdDestino);
        });

        modelBuilder.Entity<ImagemPacote>(entity =>
        {
            entity.HasOne(i => i.Pacote).WithMany(p => p.Imagens).HasForeignKey(i => i.IdPacote);
        });

        modelBuilder.Entity<Itinerario>(entity =>
        {
            entity.HasOne(i => i.Pacote).WithMany(p => p.Itinerarios).HasForeignKey(i => i.IdPacote);
        });

        modelBuilder.Entity<Notificacao>(entity =>
        {
            entity.HasOne(n => n.UsuarioOrigem).WithMany(u => u.NotificacoesEnviadas).HasForeignKey(n => n.IdOrigem);
            entity.HasOne(n => n.UsuarioDestino).WithMany(u => u.NotificacoesRecebidas).HasForeignKey(n => n.IdDestino);
        });

        modelBuilder.Entity<Pacote>(entity =>
        {
            entity.HasMany(p => p.Reservas).WithOne(r => r.Pacote).HasForeignKey(r => r.IdPacote);
            entity.HasOne(p => p.Operador).WithMany(u => u.Pacotes).HasForeignKey(p => p.IdOperador);
            entity.HasMany(p => p.ItensIncluidos).WithOne(i => i.Pacote).HasForeignKey(i => i.IdPacote);
            entity.HasMany(p => p.ItensNaoIncluidos).WithOne(n => n.Pacote).HasForeignKey(n => n.IdPacote);
            entity.HasMany(p => p.InfoImportantes).WithOne(i => i.Pacote).HasForeignKey(i => i.IdPacote);
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasOne(p => p.Reserva).WithOne(r => r.Pagamento).HasForeignKey<Pagamento>(p => p.IdReserva);
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasMany(p => p.Usuarios).WithOne(u => u.Perfil).HasForeignKey(u => u.IdPerfil);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasOne(r => r.Usuario).WithMany(u => u.Reservas).HasForeignKey(r => r.IdUsuario);
        });

        modelBuilder.Entity<Senha>(entity =>
        {
            entity.HasOne(s => s.Usuario).WithOne(u => u.Senha).HasForeignKey<Senha>(s => s.IdUsuario);
        });
    }
}
