using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsAppSenderApi.Migrations
{
    /// <inheritdoc />
    public partial class AddVipColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVIP",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVIP",
                table: "Customers");
        }
    }
}
