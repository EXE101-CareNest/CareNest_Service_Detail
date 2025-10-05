using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareNest_Service_Detail.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceCategoryId",
                table: "Services_Details",
                newName: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Services_Details",
                newName: "ServiceCategoryId");
        }
    }
}
