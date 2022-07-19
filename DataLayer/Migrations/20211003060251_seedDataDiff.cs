using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class seedDataDiff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Year",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 872, DateTimeKind.Local).AddTicks(7425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UnitType",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 873, DateTimeKind.Local).AddTicks(7400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagMaster",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 869, DateTimeKind.Local).AddTicks(7518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagDetail",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 870, DateTimeKind.Local).AddTicks(7481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryMaster",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 867, DateTimeKind.Local).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 488, DateTimeKind.Local).AddTicks(383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryDetail",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 868, DateTimeKind.Local).AddTicks(7517),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Company",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 875, DateTimeKind.Local).AddTicks(7337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Branch",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 871, DateTimeKind.Local).AddTicks(7456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillMaster",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 866, DateTimeKind.Local).AddTicks(7571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillDetail",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 867, DateTimeKind.Local).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Barcode",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 874, DateTimeKind.Local).AddTicks(7366),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AccountCategory",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 863, DateTimeKind.Local).AddTicks(7648),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 485, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Account",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 861, DateTimeKind.Local).AddTicks(7701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 484, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722), "مندوب عام" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 8, 8, new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722), "مصروف الصيدلية" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 9, 10, new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722), "رأس مال الصيدلية" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 10, 11, new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722), "بضاعة أول مدة" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 9, 10, new DateTime(2021, 10, 3, 9, 2, 49, 898, DateTimeKind.Local).AddTicks(6722), "بضاعة الإهلاك" });

            migrationBuilder.UpdateData(
                table: "ArticaleCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "ArticaleCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 894, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 879, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Year",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 9, 2, 49, 878, DateTimeKind.Local).AddTicks(7256));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Year",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 872, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UnitType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 873, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 869, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 870, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 488, DateTimeKind.Local).AddTicks(383),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 867, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 868, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 875, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 871, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 866, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 867, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Barcode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 874, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AccountCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 485, DateTimeKind.Local).AddTicks(323),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 863, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 484, DateTimeKind.Local).AddTicks(342),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 10, 3, 9, 2, 49, 861, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858), "مندوب شركة أفاميا" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 6, 6, new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858), "مندوب شركة ألفا" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 8, 8, new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858), "مصروف الصيدلية" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 9, 10, new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858), "رأس مال الصيدلية" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AccountGeneralId", "CategoryId", "CreationDate", "Name" },
                values: new object[] { 10, 11, new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858), "بضاعة أول مدة" });

            migrationBuilder.UpdateData(
                table: "ArticaleCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "ArticaleCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 499, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Year",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 494, DateTimeKind.Local).AddTicks(350));
        }
    }
}
