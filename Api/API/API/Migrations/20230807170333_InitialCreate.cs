using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Date", "Title" },
                values: new object[,]
                {
                    { 10, "Uknown", new DateTime(1800, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wars" },
                    { 11, "Mankind", new DateTime(1700, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peacetimes" },
                    { 12, "Arthur C. Clarke", new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2001: A Space Odyssey" },
                    { 13, "Uknown", new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book nr 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
