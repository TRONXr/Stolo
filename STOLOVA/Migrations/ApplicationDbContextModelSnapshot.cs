﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace STOLOVA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MenuItem", b =>
                {
                    b.Property<string>("DishName")
                        .HasColumnType("text");

                    b.Property<int>("ID")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("DishName");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemId"));

                    b.Property<string>("MenuItemDishName")
                        .HasColumnType("text");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemDishName");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OrderItem", b =>
                {
                    b.HasOne("MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemDishName");

                    b.HasOne("Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
