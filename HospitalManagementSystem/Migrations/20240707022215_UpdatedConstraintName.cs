using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedConstraintName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_User_OnlyCanHaveApprovedRole",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "UR_User_OnlyCanHaveApprovedRole",
                table: "Users",
                sql: "Role IN ('Admin', 'Doctor', 'Patient')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "UR_User_OnlyCanHaveApprovedRole",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_OnlyCanHaveApprovedRole",
                table: "Users",
                sql: "Role IN ('Admin', 'Doctor', 'Patient')");
        }
    }
}
