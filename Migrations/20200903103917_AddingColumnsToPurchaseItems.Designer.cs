﻿// <auto-generated />
using System;
using ALSaray.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ALSaray.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20200903103917_AddingColumnsToPurchaseItems")]
    partial class AddingColumnsToPurchaseItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ALSaray.Models.Category", b =>
                {
                    b.Property<int>("catId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("catName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("catId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("ALSaray.Models.MyDbAcct", b =>
                {
                    b.Property<int>("acctId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("acctName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("acctId");

                    b.ToTable("myDbAccts");
                });

            modelBuilder.Entity("ALSaray.Models.Products", b =>
                {
                    b.Property<int>("prodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("catId")
                        .HasColumnType("int");

                    b.Property<string>("prodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("prodId");

                    b.HasIndex("catId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ALSaray.Models.Purchase", b =>
                {
                    b.Property<long>("purchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int?>("accId")
                        .HasColumnType("int");

                    b.Property<float?>("gtotal")
                        .HasColumnType("real");

                    b.Property<string>("pMethod")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("purchNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("purchId");

                    b.HasIndex("accId");

                    b.ToTable("purchases");
                });

            modelBuilder.Entity("ALSaray.Models.PurchaseItems", b =>
                {
                    b.Property<long>("purchItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<float?>("Total")
                        .HasColumnType("real");

                    b.Property<int?>("prodId")
                        .HasColumnType("int");

                    b.Property<long?>("purchId")
                        .HasColumnType("bigint");

                    b.HasKey("purchItemId");

                    b.HasIndex("prodId");

                    b.HasIndex("purchId");

                    b.ToTable("purchaseItems");
                });

            modelBuilder.Entity("ALSaray.Models.Products", b =>
                {
                    b.HasOne("ALSaray.Models.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("catId");
                });

            modelBuilder.Entity("ALSaray.Models.Purchase", b =>
                {
                    b.HasOne("ALSaray.Models.MyDbAcct", "dbAcct")
                        .WithMany()
                        .HasForeignKey("accId");
                });

            modelBuilder.Entity("ALSaray.Models.PurchaseItems", b =>
                {
                    b.HasOne("ALSaray.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("prodId");

                    b.HasOne("ALSaray.Models.Purchase", "Purchase")
                        .WithMany()
                        .HasForeignKey("purchId");
                });
#pragma warning restore 612, 618
        }
    }
}
