using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNotasFinal.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoSistemaNotasFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlunoIdade = table.Column<int>(type: "int", nullable: false),
                    AlunoSerie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "Bimestre",
                columns: table => new
                {
                    BimestreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnoBimestre = table.Column<int>(type: "int", nullable: false),
                    BimestreDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bimestre", x => x.BimestreId);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    BimestreId = table.Column<int>(type: "int", nullable: false),
                    Nota1 = table.Column<double>(type: "float", nullable: false),
                    Nota2 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_Nota_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Bimestre_BimestreId",
                        column: x => x.BimestreId,
                        principalTable: "Bimestre",
                        principalColumn: "BimestreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormacaoProfessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempoTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                    table.ForeignKey(
                        name: "FK_Professor_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nota_AlunoId",
                table: "Nota",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_BimestreId",
                table: "Nota",
                column: "BimestreId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_MateriaId",
                table: "Nota",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_MateriaId",
                table: "Professor",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Bimestre");

            migrationBuilder.DropTable(
                name: "Materia");
        }
    }
}
