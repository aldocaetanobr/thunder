using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inicio = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Vencimento = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Conclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tarefas_usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarefas_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tarefas_usuarios_tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tarefas_usuarios_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_conclusao",
                table: "tarefas",
                column: "Conclusao");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_CreatedAt",
                table: "tarefas",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_inicio",
                table: "tarefas",
                column: "Inicio");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_status",
                table: "tarefas",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_titulo",
                table: "tarefas",
                column: "Titulo");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_UpdatedAt",
                table: "tarefas",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_vencimento",
                table: "tarefas",
                column: "Vencimento");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_usuarios_CreatedAt",
                table: "tarefas_usuarios",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_usuarios_TarefaId",
                table: "tarefas_usuarios",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_usuarios_UpdatedAt",
                table: "tarefas_usuarios",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_usuarios_UsuarioId",
                table: "tarefas_usuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_ativo",
                table: "usuarios",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_CreatedAt",
                table: "usuarios",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_name",
                table: "usuarios",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_UpdatedAt",
                table: "usuarios",
                column: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tarefas_usuarios");

            migrationBuilder.DropTable(
                name: "tarefas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
