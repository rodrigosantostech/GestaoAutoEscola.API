using GestaoAutoEscola.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoAutoEscola.API.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Aula> Aulas { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<CategoriaTransacao> CategoriaTransacoes { get; set; }
    public DbSet<Instrutor> Instrutores { get; set; }
    public DbSet<TipoTransacao> TipoTransacoes { get; set; }
    public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=GestaoAutoEscola;Integrated Security=SSPI;TrustServerCertificate=True");
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.Modelo).IsRequired();
            entity.Property(c => c.Marca).IsRequired();
            entity.Property(c => c.Ano);
            entity.Property(c => c.Cor);
            entity.Property(c => c.Placa).IsRequired();
            entity.Property(c => c.Categoria);
            entity.Property(c => c.Status);
            entity.Property(c => c.Kilometragem);
            entity.Property(c => c.DataUltimaManutencao);

            // Relacionamentos
            entity.HasMany(c => c.Aulas)
                .WithOne(a => a.Veiculo)
                .HasForeignKey(a => a.Id);

            entity.HasMany(c => c.Instrutores)
                .WithMany(i => i.Veiculos)
                .UsingEntity(j => j.ToTable("InstrutorCarro"));

            entity.HasOne(c => c.TipoVeiculo)
                .WithMany(i => i.Veiculos)
                .HasForeignKey(c => c.TipoVeiculoId);
        });

        modelBuilder.Entity<TipoVeiculo>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();
            entity.Property(t => t.Tipo).IsRequired();
        });
        modelBuilder.Entity<TipoTransacao>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();
            entity.Property(t => t.Tipo).IsRequired();
        });
        modelBuilder.Entity<CategoriaTransacao>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();
            entity.Property(t => t.Nome).IsRequired();
        });

        modelBuilder.Entity<Instrutor>(entity =>
        {
            entity.Property(i => i.CategoriaLicenca).IsRequired();
            entity.Property(i => i.DataValidadeLicenca).IsRequired();
            entity.Property(a => a.Salario).HasColumnType("decimal(18,2)").IsRequired();

            // Relacionamentos
            entity.HasMany(i => i.Veiculos)
                .WithMany(c => c.Instrutores)
                .UsingEntity(j => j.ToTable("InstrutorCarro"));

            entity.HasMany(i => i.Aulas)
                .WithOne(a => a.Instrutor)
                .HasForeignKey(a => a.InstrutorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.Property(a => a.Aprovado);
            entity.Property(a => a.ObjetivoAula).IsRequired();

            // Relacionamento
            entity.HasMany(a => a.Aulas)
                .WithOne(aula => aula.Aluno)
                .HasForeignKey(aula => aula.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();
            entity.Property(a => a.Data).IsRequired();
            entity.Property(a => a.Nota).IsRequired();
            entity.Property(a => a.Feedback).IsRequired();

            entity.HasOne(a => a.Aula)
                .WithOne(aula => aula.Avaliacao)
                .HasForeignKey<Avaliacao>(a => a.AulaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Aluno)
                .WithMany(aluno => aluno.Avaliacoes)
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Instrutor)
                .WithMany(instrutor => instrutor.Avaliacoes)
                .HasForeignKey(a => a.InstrutorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();
            entity.Property(a => a.Email).IsRequired();
            entity.Property(a => a.Senha).IsRequired();
            entity.Property(a => a.Nome).IsRequired();
            entity.Property(a => a.DataNascimento);
            entity.Property(a => a.Telefone);
            entity.Property(a => a.Endereco);
            entity.Property(a => a.DataCadastro);
            entity.Property(a => a.Roles);

            // Relacionamento
            entity.HasDiscriminator<string>("TipoUsuario")
                .HasValue<Aluno>("Aluno")
                .HasValue<Instrutor>("Instrutor");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();
            entity.Property(a => a.Data).IsRequired();
            entity.Property(a => a.Hora).IsRequired();
            entity.Property(a => a.Pago).IsRequired();

            // Relacionamentos
            entity.HasOne(a => a.Veiculo)
                .WithMany(c => c.Aulas)
                .HasForeignKey(a => a.VeiculoId);

            entity.HasOne(a => a.Instrutor)
                .WithMany(i => i.Aulas)
                .HasForeignKey(a => a.InstrutorId);

            entity.HasOne(a => a.Aluno)
                .WithMany(a => a.Aulas)
                .HasForeignKey(a => a.AlunoId);

            entity.HasOne(a => a.Transacao)
                .WithOne(t => t.Aula)
                .HasForeignKey<Aula>(a => a.TransacaoId)
                .IsRequired(false);

            entity.HasOne(a => a.Avaliacao)
                .WithOne(avaliacao => avaliacao.Aula)
                .HasForeignKey<Aula>(a => a.AvaliacaoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).ValueGeneratedOnAdd();

            entity.Property(a => a.DataTransacao).IsRequired();
            entity.Property(a => a.Descricao).IsRequired();
            entity.Property(a => a.Valor).HasColumnType("decimal(18,2)").IsRequired();

            // Relacionamentos
            entity.HasOne(t => t.TipoTransacao)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.TipoTransacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Categoria)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Aula)
                .WithOne(a => a.Transacao)
                .HasForeignKey<Transacao>(t => t.AulaId)
                .IsRequired(false);
        });
    }
}
