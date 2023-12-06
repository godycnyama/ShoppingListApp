﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingListApp.Infrastructure.Persistence.Context;

#nullable disable

namespace ShoppingListApp.Infrastructure.Migrations
{
    [DbContext(typeof(ShoppingListAppDataContext))]
    [Migration("20231205172039_shoppinglist2")]
    partial class shoppinglist2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingListApp.Domain.Entities.Account", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ShoppingListApp.Domain.Entities.ShoppingItem", b =>
                {
                    b.Property<int>("ShoppingItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingItemID"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhotoFileName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingListID")
                        .HasColumnType("int");

                    b.HasKey("ShoppingItemID");

                    b.HasIndex("ShoppingListID");

                    b.ToTable("ShoppingItems");
                });

            modelBuilder.Entity("ShoppingListApp.Domain.Entities.ShoppingList", b =>
                {
                    b.Property<int>("ShoppingListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingListID"));

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("ShoppingListID");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("ShoppingListApp.Domain.Entities.ShoppingItem", b =>
                {
                    b.HasOne("ShoppingListApp.Domain.Entities.ShoppingList", null)
                        .WithMany("ShoppingItems")
                        .HasForeignKey("ShoppingListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingListApp.Domain.Entities.ShoppingList", b =>
                {
                    b.Navigation("ShoppingItems");
                });
#pragma warning restore 612, 618
        }
    }
}
