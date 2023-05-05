﻿// <auto-generated />
using System;
using LocalWise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocalWise.Migrations
{
    [DbContext(typeof(LWDbContext))]
    [Migration("20230427182121_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocalWise.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Domingo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quarta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quinta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sabado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Segunda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Terca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("LocalWise.Models.ComentarioAvaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvalGuia")
                        .HasColumnType("int");

                    b.Property<int>("AvalItinerario")
                        .HasColumnType("int");

                    b.Property<string>("ComentGuia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComentItinerario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DetalheTuristaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DetalheTuristaId");

                    b.ToTable("ComentarioAvaliacaos");
                });

            modelBuilder.Entity("LocalWise.Models.DetalheGuia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataPrevista")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRealizado")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuiaId")
                        .HasColumnType("int");

                    b.Property<string>("Informacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItinerarioId")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorItinerario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorRecebido")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuiaId");

                    b.HasIndex("ItinerarioId");

                    b.ToTable("DetalheGuias");
                });

            modelBuilder.Entity("LocalWise.Models.DetalhesTurista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DetalheGuiaId")
                        .HasColumnType("int");

                    b.Property<int?>("TuristaId")
                        .HasColumnType("int");

                    b.Property<string>("ValorPago")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetalheGuiaId");

                    b.HasIndex("TuristaId");

                    b.ToTable("DetalhesTuristas");
                });

            modelBuilder.Entity("LocalWise.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Documentos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GerenteLocalId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GerenteLocalId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("LocalWise.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("LocalWise.Models.GerenteLocal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("PessoaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("GerenteLocals");
                });

            modelBuilder.Entity("LocalWise.Models.Guia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgendaId")
                        .HasColumnType("int");

                    b.Property<string>("Ativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GerenteLocalId")
                        .HasColumnType("int");

                    b.Property<string>("PessoaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("GerenteLocalId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Guias");
                });

            modelBuilder.Entity("LocalWise.Models.Itinerario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GuiaId")
                        .HasColumnType("int");

                    b.Property<string>("Transport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuiaId");

                    b.ToTable("Itinerarios");
                });

            modelBuilder.Entity("LocalWise.Models.Pessoa", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("LocalWise.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PontoTuristicoId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PontoTuristicoId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("LocalWise.Models.PontoTuristico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detalhes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int?>("GerenteLocalId")
                        .HasColumnType("int");

                    b.Property<int?>("GuiaId")
                        .HasColumnType("int");

                    b.Property<int?>("ItinerarioId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("GerenteLocalId");

                    b.HasIndex("GuiaId");

                    b.HasIndex("ItinerarioId");

                    b.ToTable("PontoTuristicos");
                });

            modelBuilder.Entity("LocalWise.Models.Turista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PessoaId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Turistas");
                });

            modelBuilder.Entity("LocalWise.Models.ComentarioAvaliacao", b =>
                {
                    b.HasOne("LocalWise.Models.DetalhesTurista", "DetalheTurista")
                        .WithMany()
                        .HasForeignKey("DetalheTuristaId");

                    b.Navigation("DetalheTurista");
                });

            modelBuilder.Entity("LocalWise.Models.DetalheGuia", b =>
                {
                    b.HasOne("LocalWise.Models.Guia", "Guia")
                        .WithMany()
                        .HasForeignKey("GuiaId");

                    b.HasOne("LocalWise.Models.Itinerario", "Itinerario")
                        .WithMany()
                        .HasForeignKey("ItinerarioId");

                    b.Navigation("Guia");

                    b.Navigation("Itinerario");
                });

            modelBuilder.Entity("LocalWise.Models.DetalhesTurista", b =>
                {
                    b.HasOne("LocalWise.Models.DetalheGuia", "DetalheGuia")
                        .WithMany()
                        .HasForeignKey("DetalheGuiaId");

                    b.HasOne("LocalWise.Models.Turista", "Turista")
                        .WithMany()
                        .HasForeignKey("TuristaId");

                    b.Navigation("DetalheGuia");

                    b.Navigation("Turista");
                });

            modelBuilder.Entity("LocalWise.Models.Documento", b =>
                {
                    b.HasOne("LocalWise.Models.GerenteLocal", "GerenteLocal")
                        .WithMany()
                        .HasForeignKey("GerenteLocalId");

                    b.Navigation("GerenteLocal");
                });

            modelBuilder.Entity("LocalWise.Models.GerenteLocal", b =>
                {
                    b.HasOne("LocalWise.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("LocalWise.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("Endereco");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("LocalWise.Models.Guia", b =>
                {
                    b.HasOne("LocalWise.Models.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaId");

                    b.HasOne("LocalWise.Models.GerenteLocal", "GerenteLocal")
                        .WithMany()
                        .HasForeignKey("GerenteLocalId");

                    b.HasOne("LocalWise.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("Agenda");

                    b.Navigation("GerenteLocal");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("LocalWise.Models.Itinerario", b =>
                {
                    b.HasOne("LocalWise.Models.Guia", "Guia")
                        .WithMany()
                        .HasForeignKey("GuiaId");

                    b.Navigation("Guia");
                });

            modelBuilder.Entity("LocalWise.Models.Photo", b =>
                {
                    b.HasOne("LocalWise.Models.PontoTuristico", "PontoTuristico")
                        .WithMany()
                        .HasForeignKey("PontoTuristicoId");

                    b.Navigation("PontoTuristico");
                });

            modelBuilder.Entity("LocalWise.Models.PontoTuristico", b =>
                {
                    b.HasOne("LocalWise.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("LocalWise.Models.GerenteLocal", "GerenteLocal")
                        .WithMany()
                        .HasForeignKey("GerenteLocalId");

                    b.HasOne("LocalWise.Models.Guia", "Guia")
                        .WithMany()
                        .HasForeignKey("GuiaId");

                    b.HasOne("LocalWise.Models.Itinerario", "Itinerario")
                        .WithMany()
                        .HasForeignKey("ItinerarioId");

                    b.Navigation("Endereco");

                    b.Navigation("GerenteLocal");

                    b.Navigation("Guia");

                    b.Navigation("Itinerario");
                });

            modelBuilder.Entity("LocalWise.Models.Turista", b =>
                {
                    b.HasOne("LocalWise.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
