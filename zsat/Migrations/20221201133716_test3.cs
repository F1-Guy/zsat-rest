using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zsat.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_CardUsers_CardUserCardId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "CardUserCardId",
                table: "Attendances",
                newName: "CardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_CardUserCardId",
                table: "Attendances",
                newName: "IX_Attendances_CardUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_CardUsers_CardUserId",
                table: "Attendances",
                column: "CardUserId",
                principalTable: "CardUsers",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_CardUsers_CardUserId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "CardUserId",
                table: "Attendances",
                newName: "CardUserCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_CardUserId",
                table: "Attendances",
                newName: "IX_Attendances_CardUserCardId");

            migrationBuilder.AddColumn<string>(
                name: "CardId",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_CardUsers_CardUserCardId",
                table: "Attendances",
                column: "CardUserCardId",
                principalTable: "CardUsers",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
