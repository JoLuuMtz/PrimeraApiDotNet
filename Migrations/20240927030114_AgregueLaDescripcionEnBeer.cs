using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mi_primera_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AgregueLaDescripcionEnBeer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Beers");
        }
    }
}
