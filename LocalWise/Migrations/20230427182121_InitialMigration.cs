using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalWise.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Segunda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quarta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quinta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sabado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domingo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GerenteLocals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true),
                    PessoaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerenteLocals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GerenteLocals_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GerenteLocals_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Turistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turistas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerenteLocalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_GerenteLocals_GerenteLocalId",
                        column: x => x.GerenteLocalId,
                        principalTable: "GerenteLocals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Guias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GerenteLocalId = table.Column<int>(type: "int", nullable: true),
                    AgendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guias_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guias_GerenteLocals_GerenteLocalId",
                        column: x => x.GerenteLocalId,
                        principalTable: "GerenteLocals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Guias_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Itinerarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuiaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itinerarios_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalheGuias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRealizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorItinerario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorRecebido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuiaId = table.Column<int>(type: "int", nullable: true),
                    ItinerarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheGuias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalheGuias_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetalheGuias_Itinerarios_ItinerarioId",
                        column: x => x.ItinerarioId,
                        principalTable: "Itinerarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PontoTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true),
                    GerenteLocalId = table.Column<int>(type: "int", nullable: true),
                    GuiaId = table.Column<int>(type: "int", nullable: true),
                    ItinerarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoTuristicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontoTuristicos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PontoTuristicos_GerenteLocals_GerenteLocalId",
                        column: x => x.GerenteLocalId,
                        principalTable: "GerenteLocals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PontoTuristicos_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PontoTuristicos_Itinerarios_ItinerarioId",
                        column: x => x.ItinerarioId,
                        principalTable: "Itinerarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalhesTuristas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalheGuiaId = table.Column<int>(type: "int", nullable: true),
                    TuristaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhesTuristas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalhesTuristas_DetalheGuias_DetalheGuiaId",
                        column: x => x.DetalheGuiaId,
                        principalTable: "DetalheGuias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetalhesTuristas_Turistas_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turistas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PontoTuristicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_PontoTuristicos_PontoTuristicoId",
                        column: x => x.PontoTuristicoId,
                        principalTable: "PontoTuristicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComentarioAvaliacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComentGuia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvalGuia = table.Column<int>(type: "int", nullable: false),
                    ComentItinerario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvalItinerario = table.Column<int>(type: "int", nullable: false),
                    DetalheTuristaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioAvaliacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentarioAvaliacaos_DetalhesTuristas_DetalheTuristaId",
                        column: x => x.DetalheTuristaId,
                        principalTable: "DetalhesTuristas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioAvaliacaos_DetalheTuristaId",
                table: "ComentarioAvaliacaos",
                column: "DetalheTuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheGuias_GuiaId",
                table: "DetalheGuias",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheGuias_ItinerarioId",
                table: "DetalheGuias",
                column: "ItinerarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesTuristas_DetalheGuiaId",
                table: "DetalhesTuristas",
                column: "DetalheGuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesTuristas_TuristaId",
                table: "DetalhesTuristas",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_GerenteLocalId",
                table: "Documentos",
                column: "GerenteLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_GerenteLocals_EnderecoId",
                table: "GerenteLocals",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_GerenteLocals_PessoaId",
                table: "GerenteLocals",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_AgendaId",
                table: "Guias",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_GerenteLocalId",
                table: "Guias",
                column: "GerenteLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_PessoaId",
                table: "Guias",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Itinerarios_GuiaId",
                table: "Itinerarios",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PontoTuristicoId",
                table: "Photos",
                column: "PontoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristicos_EnderecoId",
                table: "PontoTuristicos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristicos_GerenteLocalId",
                table: "PontoTuristicos",
                column: "GerenteLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristicos_GuiaId",
                table: "PontoTuristicos",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristicos_ItinerarioId",
                table: "PontoTuristicos",
                column: "ItinerarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Turistas_PessoaId",
                table: "Turistas",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioAvaliacaos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "DetalhesTuristas");

            migrationBuilder.DropTable(
                name: "PontoTuristicos");

            migrationBuilder.DropTable(
                name: "DetalheGuias");

            migrationBuilder.DropTable(
                name: "Turistas");

            migrationBuilder.DropTable(
                name: "Itinerarios");

            migrationBuilder.DropTable(
                name: "Guias");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "GerenteLocals");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
