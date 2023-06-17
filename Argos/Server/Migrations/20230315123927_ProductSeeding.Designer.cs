﻿// <auto-generated />
using Argos.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Argos.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230315123927_ProductSeeding")]
    partial class ProductSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Argos.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Descriere1",
                            ImageUrl = "https://mcdn.elefant.ro/mnresize/350/350/is/product-images/cartero/120e608a/8874/4e34/8c0b/94ec3204b406/120e608a-8874-4e34-8c0b-94ec3204b406_1.jpg",
                            Price = 9.99m,
                            Title = "Carte1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Descriere2",
                            ImageUrl = "https://mcdn.elefant.ro/mnresize/350/350/images/63/2010963/atomic-habits-o-cale-usoara-si-eficienta-de-a-ti-forma-obiceiuri-bune-si-a-scapa-de-cele-proaste_1_fullsize.jpg",
                            Price = 19.99m,
                            Title = "Carte2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Descriere3",
                            ImageUrl = "https://mcdn.elefant.ro/mnresize/350/350/images/90/276490/ugly-love-despre-fata-urata-a-iubirii_1_fullsize.jpg",
                            Price = 29.99m,
                            Title = "Carte3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}