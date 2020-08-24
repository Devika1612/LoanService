using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginService.Migrations.LoanDetail
{
    public partial class LoanDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    LNId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanOwnerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    LoanNumber = table.Column<string>(type: "varchar(5)", nullable: false),
                    LoanAmount = table.Column<string>(type: "varchar(5)", nullable: false),
                    LoanTerm = table.Column<string>(type: "varchar(2)", nullable: false),
                    LoanType = table.Column<string>(type: "varchar(5)", nullable: false),
                    LegalDocuments = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.LNId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanDetails");
        }
    }
}
