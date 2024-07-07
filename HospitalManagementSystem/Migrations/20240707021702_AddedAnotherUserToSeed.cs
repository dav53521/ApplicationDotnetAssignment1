using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnotherUserToSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 3, "2 This is a real street, Sydney, NSW", "Jack@owlmail.com", "Jack", "password", "0411111100", "Patient" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
