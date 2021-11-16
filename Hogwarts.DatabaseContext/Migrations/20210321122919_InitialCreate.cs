using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.DatabaseContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestLogin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: true),
                    Identification = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HomeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestLogin_Home_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Home",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestLogin_HomeId",
                table: "RequestLogin",
                column: "HomeId");

            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "Name" },
                values: new object[] { "Gryffindor" });

            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "Name" },
                values: new object[] { "Hufflepuff"});

            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "Name" },
                values: new object[] { "Ravenclaw"});

            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "Name" },
                values: new object[] { "Slytherin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLogin");

            migrationBuilder.DropTable(
                name: "Home");
        }
    }
}
