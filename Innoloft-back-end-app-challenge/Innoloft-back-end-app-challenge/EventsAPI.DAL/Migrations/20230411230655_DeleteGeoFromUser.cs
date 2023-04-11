using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteGeoFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Geos_GeoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GeoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GeoId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeoId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GeoId",
                table: "Users",
                column: "GeoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Geos_GeoId",
                table: "Users",
                column: "GeoId",
                principalTable: "Geos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
