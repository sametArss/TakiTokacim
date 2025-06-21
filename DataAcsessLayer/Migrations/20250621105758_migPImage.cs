using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migPImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImage2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImage3",
                table: "Products");
        }
    }
}
