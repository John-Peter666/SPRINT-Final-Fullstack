using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprint_3.Migrations
{
    public partial class AdicionarTabelasRestantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "disciplinas",
                columns: table => new
                {
                    idedisciplina = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

                    nomemateria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),

                    cargahoraria = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),

                    ementa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplinas", x => x.idedisciplina);
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.CreateTable(
                name: "professores",
                columns: table => new
                {
                    ideprofessor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

                    nomeprofessor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),

                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),

                    telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professores", x => x.ideprofessor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

                    login = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),

                    senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),

                    role = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.CreateTable(
                name: "turmas",
                columns: table => new
                {
                    idturma = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

                    ideprofessor = table.Column<long>(type: "bigint", nullable: false),

                    idedisciplina = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turmas", x => x.idturma);

                    table.ForeignKey(
                        name: "FK_turmas_professores_ideprofessor",
                        column: x => x.ideprofessor,
                        principalTable: "professores",
                        principalColumn: "ideprofessor",
                        onDelete: ReferentialAction.Cascade
                    );

                    table.ForeignKey(
                        name: "FK_turmas_disciplinas_idedisciplina",
                        column: x => x.idedisciplina,
                        principalTable: "disciplinas",
                        principalColumn: "idedisciplina",
                        onDelete: ReferentialAction.Cascade
                    );
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.CreateTable(
                name: "matriculas_disciplinas",
                columns: table => new
                {
                    idMatricula = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

                    idealuno = table.Column<long>(type: "bigint", nullable: false),

                    ideturma = table.Column<long>(type: "bigint", nullable: false),

                    nota = table.Column<decimal>(type: "decimal(65,30)", nullable: true),

                    frequencia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculas_disciplinas", x => x.idMatricula);

                    table.ForeignKey(
                        name: "FK_matriculas_turmas_ideturma",
                        column: x => x.ideturma,
                        principalTable: "turmas",
                        principalColumn: "idturma",
                        onDelete: ReferentialAction.Cascade
                    );

                    table.ForeignKey(
                        name: "FK_matriculas_alunos_idealuno",
                        column: x => x.idealuno,
                        principalTable: "alunos",
                        principalColumn: "idealuno",
                        onDelete: ReferentialAction.Cascade
                    );
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.CreateIndex(
                name: "IX_turmas_ideprofessor",
                table: "turmas",
                column: "ideprofessor"
            );

            migrationBuilder.CreateIndex(
                name: "IX_turmas_idedisciplina",
                table: "turmas",
                column: "idedisciplina"
            );

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_disciplinas_ideturma",
                table: "matriculas_disciplinas",
                column: "ideturma"
            );

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_disciplinas_idealuno",
                table: "matriculas_disciplinas",
                column: "idealuno"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matriculas_disciplinas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "turmas");

            migrationBuilder.DropTable(
                name: "professores");

            migrationBuilder.DropTable(
                name: "disciplinas");
        }
    }
}