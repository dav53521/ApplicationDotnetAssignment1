using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseColumnLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patients",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Admins",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 10000,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "21 Test Test Drive Sydney NSW", "0491570110" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "Description",
                value: "Covid-19");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11000,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "12 Ultimo Road Sydney NSW", "0491570156" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20000,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "10 place street Sydney NSW", "0491570157" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20001,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "11 real street Melbourne VIC", "0491570006" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20002,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "10 Nowhere Drive Sydney NSW", "0491570158" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20003,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "11 A real street ave Sydney NSW", "0491570159" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Admins",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 10000,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "21 Test Test", "0411111111" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "Description",
                value: "Test");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11000,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "12 A real street ave", "0411111111" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20000,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "10 A real street ave", "0411111111" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20001,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "11 A real street ave", "0411111111" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20002,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "11 A real street ave", "0411111111" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20003,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "11 A real street ave", "0411111111" });
        }
    }
}
