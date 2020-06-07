using Microsoft.EntityFrameworkCore.Migrations;

namespace ElCocineroBack.Migrations
{
    public partial class AddRecipeIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientStateIngredientKey",
                table: "RecipeIngredients",
                column: "IngredientStateIngredientKey");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeStateRecipeKey",
                table: "RecipeIngredients",
                column: "RecipeStateRecipeKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");
        }
    }
}
