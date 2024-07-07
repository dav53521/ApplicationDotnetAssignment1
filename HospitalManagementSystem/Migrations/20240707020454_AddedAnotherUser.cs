using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnotherUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 2, "10 This is a real street, Sydney, NSW", "Ben@carrierpigeonmail.com", "Ben", "ben", "0411111110", "Doctor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
