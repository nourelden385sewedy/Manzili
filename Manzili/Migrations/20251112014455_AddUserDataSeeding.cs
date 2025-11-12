using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manzili.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BlockReason", "BlockedUntil", "CreatedAt", "UpdatedAt", "Email", "FullName", "IsBlocked", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@gmail.com", "Ahmed Hassan", false, "AQAAAAIAAYagAAAAEOSomiuxubMBJd0b5zXoknncaNtP/RAQaI0WXKeFr/Y6IUj0KtkekAaIVBcXuCVKcw==", "01012345678", "Buyer" },
                    { 2, null, null, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.adel@yahoo.com", "Mariam Adel", false, "AQAAAAIAAYagAAAAEI6LEv2N2bN7hLwOk4bNssWmJWtVtsxmLTVbV7BfjhP9edO+HeZpT8/uP5nJaL0Zuw==", "01098765432", "Provider" },
                    { 3, null, null, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "omarkhaled@outlook.com", "Omar Khaled", false, "AQAAAAIAAYagAAAAEJgr4+Tct67j8lvvaKSFativH7UxHpBNTqqiKXYbGu38c3rnoyYVY95FKKK7Xak/qw==", "01029305160", "Buyer" },
                    { 4, null, null, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.nabil@gmail.com", "Sarah Nabil", false, "AQAAAAIAAYagAAAAELYaREqWkrIFh6BXmAArd01j3bX0u9t9vzcNNYbrYcWPOeDjh426NzplDJODTAELBw==", "01022223333", "Provider" },
                    { 5, null, null, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.m@gmail.com", "Youssef Mahmoud", true, "AQAAAAIAAYagAAAAEBWwjjjUJO352Z7FseYUi1iJRsrh0c7uTS7rjfyEimExmhH+z8wXSK+oqenCPoClKw==", "01044445555", "Provider" },
                    { 6, null, null, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "laila.samir@icloud.com", "Laila Samir", false, "AQAAAAIAAYagAAAAELYFzPVNGLj6Pxk1hHPP9twcePfSf9lov8Qzg/SVG2a4Hkg6ryXquePXtWdmWKzzRg==", "01055556666", "Buyer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
