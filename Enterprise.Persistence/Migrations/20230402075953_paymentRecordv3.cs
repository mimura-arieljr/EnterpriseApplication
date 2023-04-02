using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enterprise.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class paymentRecordv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PagIbigNo",
                table: "PaymentRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhilHealthNo",
                table: "PaymentRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagIbigNo",
                table: "PaymentRecords");

            migrationBuilder.DropColumn(
                name: "PhilHealthNo",
                table: "PaymentRecords");
        }
    }
}
