using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipatorId",
                table: "EventsRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipatorId",
                table: "EventsRegistrations");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Events");
        }
    }
}
