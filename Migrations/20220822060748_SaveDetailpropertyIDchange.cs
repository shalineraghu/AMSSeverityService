using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditSeverityModule.Migrations
{
    public partial class SaveDetailpropertyIDchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SaveDetail",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "SaveDetail",
                newName: "ID");
        }
    }
}
