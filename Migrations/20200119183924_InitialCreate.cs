using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCRUDBackend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactList",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactDdd = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    ContactPersonId = table.Column<string>(type: "nvarchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactList", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PersonCpf = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    PersonBirthdate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PersonEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PersonContacts = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.PersonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactList");

            migrationBuilder.DropTable(
                name: "PersonDetails");
        }
    }
}
