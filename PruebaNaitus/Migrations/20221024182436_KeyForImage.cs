using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaNaitus.Migrations
{
    public partial class KeyForImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "Imagenes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagenes",
                table: "Imagenes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagenes",
                table: "Imagenes");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Imagenes");
        }
    }
}
