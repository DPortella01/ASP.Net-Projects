using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcDriverWithAuth.Data.Migrations
{
    public partial class makeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakeCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_MakeId",
                table: "Driver",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Make_MakeId",
                table: "Driver",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Make_MakeId",
                table: "Driver");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropIndex(
                name: "IX_Driver_MakeId",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Driver");
        }
    }
}
