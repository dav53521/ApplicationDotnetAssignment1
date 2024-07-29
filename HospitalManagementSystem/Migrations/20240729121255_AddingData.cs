using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedDoctorId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_AssignedDoctorId",
                        column: x => x.AssignedDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 30000, "21 Test Test Drive Sydney NSW", "Test@Test.com", "David Sorrell", "123", "0491570110" },
                    { 30001, "21 Test Test Drive Sydney NSW", "Test@Test.com", "David Person", "test", "0491570110" },
                    { 30002, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" },
                    { 30003, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" },
                    { 30004, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" },
                    { 30005, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" },
                    { 30006, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" },
                    { 30007, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" },
                    { 30008, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" },
                    { 30009, "21 Test Test Drive Sydney NSW", "Person@gmail2.com", "David Person", "321", "0491570110" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 10000, "12 Ultimo Road Sydney NSW", "Test@email.com", "John Deer", "test", "0491570156" },
                    { 10001, "10 Ultimo Road Sydney NSW", "Doctor@snaimail.com", "Mr Doctor", "Password", "0491570158" },
                    { 10002, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10003, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10004, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10005, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10006, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10007, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10008, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10009, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "AssignedDoctorId", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 20001, "11 real street Melbourne VIC", null, "Test@email.com", "Jane Deer", "test", "0491570006" },
                    { 20003, "11 A real street ave Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "123", "0491570159" },
                    { 20004, "11 A real street ave Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "123", "0491570159" },
                    { 20005, "11 A real street ave Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "123", "0491570159" },
                    { 20006, "11 A real street ave Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "123", "0491570159" },
                    { 20007, "11 A real street ave Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "123", "0491570159" },
                    { 20008, "11 A real street ave Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "123", "0491570159" },
                    { 20009, "11 A real street ave Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "123", "0491570159" },
                    { 20000, "10 place street Sydney NSW", 10000, "Test@email.com", "Jill Deer", "123", "0491570157" },
                    { 20002, "10 Nowhere Drive Sydney NSW", 10002, "Test@email.com", "Person Person", "123", "0491570158" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Description", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 10000, "Cold", 10000, 20000 },
                    { 10001, "Covid-19", 10002, 20002 },
                    { 10002, "A cough", 10002, 20002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AssignedDoctorId",
                table: "Patients",
                column: "AssignedDoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
