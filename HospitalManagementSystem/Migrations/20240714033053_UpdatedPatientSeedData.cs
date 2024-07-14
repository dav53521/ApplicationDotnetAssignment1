using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPatientSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 21,
                column: "AssignedDoctorId",
                value: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 21,
                column: "AssignedDoctorId",
                value: null);
        }
    }
}
