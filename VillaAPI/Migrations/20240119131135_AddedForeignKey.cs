using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaId",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2301), 0 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 2,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2302), 0 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 3,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2303), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villa_VillaId",
                table: "VillaNumbers",
                column: "VillaId",
                principalTable: "Villa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villa_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 19, 15, 37, 42, 968, DateTimeKind.Local).AddTicks(4611));
        }
    }
}
