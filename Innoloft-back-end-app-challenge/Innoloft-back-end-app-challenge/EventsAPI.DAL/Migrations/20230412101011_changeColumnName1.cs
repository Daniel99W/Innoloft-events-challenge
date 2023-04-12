using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnName1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsRegistrations_Users_UserId",
                table: "EventsRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventsRegistrations_UserId",
                table: "EventsRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_Events_UserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EventsRegistrations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_EventsRegistrations_ParticipatorId",
                table: "EventsRegistrations",
                column: "ParticipatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId",
                table: "Events",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_CreatorId",
                table: "Events",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsRegistrations_Users_ParticipatorId",
                table: "EventsRegistrations",
                column: "ParticipatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_CreatorId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsRegistrations_Users_ParticipatorId",
                table: "EventsRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventsRegistrations_ParticipatorId",
                table: "EventsRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatorId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EventsRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventsRegistrations_UserId",
                table: "EventsRegistrations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsRegistrations_Users_UserId",
                table: "EventsRegistrations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
