using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CheeseMVC.Data;

namespace CheeseMVC.Migrations
{
    [DbContext(typeof(CheeseDbContext))]
    [Migration("20170413210415_AddMenu")]
    partial class AddMenu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheeseMVC.Models.Cheese", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CatagoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("CatagoryID");

                    b.ToTable("Cheeses");
                });

            modelBuilder.Entity("CheeseMVC.Models.CheeseCatagory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Catagories");
                });

            modelBuilder.Entity("CheeseMVC.Models.CheeseMenu", b =>
                {
                    b.Property<int>("CheeseID");

                    b.Property<int>("MenuID");

                    b.Property<int?>("CheeseMenuCheeseID");

                    b.Property<int?>("CheeseMenuMenuID");

                    b.HasKey("CheeseID", "MenuID");

                    b.HasIndex("CheeseID");

                    b.HasIndex("MenuID");

                    b.HasIndex("CheeseMenuCheeseID", "CheeseMenuMenuID");

                    b.ToTable("CheeseMenus");
                });

            modelBuilder.Entity("CheeseMVC.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CheeseMVC.Models.Cheese", b =>
                {
                    b.HasOne("CheeseMVC.Models.CheeseCatagory", "Catagory")
                        .WithMany("Cheeses")
                        .HasForeignKey("CatagoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CheeseMVC.Models.CheeseMenu", b =>
                {
                    b.HasOne("CheeseMVC.Models.Cheese", "Cheese")
                        .WithMany("CheeseMenu")
                        .HasForeignKey("CheeseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CheeseMVC.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CheeseMVC.Models.CheeseMenu")
                        .WithMany("CheeseMenus")
                        .HasForeignKey("CheeseMenuCheeseID", "CheeseMenuMenuID");
                });
        }
    }
}
