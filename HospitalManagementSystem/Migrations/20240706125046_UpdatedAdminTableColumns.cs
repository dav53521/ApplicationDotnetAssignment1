using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAdminTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_AssociatedUserId",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "AssociatedUserId",
                table: "Admins",
                newName: "LoginDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_AssociatedUserId",
                table: "Admins",
                newName: "IX_Admins_LoginDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_LoginDetailsId",
                table: "Admins",
                column: "LoginDetailsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_LoginDetailsId",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "LoginDetailsId",
                table: "Admins",
                newName: "AssociatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_LoginDetailsId",
                table: "Admins",
                newName: "IX_Admins_AssociatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_AssociatedUserId",
                table: "Admins",
                column: "AssociatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
