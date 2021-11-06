using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAPI.DAL.Migrations
{
    public partial class username_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_username",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_username",
                table: "user",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_username",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_username",
                table: "user",
                column: "username");
        }
    }
}
