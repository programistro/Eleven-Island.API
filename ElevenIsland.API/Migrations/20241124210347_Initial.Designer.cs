﻿// <auto-generated />
using System;
using ElevenIsland.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElevenIsland.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241124210347_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ElevenIsland.Core.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductAttributeId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ProductidProduct")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductidProduct");

                    b.ToTable("Attribute");
                });

            modelBuilder.Entity("ElevenIsland.Core.AttributeValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AttributeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.ToTable("AttributeValue");
                });

            modelBuilder.Entity("ElevenIsland.Core.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ElevenIsland.Core.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProductidProduct")
                        .HasColumnType("TEXT");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductidProduct");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("ElevenIsland.Core.Product", b =>
                {
                    b.Property<Guid>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idProduct");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ElevenIsland.Core.Attribute", b =>
                {
                    b.HasOne("ElevenIsland.Core.Product", null)
                        .WithMany("Attributes")
                        .HasForeignKey("ProductidProduct");
                });

            modelBuilder.Entity("ElevenIsland.Core.AttributeValue", b =>
                {
                    b.HasOne("ElevenIsland.Core.Attribute", null)
                        .WithMany("AttributeValues")
                        .HasForeignKey("AttributeId");
                });

            modelBuilder.Entity("ElevenIsland.Core.Image", b =>
                {
                    b.HasOne("ElevenIsland.Core.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductidProduct");
                });

            modelBuilder.Entity("ElevenIsland.Core.Attribute", b =>
                {
                    b.Navigation("AttributeValues");
                });

            modelBuilder.Entity("ElevenIsland.Core.Product", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
