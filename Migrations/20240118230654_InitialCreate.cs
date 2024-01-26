using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodris.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SortingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Algorithm = table.Column<string>(type: "TEXT", nullable: false),
                    Input = table.Column<string>(type: "TEXT", nullable: false),
                    Output = table.Column<string>(type: "TEXT", nullable: false),
                    SortDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortingHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SortingHistories");
        }
    }
}
