using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enterprise.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editPaymentRecordV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OvertimeHours",
                table: "PaymentRecords",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OvertimeHours",
                table: "PaymentRecords");
        }
    }
}
