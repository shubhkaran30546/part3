﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using part3.Data;

#nullable disable

namespace part3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240821181741_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("part3.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("part3.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("part3.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("part3.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComputerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("part3.Models.OrderComponent", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComponentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId", "ComponentId");

                    b.HasIndex("ComponentId");

                    b.ToTable("OrderComponents");
                });

            modelBuilder.Entity("part3.Models.Component", b =>
                {
                    b.HasOne("part3.Models.Computer", "Computer")
                        .WithMany("Components")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");
                });

            modelBuilder.Entity("part3.Models.Order", b =>
                {
                    b.HasOne("part3.Models.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("part3.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Computer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("part3.Models.OrderComponent", b =>
                {
                    b.HasOne("part3.Models.Component", "Component")
                        .WithMany("OrderComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("part3.Models.Order", "Order")
                        .WithMany("OrderComponents")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Component");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("part3.Models.Component", b =>
                {
                    b.Navigation("OrderComponents");
                });

            modelBuilder.Entity("part3.Models.Computer", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("part3.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("part3.Models.Order", b =>
                {
                    b.Navigation("OrderComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
