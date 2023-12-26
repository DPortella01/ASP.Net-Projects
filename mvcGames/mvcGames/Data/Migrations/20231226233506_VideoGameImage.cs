using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcGames.Data.Migrations
{
    public partial class VideoGameImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "VideoGame",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_ImageId",
                table: "VideoGame",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGame_Files_ImageId",
                table: "VideoGame",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGame_Files_ImageId",
                table: "VideoGame");

            migrationBuilder.DropIndex(
                name: "IX_VideoGame_ImageId",
                table: "VideoGame");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "VideoGame");
        }
    }
}
