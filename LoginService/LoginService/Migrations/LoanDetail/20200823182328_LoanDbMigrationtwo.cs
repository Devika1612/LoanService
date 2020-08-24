using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginService.Migrations.LoanDetail
{
    public partial class LoanDbMigrationtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LoanAmount",
                table: "LoanDetails",
                type: "varchar(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LoanAmount",
                table: "LoanDetails",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(7)");
        }
    }
}
