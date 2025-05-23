using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clase11.Migrations
{
    /// <inheritdoc />
    public partial class created_by_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Students",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }
    }
}
