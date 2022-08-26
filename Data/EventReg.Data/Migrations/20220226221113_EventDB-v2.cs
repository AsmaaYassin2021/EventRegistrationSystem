using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventReg.Data.Migrations
{
    public partial class EventDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 2, 27, 5, 11, 13, 561, DateTimeKind.Local).AddTicks(5142), new DateTime(2022, 3, 3, 0, 11, 13, 560, DateTimeKind.Local).AddTicks(6238) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 3, 6, 0, 11, 13, 561, DateTimeKind.Local).AddTicks(5532), new DateTime(2022, 3, 3, 0, 11, 13, 561, DateTimeKind.Local).AddTicks(5522) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 3, 2, 5, 11, 13, 561, DateTimeKind.Local).AddTicks(5543), new DateTime(2022, 3, 1, 0, 11, 13, 561, DateTimeKind.Local).AddTicks(5541) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 3, 2, 5, 11, 13, 561, DateTimeKind.Local).AddTicks(5545), new DateTime(2022, 3, 2, 0, 11, 13, 561, DateTimeKind.Local).AddTicks(5544) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 2, 28, 5, 11, 13, 561, DateTimeKind.Local).AddTicks(5548), new DateTime(2022, 2, 28, 0, 11, 13, 561, DateTimeKind.Local).AddTicks(5547) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 2, 26, 5, 11, 13, 561, DateTimeKind.Local).AddTicks(5550), new DateTime(2022, 2, 26, 0, 11, 13, 561, DateTimeKind.Local).AddTicks(5549) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 2, 27, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5358), new DateTime(2022, 3, 2, 23, 32, 27, 289, DateTimeKind.Local).AddTicks(7791) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 3, 5, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5804), new DateTime(2022, 3, 2, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5792) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 3, 2, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5813), new DateTime(2022, 2, 28, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5812) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 3, 2, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5815), new DateTime(2022, 3, 1, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5814) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 2, 28, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5818), new DateTime(2022, 2, 27, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5817) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2022, 2, 26, 4, 32, 27, 290, DateTimeKind.Local).AddTicks(5821), new DateTime(2022, 2, 25, 23, 32, 27, 290, DateTimeKind.Local).AddTicks(5819) });
        }
    }
}
