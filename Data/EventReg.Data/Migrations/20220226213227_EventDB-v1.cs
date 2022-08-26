using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventReg.Data.Migrations
{
    public partial class EventDBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 254, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TicketNumber = table.Column<string>(nullable: true),
                    EventId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registration_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Description", "EndDateTime", "EventType", "Name", "StartDateTime" },
                values: new object[,]
                {
                    { 1L, "Software", new DateTime(2022, 2, 27, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5358), "Event", "Programming", new DateTime(2022, 3, 2, 23, 32, 27, 289, DateTimeKind.Local).AddTicks(7791) },
                    { 2L, "Hardware", new DateTime(2022, 3, 5, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5804), "Event", "Network", new DateTime(2022, 3, 2, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5792) },
                    { 3L, "Software", new DateTime(2022, 3, 2, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5813), "Event", "Devpos", new DateTime(2022, 2, 28, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5812) },
                    { 4L, "Software", new DateTime(2022, 3, 2, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5815), "Event", "C#", new DateTime(2022, 3, 1, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5814) },
                    { 5L, "Software", new DateTime(2022, 2, 28, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5818), "Event", "Java", new DateTime(2022, 2, 27, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5817) },
                    { 6L, "Software", new DateTime(2022, 2, 26, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5821), "Event", "Python", new DateTime(2022, 2, 25, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5819) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 1, "Admin", "Admin12345", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Registration_EventId",
                table: "Registration",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
