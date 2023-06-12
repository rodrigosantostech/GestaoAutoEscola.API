using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoAutoEscola.API.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class HoraInicioHoraFim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hora",
                table: "Aulas",
                newName: "HoraInicio");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFim",
                table: "Aulas",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFim",
                table: "Aulas");

            migrationBuilder.RenameColumn(
                name: "HoraInicio",
                table: "Aulas",
                newName: "Hora");
        }
    }
}
