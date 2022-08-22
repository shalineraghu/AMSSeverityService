using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditSeverityModule.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaveDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(nullable: true),
                    projectManagerName = table.Column<string>(nullable: true),
                    applicationOwnerName = table.Column<string>(nullable: true),
                    auditType = table.Column<string>(nullable: true),
                    auditDate = table.Column<string>(nullable: true),
                    auditId = table.Column<int>(nullable: false),
                    projectExecutionStatus = table.Column<string>(nullable: true),
                    remedialActionDuration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveDetail", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaveDetail");
        }
    }
}
