using Microsoft.EntityFrameworkCore.Migrations;

namespace User_Registration_Sample.Migrations
{
    public partial class CreateDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NIC = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
