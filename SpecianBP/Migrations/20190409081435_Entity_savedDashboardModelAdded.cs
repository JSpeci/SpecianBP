using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecianBP.Migrations
{
    public partial class Entity_savedDashboardModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedDashboardModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    JSONparamas = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedDashboardModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedDashboardModel");
        }
    }
}
