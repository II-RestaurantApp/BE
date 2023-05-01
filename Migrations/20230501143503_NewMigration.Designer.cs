﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantAppBE.DataAccess.Context;

#nullable disable

namespace RestaurantAppBE.Migrations
{
    [DbContext(typeof(RestaurantAppContext))]
    [Migration("20230501143503_NewMigration")]
    partial class NewMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.Comanda", b =>
                {
                    b.Property<int>("ComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComId"));

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("ComId");

                    b.HasIndex("UserId");

                    b.ToTable("Comenzi");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.ComandaItem", b =>
                {
                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("ItemItemId")
                        .HasColumnType("int");

                    b.HasKey("ComandaId", "ItemItemId");

                    b.HasIndex("ItemItemId");

                    b.ToTable("ComandaItem");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.Ingredient", b =>
                {
                    b.Property<int>("IngrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngrId"));

                    b.Property<string>("IngrName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngrId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Gramaj")
                        .HasColumnType("float");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.ItemIngredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("ItemsItemId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId", "ItemsItemId");

                    b.HasIndex("ItemsItemId");

                    b.ToTable("ItemIngredient");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.Comanda", b =>
                {
                    b.HasOne("RestaurantAppBE.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.ComandaItem", b =>
                {
                    b.HasOne("RestaurantAppBE.DataAccess.Models.Comanda", "Comanda")
                        .WithMany("Items")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAppBE.DataAccess.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.ItemIngredient", b =>
                {
                    b.HasOne("RestaurantAppBE.DataAccess.Models.Ingredient", "Ingredient")
                        .WithMany("Item")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAppBE.DataAccess.Models.Item", "Item")
                        .WithMany("Ingrediente")
                        .HasForeignKey("ItemsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.Comanda", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.Ingredient", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("RestaurantAppBE.DataAccess.Models.Item", b =>
                {
                    b.Navigation("Ingrediente");
                });
#pragma warning restore 612, 618
        }
    }
}
