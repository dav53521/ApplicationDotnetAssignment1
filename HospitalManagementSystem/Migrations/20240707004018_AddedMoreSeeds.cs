using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_LoginDetailsId",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "LoginDetailsId",
                table: "Admins",
                newName: "LoginDetailsID");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_LoginDetailsId",
                table: "Admins",
                newName: "IX_Admins_LoginDetailsID");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "LoginDetailsID" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_LoginDetailsID",
                table: "Admins",
                column: "LoginDetailsID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_LoginDetailsID",
                table: "Admins");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "LoginDetailsID",
                table: "Admins",
                newName: "LoginDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_LoginDetailsID",
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
    }
}
