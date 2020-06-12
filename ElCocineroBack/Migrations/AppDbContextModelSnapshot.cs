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

            modelBuilder.Entity("ElCocineroBack.Domain.RecipeIngredient.RecipeIngredientState", b =>
                {
                    b.Property<string>("RecipeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("IngredientId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("ElCocineroBack.Domain.Recipe.RecipeState", b =>
                {
                    b.HasOne("ElCocineroBack.Domain.Author.AuthorState", "Author")
                        .WithMany("Recipes")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("ElCocineroBack.Domain.RecipeIngredient.RecipeIngredientState", b =>
                {
                    b.HasOne("ElCocineroBack.Domain.Ingredient.IngredientState", "Ingredient")
                        .WithMany("Recipes")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElCocineroBack.Domain.Recipe.RecipeState", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
