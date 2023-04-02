using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enterprise.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editPaymentRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentLoanContribution",
                table: "PaymentRecords",
                newName: "LoanContribution");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanContribution",
                table: "PaymentRecords",
                newName: "StudentLoanContribution");
        }
    }
}
