using Microsoft.EntityFrameworkCore;
using PosInfnet.InfnetMusic.Domain.BandaAggregate;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.ValueObjects;
using PosInfnet.InfnetMusic.Domain.ContaAggregate;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate;

namespace PosInfnet.InfnetMusic.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Assinatura> Assinaturas { get; set; }
    public DbSet<Banda> Bandas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Conta>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Email).IsRequired().HasMaxLength(100);
            entity.Property(c => c.SenhaHash).IsRequired().HasMaxLength(256);

            entity.HasMany(c => c.MusicasFavoritas)
                  .WithMany(c => c.ContasMusicasFavoritas)
                  .UsingEntity(j => j.ToTable("ContasMusicasFavoritas"));

            entity.HasMany(c => c.BandasFavoritas)
                  .WithMany(c => c.ContasBandasFavoritas)
                  .UsingEntity(j => j.ToTable("ContasBandasFavoritas"));

            entity.HasOne(c => c.Assinatura)
                  .WithOne(a => a.Conta)
                  .HasForeignKey<Assinatura>("ContaId")
                  .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Banda>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AI");

            entity.HasMany(b => b.Musicas)
                .WithOne(m => m.Banda)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Musica>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Titulo)
                .IsRequired()
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AI");

            entity.HasOne(m => m.Banda)
                .WithMany(b => b.Musicas)
                .HasPrincipalKey(b => b.Id);
        });

        builder.Entity<Transacao>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Data).IsRequired();
            entity.Property(t => t.Valor).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(t => t.Status).IsRequired().HasConversion<int>();
            entity.HasOne(t => t.Conta)
                  .WithMany(c => c.Transacoes)
                  .HasPrincipalKey(x => x.Id);
        });


        builder.Entity<Assinatura>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Plano).IsRequired().HasConversion<int>();
            entity.Property(a => a.Preco).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(a => a.Data).IsRequired();
        });
    }
}
