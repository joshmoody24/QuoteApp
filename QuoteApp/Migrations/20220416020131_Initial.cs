using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuoteApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuoteText = table.Column<string>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    Citation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quotes_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotes_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 1, "Spencer", "Hilton" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 2, "Albert", "Einstein" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 3, "J.K.", "Rowling" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 4, "Russel", "Nelson" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 5, "Elon", "Musk" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 6, "Randall", "Munroe" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 7, "Amulek", null });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[] { 1, "Joy" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[] { 2, "Funny" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[] { 3, "Coding" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[] { 4, "Despicable" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[] { 5, "Political" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "AuthorId", "Citation", "Date", "QuoteText", "SubjectId" },
                values: new object[] { 2, 6, "https://xkcd.com/1942/", new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "I disagree strongly with whatever work this quote is attached to", null });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "AuthorId", "Citation", "Date", "QuoteText", "SubjectId" },
                values: new object[] { 3, 7, "Alma 11:33", null, "Yea", null });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "AuthorId", "Citation", "Date", "QuoteText", "SubjectId" },
                values: new object[] { 1, 1, "Heard it in 403 last semester", new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CREATE TABLE Yeet", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AuthorId",
                table: "Quotes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_SubjectId",
                table: "Quotes",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
