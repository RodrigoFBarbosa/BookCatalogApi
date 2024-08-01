using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class InsertBookData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Books\" (\"Name\", \"Author\", \"Year\",  \"Description\", \"RegistrationDate\", \"CategoryId\") " +
                "VALUES ('Pequeno Príncipe','Antoine de Saint-Exupéry',1943,'Livro edição de luxo Capa Dura com ilustrações',now(), 10)");

            migrationBuilder.Sql("INSERT INTO \"Books\" (\"Name\", \"Author\", \"Year\",  \"Description\", \"RegistrationDate\", \"CategoryId\") " +
                "VALUES ('Fahrenheit 451','Ray Bradbury',1953,'Livro de romance e ficção cientifica',now(), 11)");

            migrationBuilder.Sql("INSERT INTO \"Books\" (\"Name\", \"Author\", \"Year\",  \"Description\", \"RegistrationDate\", \"CategoryId\") " +
                "VALUES ('Capitães de Areia','Jorge Amado',1937,'Obra brasileira que retrata menores abandonas que cresceram nas ruas de salvador',now(), 12)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Books\"");
        }
    }
}
