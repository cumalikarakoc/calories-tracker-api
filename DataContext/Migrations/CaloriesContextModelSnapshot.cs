﻿// <auto-generated />
using System;
using DataContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataContext.Migrations
{
    [DbContext(typeof(CaloriesContext))]
    partial class CaloriesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("DataContext.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name")
                        .HasName("AK_Ingredient_Name");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("DataContext.Models.IngredientMeal", b =>
                {
                    b.Property<int>("IngredientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MealId");

                    b.HasKey("IngredientId", "CreatedAt");

                    b.HasIndex("MealId");

                    b.ToTable("IngredientMeal");
                });

            modelBuilder.Entity("DataContext.Models.IngredientRecipe", b =>
                {
                    b.Property<int>("IngredientId");

                    b.Property<int>("RecipeId");

                    b.Property<int>("Quantity");

                    b.HasKey("IngredientId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("IngredientRecipe");
                });

            modelBuilder.Entity("DataContext.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("DataContext.Models.MealRecipe", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MealId");

                    b.HasKey("RecipeId", "CreatedAt");

                    b.HasIndex("MealId");

                    b.ToTable("MealRecipe");
                });

            modelBuilder.Entity("DataContext.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name")
                        .HasName("AK_Recipe_Name");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("DataContext.Models.IngredientMeal", b =>
                {
                    b.HasOne("DataContext.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataContext.Models.Meal", "Meal")
                        .WithMany("Meals")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataContext.Models.IngredientRecipe", b =>
                {
                    b.HasOne("DataContext.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataContext.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataContext.Models.MealRecipe", b =>
                {
                    b.HasOne("DataContext.Models.Meal", "Meal")
                        .WithMany("Recipes")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataContext.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
