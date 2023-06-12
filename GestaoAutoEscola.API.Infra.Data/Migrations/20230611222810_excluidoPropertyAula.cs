using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoAutoEscola.API.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class excluidoPropertyAula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Aulas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "Aulas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "Aulas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
