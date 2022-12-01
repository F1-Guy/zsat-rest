using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zsat.Migrations
{
    public partial class drinkkark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_AppUserId",
                table: "Attendances");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CardId",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardUserCardId",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_CardUserCardId",
                table: "Attendances",
                column: "CardUserCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_AppUserId",
                table: "Attendances",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_CardUsers_CardUserCardId",
                table: "Attendances",
                column: "CardUserCardId",
                principalTable: "CardUsers",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_AppUserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_CardUsers_CardUserCardId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_CardUserCardId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "CardUserCardId",
                table: "Attendances");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_AppUserId",
                table: "Attendances",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
