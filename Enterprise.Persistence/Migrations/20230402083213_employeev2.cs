using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enterprise.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class employeev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PagIbigNo",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhilHealthNo",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagIbigNo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhilHealthNo",
                table: "Employees");
        }
    }
}
