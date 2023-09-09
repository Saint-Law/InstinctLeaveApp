using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstinctLeaveApp.Migrations
{
    public partial class ColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefautDays",
                table: "LeaveTypes",
                newName: "DefaultDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultDays",
                table: "LeaveTypes",
                newName: "DefautDays");
        }
    }
}
