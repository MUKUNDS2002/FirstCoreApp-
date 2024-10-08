using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnDobInManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Management");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DOB",
                table: "Management",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Management",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Management");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Management");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Management",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
