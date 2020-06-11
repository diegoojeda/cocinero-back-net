using Microsoft.EntityFrameworkCore.Migrations;

namespace ElCocineroBack.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorKey = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorKey);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientKey = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientKey);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeKey = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeKey);
                    table.ForeignKey(
                        name: "FK_Recipes_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<string>(type: "TEXT", nullable: false),
                    IngredientId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    IngredientStateIngredientKey = table.Column<string>(type: "TEXT", nullable: true),
                    RecipeStateRecipeKey = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientStateIngredientKey",
                        column: x => x.IngredientStateIngredientKey,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeStateRecipeKey",
                        column: x => x.RecipeStateRecipeKey,
                        principalTable: "Recipes",
                        principalColumn: "RecipeKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientKey", "Name" },
                values: new object[] { "0c03d869-6b0c-46f7-b28f-10d62bee5129", "Harina" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientKey", "Name" },
                values: new object[] { "8c1cce22-c1cf-4297-95c1-15f9bd754d7b", "Pollo" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientKey", "Name" },
                values: new object[] { "ce9c1969-a011-45a6-9fc4-79c79c321e73", "Manzanas" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientKey", "Name" },
                values: new object[] { "d55b6100-6ab1-48d1-b781-94d7316285e6", "Platanos" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientStateIngredientKey",
                table: "RecipeIngredients",
                column: "IngredientStateIngredientKey");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeStateRecipeKey",
                table: "RecipeIngredients",
                column: "RecipeStateRecipeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AuthorId",
                table: "Recipes",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
