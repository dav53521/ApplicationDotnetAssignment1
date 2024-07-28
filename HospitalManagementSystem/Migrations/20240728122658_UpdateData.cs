using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 10000);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11000);

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[] { 30000, "21 Test Test Drive Sydney NSW", "Test@Test.com", "David Sorrell", "123", "0491570110" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10000,
                column: "DoctorId",
                value: 10000);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "DoctorId",
                value: 10000);

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[] { 10000, "12 Ultimo Road Sydney NSW", "Test@email.com", "John Deer", "test", "0491570156" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20000,
                column: "AssignedDoctorId",
                value: 10000);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20002,
                column: "AssignedDoctorId",
                value: 10000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 30000);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10000);

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[] { 10000, "21 Test Test Drive Sydney NSW", "Test@Test.com", "David Sorrell", "123", "0491570110" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10000,
                column: "DoctorId",
                value: 11000);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10001,
                column: "DoctorId",
                value: 11000);

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[] { 11000, "12 Ultimo Road Sydney NSW", "Test@email.com", "John Deer", "test", "0491570156" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20000,
                column: "AssignedDoctorId",
                value: 11000);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20002,
                column: "AssignedDoctorId",
                value: 11000);
        }
    }
}
