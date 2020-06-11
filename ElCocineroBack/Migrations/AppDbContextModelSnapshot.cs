﻿// <auto-generated />
using ElCocineroBack.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElCocineroBack.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10");

            modelBuilder.Entity("ElCocineroBack.Domain.Author.AuthorState", b =>
                {
                    b.Property<string>("AuthorKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorKey");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ElCocineroBack.Domain.Ingredient.IngredientState", b =>
                {
                    b.Property<string>("IngredientKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("IngredientKey");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientKey = "0c03d869-6b0c-46f7-b28f-10d62bee5129",
                            Name = "Harina"
                        },
                        new
                        {
                            IngredientKey = "8c1cce22-c1cf-4297-95c1-15f9bd754d7b",
                            Name = "Pollo"
                        },
                        new
                        {
                            IngredientKey = "ce9c1969-a011-45a6-9fc4-79c79c321e73",
                            Name = "Manzanas"
                        },
                        new
                        {
                            IngredientKey = "d55b6100-6ab1-48d1-b781-94d7316285e6",
                            Name = "Platanos"
                        });
                });

            modelBuilder.Entity("ElCocineroBack.Domain.Recipe.RecipeIngredient.RecipeIngredientState", b =>
                {
                    b.Property<string>("RecipeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("IngredientId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IngredientStateIngredientKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeStateRecipeKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientStateIngredientKey");

                    b.HasIndex("RecipeStateRecipeKey");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("ElCocineroBack.Domain.Recipe.RecipeState", b =>
                {
                    b.Property<string>("RecipeKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("RecipeKey");

                    b.HasIndex("AuthorId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("ElCocineroBack.Domain.Recipe.RecipeIngredient.RecipeIngredientState", b =>
                {
                    b.HasOne("ElCocineroBack.Domain.Ingredient.IngredientState", null)
                        .WithMany("Recipes")
                        .HasForeignKey("IngredientStateIngredientKey");

                    b.HasOne("ElCocineroBack.Domain.Recipe.RecipeState", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeStateRecipeKey");
                });

            modelBuilder.Entity("ElCocineroBack.Domain.Recipe.RecipeState", b =>
                {
                    b.HasOne("ElCocineroBack.Domain.Author.AuthorState", "Author")
                        .WithMany("Recipes")
                        .HasForeignKey("AuthorId");
                });
#pragma warning restore 612, 618
        }
    }
}
