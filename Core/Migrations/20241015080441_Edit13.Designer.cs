﻿// <auto-generated />
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241015080441_Edit13")]
    partial class Edit13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Card_Number")
                        .HasColumnType("int");

                    b.Property<string>("Card_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("admin");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Card_Number = 123,
                            Card_Password = "hello",
                            name = "jon"
                        });
                });

            modelBuilder.Entity("Core.Models.Chef", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Card_Number")
                        .HasColumnType("int");

                    b.Property<string>("Card_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("chefs");
                });

            modelBuilder.Entity("Core.Models.Manager", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Card_Number")
                        .HasColumnType("int");

                    b.Property<string>("Card_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("managers");
                });

            modelBuilder.Entity("Core.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("m_catigory_id")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("m_catigory_id");

                    b.ToTable("meals");
                });

            modelBuilder.Entity("Core.Models.MealCatigory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("meal_catigories");
                });

            modelBuilder.Entity("Core.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Core.Models.Order_Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_Meals");
                });

            modelBuilder.Entity("Core.Models.chef_meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("chef_id")
                        .HasColumnType("int");

                    b.Property<int>("meal_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("chef_id");

                    b.HasIndex("meal_id");

                    b.ToTable("Chefs_meals");
                });

            modelBuilder.Entity("Core.Models.Meal", b =>
                {
                    b.HasOne("Core.Models.MealCatigory", "mealcatigory")
                        .WithMany("Meals")
                        .HasForeignKey("m_catigory_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("mealcatigory");
                });

            modelBuilder.Entity("Core.Models.Order_Meal", b =>
                {
                    b.HasOne("Core.Models.Meal", "meal")
                        .WithMany("orders_meal")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Models.Order", "order")
                        .WithMany("orders_meal")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("meal");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Core.Models.chef_meal", b =>
                {
                    b.HasOne("Core.Models.Chef", "chef")
                        .WithMany("chef_meals")
                        .HasForeignKey("chef_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Models.Meal", "meal")
                        .WithMany("meal_chefs")
                        .HasForeignKey("meal_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("chef");

                    b.Navigation("meal");
                });

            modelBuilder.Entity("Core.Models.Chef", b =>
                {
                    b.Navigation("chef_meals");
                });

            modelBuilder.Entity("Core.Models.Meal", b =>
                {
                    b.Navigation("meal_chefs");

                    b.Navigation("orders_meal");
                });

            modelBuilder.Entity("Core.Models.MealCatigory", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Core.Models.Order", b =>
                {
                    b.Navigation("orders_meal");
                });
#pragma warning restore 612, 618
        }
    }
}
