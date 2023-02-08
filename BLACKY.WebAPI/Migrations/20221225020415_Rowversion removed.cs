using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLACKY.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Rowversionremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ExpenseTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ExpenseTypes",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
