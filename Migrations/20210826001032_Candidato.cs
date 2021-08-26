using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gama_aec.Migrations
{
    public partial class Candidato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profissoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profissoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "candidatos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    cpf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    genero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    profissao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    estadoCivil = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    cidade = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    profissao_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidatos", x => x.id);
                    table.ForeignKey(
                        name: "FK_candidatos_profissoes_profissao_id",
                        column: x => x.profissao_id,
                        principalTable: "profissoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidatos_profissao_id",
                table: "candidatos",
                column: "profissao_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidatos");

            migrationBuilder.DropTable(
                name: "profissoes");
        }
    }
}
