using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinapse.Migrations
{
    /// <inheritdoc />
    public partial class RenomearImageUrlParaImageFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Publicacoes",
                newName: "ImageFileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Publicacoes",
                newName: "ImageUrl");
        }
    }
}
