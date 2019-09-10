using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPessoa.Repositorio.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "apipessoa");

            migrationBuilder.CreateTable(
                name: "PESSOA",
                schema: "apipessoa",
                columns: table => new
                {
                    ID_PESSOA = table.Column<Guid>(nullable: false),
                    NM_NOME = table.Column<string>(nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    CD_SEXO = table.Column<int>(nullable: false),
                    TX_CPF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.ID_PESSOA);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PESSOA",
                schema: "apipessoa");
        }
    }
}
