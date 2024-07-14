using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnotherPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Address",
                value: "12 A real street ave");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "AssignedDoctorId", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[] { 22, "11 A real street ave", null, "Test@email.com", "Jane Deer", "Jane", "0411111111" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Address",
                value: "10 A real street ave");
        }
    }
}
