using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zsat.Migrations
{
    public partial class checkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Attendances",
                newName: "CheckIn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Attendances",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Attendances",
                newName: "Timestamp");
        }
    }
}
