using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class InsertCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\", \"ImageUrl\") VALUES ('Infantil', 'infantil.jpg')");
    migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\", \"ImageUrl\") VALUES ('Ficção', 'ficcao.jpg')");
    migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\", \"ImageUrl\") VALUES ('Romance', 'romance.jpg')");
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("DELETE FROM \"Categories\"");
}
    }
}
