using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V2testTask.Server.Migrations
{
    /// <inheritdoc />
    public partial class PolygonColName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Polygons",
                newName: "polygon_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "polygon_name",
                table: "Polygons",
                newName: "Name");
        }
    }
}
