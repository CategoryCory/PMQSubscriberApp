using Microsoft.EntityFrameworkCore.Migrations;

namespace PMQSubscriberApp.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzerias",
                columns: table => new
                {
                    PizzeriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzeriaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    NumberOfLocations = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzerias", x => x.PizzeriaId);
                });

            migrationBuilder.CreateTable(
                name: "PizzeriaContact",
                columns: table => new
                {
                    ContactsContactId = table.Column<int>(type: "int", nullable: false),
                    PizzeriasPizzeriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzeriaContact", x => new { x.ContactsContactId, x.PizzeriasPizzeriaId });
                    table.ForeignKey(
                        name: "FK_PizzeriaContact_Contacts_ContactsContactId",
                        column: x => x.ContactsContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzeriaContact_Pizzerias_PizzeriasPizzeriaId",
                        column: x => x.PizzeriasPizzeriaId,
                        principalTable: "Pizzerias",
                        principalColumn: "PizzeriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LastName",
                table: "Contacts",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_PizzeriaContact_PizzeriasPizzeriaId",
                table: "PizzeriaContact",
                column: "PizzeriasPizzeriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzerias_PizzeriaName",
                table: "Pizzerias",
                column: "PizzeriaName");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzerias_State",
                table: "Pizzerias",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzerias_ZipCode",
                table: "Pizzerias",
                column: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzeriaContact");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Pizzerias");
        }
    }
}
