using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enterprise.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editStudentLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentLoan",
                table: "Employees",
                newName: "Loan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Loan",
                table: "Employees",
                newName: "StudentLoan");
        }
    }
}
