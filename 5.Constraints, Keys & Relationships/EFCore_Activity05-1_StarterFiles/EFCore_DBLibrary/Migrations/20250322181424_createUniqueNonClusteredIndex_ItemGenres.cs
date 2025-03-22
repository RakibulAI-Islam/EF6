using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DBLibrary.Migrations
{
    public partial class createUniqueNonClusteredIndex_ItemGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemGenres_ItemId",
                table: "ItemGenres");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGenres_ItemId_GenreId",
                table: "ItemGenres",
                columns: new[] { "ItemId", "GenreId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemGenres_ItemId_GenreId",
                table: "ItemGenres");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGenres_ItemId",
                table: "ItemGenres",
                column: "ItemId");
        }
    }
}
