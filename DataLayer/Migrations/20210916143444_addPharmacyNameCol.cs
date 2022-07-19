using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class addPharmacyNameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Year",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 751, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UnitType",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 752, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagMaster",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 749, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagDetail",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 750, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryMaster",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 488, DateTimeKind.Local).AddTicks(383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 748, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryDetail",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 749, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.AddColumn<string>(
                name: "PharmacyName",
                table: "DataBaseConfigurations",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Company",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 753, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Branch",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 751, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillMaster",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 747, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillDetail",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 748, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Barcode",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 752, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AccountCategory",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 485, DateTimeKind.Local).AddTicks(323),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 745, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Account",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 484, DateTimeKind.Local).AddTicks(342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 744, DateTimeKind.Local).AddTicks(5974));

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
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 34, 43, 501, DateTimeKind.Local).AddTicks(9858));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyName",
                table: "DataBaseConfigurations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Year",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 751, DateTimeKind.Local).AddTicks(5788),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UnitType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 752, DateTimeKind.Local).AddTicks(5762),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 491, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 749, DateTimeKind.Local).AddTicks(5840),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "PriceTagDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 750, DateTimeKind.Local).AddTicks(5814),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 748, DateTimeKind.Local).AddTicks(5867),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 488, DateTimeKind.Local).AddTicks(383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "EntryDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 749, DateTimeKind.Local).AddTicks(5840),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 489, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 753, DateTimeKind.Local).AddTicks(5733),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 751, DateTimeKind.Local).AddTicks(5788),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 490, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 747, DateTimeKind.Local).AddTicks(5894),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BillDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 748, DateTimeKind.Local).AddTicks(5867),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 487, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Barcode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 752, DateTimeKind.Local).AddTicks(5762),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 492, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AccountCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 745, DateTimeKind.Local).AddTicks(5947),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 485, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 744, DateTimeKind.Local).AddTicks(5974),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 9, 16, 17, 34, 43, 484, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "ArticaleCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "ArticaleCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "UnitType",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Year",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707));
        }
    }
}
