using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationDotnetAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class FinishAddingData : Migration
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
                    { 30000, "21 Test Test Drive Sydney NSW", "David@Test.com", "David Sorrell", "123", "0491570110" },
                    { 30001, "22 Test Test Drive Sydney NSW", "Person@Test.com", "David Person", "Person", "0491570110" },
                    { 30002, "23 Test Test Drive Sydney NSW", "Rubio@gmail2.com", "Norma Rubio", "FInTheChat", "0491570110" },
                    { 30003, "24 Test Test Drive Sydney NSW", "Ifan@gmail2.com", "Ifan Norton", "NortonAntiVirus", "0491570110" },
                    { 30004, "25 Test Test Drive Sydney NSW", "Shaw@gmail2.com", "Sapphire Shaw", "GrimShaw", "0491570110" },
                    { 30005, "26 Test Test Drive Sydney NSW", "Rick@gmail2.com", "Rick Sanchez", "IAmARickAndMortyReference", "0491570110" },
                    { 30006, "27 Test Test Drive Sydney NSW", "Mcclain@gmail2.com", "Eleanor Mcclain", "McclainIsTheName", "0491570110" },
                    { 30007, "28 Test Test Drive Sydney NSW", "Grace@gmail2.com", "Grace O'Connor", "GraceExists", "0491570110" },
                    { 30008, "29 Test Test Drive Sydney NSW", "Ward@gmail2.com", "Evie Ward", "HospitalWard", "0491570110" },
                    { 30009, "30 Test Test Drive Sydney NSW", "Stokes@gmail2.com", "Lorraine Stokes", "StokesExists", "0491570110" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 10000, "12 Ultimo Road Sydney NSW", "Test@email.com", "John Deer", "test", "0491570156" },
                    { 10001, "10 Ultimo Road Sydney NSW", "Doctor@snaimail.com", "Mr Doctor", "Password", "0491570158" },
                    { 10002, "12 Place Street Sydney NSW", "Jack@PigeonMail.com", "Jack Doe", "hello", "0491570151" },
                    { 10003, "14 100% Real Street Sydney NSW", "Jane@fakegmail.com", "Jane Dane", "123Jane", "0491570152" },
                    { 10004, "100 Place Street Sydney NSW", "Jack@PigeonSnailMail.com", "Jack Test", "JackTest", "0491570153" },
                    { 10005, "2 Somewhere Street Sydney NSW", "Florence@PigeonMail.com", "Florence Padilla", "hellohello", "0491570154" },
                    { 10006, "10 A Real Street Sydney NSW", "Jordan@PigeonMail.com", "Riya Jordan", "JordanRules", "0491570155" },
                    { 10007, "13 Place Street Sydney NSW", "Dan@PigeonMail.com", "Dan Peters", "DanSaysHello", "0491570156" },
                    { 10008, "14 Place Street Sydney NSW", "Church@PigeonMail.com", "Jazmine Church", "JazmineJazmine", "0491570157" },
                    { 10009, "15 Place Street Sydney NSW", "Victoria@PigeonMail.com", "Victoria Mckee", "Mckee", "0491570158" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "AssignedDoctorId", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 20001, "11 Real Street Melbourne VIC", null, "Test@email.com", "Jane Deer", "Anonymous", "0491570006" },
                    { 20003, "11 Street Street Sydney NSW", null, "david2017au@gmail.com", "David Sorrell", "MyRealPassword", "0491570159" },
                    { 20005, "13 Street Street Sydney NSW", null, "Walls@gmail2.com", "Subhan Walls", "WallsRule", "0491570159" },
                    { 20007, "15 Street Street Sydney NSW", null, "Clay@gmail2.com", "Connie Clay", "ClayIsTasty", "0491570159" },
                    { 20009, "17 Street Street Sydney NSW", null, "Santana@gmail2.com", "Sam Santana", "InspectorSam", "0491570159" },
                    { 20000, "10 Street Street Sydney NSW", 10000, "Test@email.com", "Jill Deer", "DeerIsMyName", "0491570157" },
                    { 20002, "10 Nowhere Drive Sydney NSW", 10002, "Test@email.com", "Person Person", "Person", "0491570158" },
                    { 20004, "12 Street Street Sydney NSW", 10004, "Goodwin@gmail2.com", "Vinnie Goodwin", "VinnieIsGood", "0491570159" },
                    { 20006, "14 Street Street Sydney NSW", 10006, "Sears@gmail2.com", "Lillie Sears", "Sears", "0491570159" },
                    { 20008, "16 Street Street Sydney NSW", 10008, "Diana@gmail2.com", "Diana Petty", "Petty", "0491570159" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Description", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 10000, "Cold", 10000, 20000 },
                    { 10001, "Something I swear", 10000, 20000 },
                    { 10002, "Covid-19", 10002, 20002 },
                    { 10003, "A cough", 10002, 20002 },
                    { 10004, "Just because", 10004, 20004 },
                    { 10005, "Wanted Email", 10004, 20004 },
                    { 10006, "I was lonely", 10006, 20006 },
                    { 10007, "Dying", 10006, 20006 },
                    { 10008, "yearly checkup", 10008, 20008 },
                    { 10009, "Because Why not", 10008, 20008 }
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
