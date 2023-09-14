﻿// <auto-generated />
using System;
using Banking_WebAPI_Practice_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Banking_WebAPI_Practice_Project.Migrations
{
    [DbContext(typeof(Banking_WebAPI_Practice_ProjectContext))]
    [Migration("20230914130933_need")]
    partial class need
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Banking_WebAPI_Practice_Project.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(11,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(3,2)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Banking_WebAPI_Practice_Project.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CardCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastTransactionDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Banking_WebAPI_Practice_Project.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("NewBalance")
                        .HasColumnType("decimal(11,2)");

                    b.Property<decimal>("PreviousBalance")
                        .HasColumnType("decimal(11,2)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Banking_WebAPI_Practice_Project.Models.Account", b =>
                {
                    b.HasOne("Banking_WebAPI_Practice_Project.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Banking_WebAPI_Practice_Project.Models.Transaction", b =>
                {
                    b.HasOne("Banking_WebAPI_Practice_Project.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
