using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialPulse.Repository.Migrations
{
    public partial class FriendConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_RequesterId",
                table: "Friends");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Friends",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "RequesterId", "AddresseeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Friends",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_RequesterId",
                table: "Friends",
                column: "RequesterId");
        }
    }
}
