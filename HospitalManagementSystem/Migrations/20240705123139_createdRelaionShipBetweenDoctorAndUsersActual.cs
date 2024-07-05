using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class createdRelaionShipBetweenDoctorAndUsersActual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssociatedUser",
                table: "Doctors",
                newName: "AssociatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AssociatedUserId",
                table: "Doctors",
                column: "AssociatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_AssociatedUserId",
                table: "Doctors",
                column: "AssociatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_AssociatedUserId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AssociatedUserId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "AssociatedUserId",
                table: "Doctors",
                newName: "AssociatedUser");
        }
    }
}
