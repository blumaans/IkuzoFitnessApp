using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkuzoFitnessApp.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 15, 20, 36, 39, 830, DateTimeKind.Local).AddTicks(9329), new DateTime(2024, 1, 15, 20, 36, 39, 830, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 15, 20, 36, 39, 830, DateTimeKind.Local).AddTicks(9350), new DateTime(2024, 1, 15, 20, 36, 39, 830, DateTimeKind.Local).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 15, 20, 36, 39, 830, DateTimeKind.Local).AddTicks(9352), new DateTime(2024, 1, 15, 20, 36, 39, 830, DateTimeKind.Local).AddTicks(9352) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "PaymentAmount", "PaymentType", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(6135), new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(6136), null, "Credit/Debit Card", "System" },
                    { 2, "System", new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(6138), new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(6139), null, "Apple Pay", "System" },
                    { 3, "System", new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(6140), new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(6140), null, "PayPal", "System" }
                });

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(5769), new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(5789), new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(5791), new DateTime(2024, 1, 15, 20, 33, 51, 942, DateTimeKind.Local).AddTicks(5792) });
        }
    }
}
