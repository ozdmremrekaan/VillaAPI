using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillaNumbers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 14, 59, 30, 783, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 14, 59, 30, 783, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 14, 59, 30, 783, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 14, 59, 30, 783, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 14, 59, 30, 783, DateTimeKind.Local).AddTicks(9196));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillaNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "VillaNo", "CreatedDate", "SpecialDetails", "UpdatedDate", "VillaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2301), "Small Room", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2302), "Giant Room", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, new DateTime(2024, 1, 19, 16, 11, 35, 244, DateTimeKind.Local).AddTicks(2303), "Big room", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }
    }
}
