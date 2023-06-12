﻿// <auto-generated />
using System;
using GestaoAutoEscola.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoAutoEscola.API.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230611230641_HoraInicioHoraFim")]
    partial class HoraInicioHoraFim
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int?>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finalizada")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("HoraFim")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int>("InstrutorId")
                        .HasColumnType("int");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.Property<int?>("TransacaoId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("AvaliacaoId")
                        .IsUnique()
                        .HasFilter("[AvaliacaoId] IS NOT NULL");

                    b.HasIndex("InstrutorId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("AulaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstrutorId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("InstrutorId");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.CategoriaTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaTransacoes");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.TipoTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoTransacoes");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.TipoVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoVeiculos");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AulaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataTransacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoTransacaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AulaId")
                        .IsUnique()
                        .HasFilter("[AulaId] IS NOT NULL");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TipoTransacaoId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Roles").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataUltimaManutencao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kilometragem")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TipoVeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoVeiculoId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("InstrutorVeiculo", b =>
                {
                    b.Property<int>("InstrutoresId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculosId")
                        .HasColumnType("int");

                    b.HasKey("InstrutoresId", "VeiculosId");

                    b.HasIndex("VeiculosId");

                    b.ToTable("InstrutorCarro", (string)null);
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("GestaoAutoEscola.API.Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue("ADMIN");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Aluno", b =>
                {
                    b.HasBaseType("GestaoAutoEscola.API.Domain.Entities.Usuario");

                    b.Property<bool>("Aprovado")
                        .HasColumnType("bit");

                    b.Property<string>("ObjetivoAula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ALUNO");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Gerente", b =>
                {
                    b.HasBaseType("GestaoAutoEscola.API.Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue("GERENTE");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Instrutor", b =>
                {
                    b.HasBaseType("GestaoAutoEscola.API.Domain.Entities.Usuario");

                    b.Property<string>("CategoriaLicenca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataValidadeLicenca")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("INSTRUTOR");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Aula", b =>
                {
                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Aluno", "Aluno")
                        .WithMany("Aulas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Avaliacao", "Avaliacao")
                        .WithOne("Aula")
                        .HasForeignKey("GestaoAutoEscola.API.Domain.Entities.Aula", "AvaliacaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Instrutor", "Instrutor")
                        .WithMany("Aulas")
                        .HasForeignKey("InstrutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Veiculo", "Veiculo")
                        .WithMany("Aulas")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Avaliacao");

                    b.Navigation("Instrutor");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Aluno", "Aluno")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Instrutor", "Instrutor")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("InstrutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Instrutor");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Transacao", b =>
                {
                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Aula", "Aula")
                        .WithOne("Transacao")
                        .HasForeignKey("GestaoAutoEscola.API.Domain.Entities.Transacao", "AulaId");

                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.CategoriaTransacao", "Categoria")
                        .WithMany("Transacoes")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.TipoTransacao", "TipoTransacao")
                        .WithMany("Transacoes")
                        .HasForeignKey("TipoTransacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("Categoria");

                    b.Navigation("TipoTransacao");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.TipoVeiculo", "TipoVeiculo")
                        .WithMany("Veiculos")
                        .HasForeignKey("TipoVeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoVeiculo");
                });

            modelBuilder.Entity("InstrutorVeiculo", b =>
                {
                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Instrutor", null)
                        .WithMany()
                        .HasForeignKey("InstrutoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoAutoEscola.API.Domain.Entities.Veiculo", null)
                        .WithMany()
                        .HasForeignKey("VeiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Aula", b =>
                {
                    b.Navigation("Transacao");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Avaliacao", b =>
                {
                    b.Navigation("Aula")
                        .IsRequired();
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.CategoriaTransacao", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.TipoTransacao", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.TipoVeiculo", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Veiculo", b =>
                {
                    b.Navigation("Aulas");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Aluno", b =>
                {
                    b.Navigation("Aulas");

                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("GestaoAutoEscola.API.Domain.Entities.Instrutor", b =>
                {
                    b.Navigation("Aulas");

                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
