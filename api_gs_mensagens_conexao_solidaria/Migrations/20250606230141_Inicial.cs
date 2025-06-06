using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_gs_mensagens_conexao_solidaria.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MENSAGENS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    CONTEUDO = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: false),
                    PRIORIDADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    DATA_ENVIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UUID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TTL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    USUARIO_ID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSAGENS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MENSAGENS_USUARIOS_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MENSAGENS_USUARIO_ID",
                table: "MENSAGENS",
                column: "USUARIO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MENSAGENS");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
