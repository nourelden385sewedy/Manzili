using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manzili.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    BlockedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlockReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Government = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeliveryNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BlockReason", "BlockedUntil", "CreatedAt", "Email", "FullName", "IsBlocked", "PasswordHash", "PhoneNumber", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@gmail.com", "Ahmed Hassan", false, "AQAAAAIAAYagAAAAEE+FGwkFi1MXWXXsZn2Y0aNr1uIsFWCMWf8XLfMNHNf2am3nuc1GaM3aP9sLyYjPCA==", "01012345678", "Buyer", new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, null, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.adel@yahoo.com", "Mariam Adel", false, "AQAAAAIAAYagAAAAELr9KQGPzaNJMzShxn3PALJLqozABvn7zKcFr98/VpMXvR1JRSHsSoKPHuWGqlEIjw==", "01098765432", "Provider", new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, null, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "omarkhaled@outlook.com", "Omar Khaled", false, "AQAAAAIAAYagAAAAEIDJRDwXzGsWMcIjgZedQAmFx7rfmK8d5fowqOUMN9Qa3xWJd43qvMbZUxkJcTWxiA==", "01029305160", "Buyer", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, null, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.nabil@gmail.com", "Sarah Nabil", false, "AQAAAAIAAYagAAAAEKZ9cBbvDydFdIIu/ub20qGZQCmq/ZIrMfJ4afsH9akfgFwVHb7VNgkc2sgx+wx9cg==", "01022223333", "Provider", new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, null, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.m@gmail.com", "Youssef Mahmoud", true, "AQAAAAIAAYagAAAAEBMjtXhcyoDzDLwiwCpdQ8LJzGeifw/jAQYatfYba7leWTQ62TYr3711+W+JIhJGyA==", "01044445555", "Provider", new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, null, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "laila.samir@icloud.com", "Laila Samir", false, "AQAAAAIAAYagAAAAEDnhSLR5NvBXwBBWtyGeibpSUNCT3PMR7RvDHFQhU4fAEJ5SGovtllt5lPskEjStzA==", "01055556666", "Buyer", new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
