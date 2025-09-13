using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareNest_Service_Detail.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services_Details",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ServiceCategoryId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    DurationTime = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Discount = table.Column<double>(type: "double precision", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    ImgUrls = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeleteAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services_Details", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services_Details");
        }
    }
}
