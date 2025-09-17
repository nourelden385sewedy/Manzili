using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manzili.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenUserAndPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BuyerId",
                table: "Payments",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_BuyerId",
                table: "Payments",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_BuyerId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BuyerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Payments");
        }
    }
}
