﻿// <auto-generated />
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyAppDb))]
    partial class MyAppDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TravelBookingApp.Model.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BlogCategory")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("BlogContent")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NoOfSubscriptions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BlogsTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlogCategory = "Nature",
                            BlogContent = "Lorem Neque Neque porro quisquam Neque porro quisquam est qui Neque porro quisquam est quiest quiporro quisquam est qui",
                            BlogTitle = "Neque porro quisquam est qui",
                            NoOfSubscriptions = 10
                        },
                        new
                        {
                            Id = 2,
                            BlogCategory = "Politics",
                            BlogContent = "Lorem Neque Neque porro quisquam Neque porro quisquam est qui Neque porro quisquam est quiest quiporro quisquam est qui",
                            BlogTitle = "Porro quisqu ameque  est qui",
                            NoOfSubscriptions = 30
                        },
                        new
                        {
                            Id = 3,
                            BlogCategory = "Weather",
                            BlogContent = "Lorem Neque Neque porro quisquam Neque porro quisquam est qui Neque porro quisquam est quiest quiporro quisquam est qui",
                            BlogTitle = "Eest qui eque porro quisquam ",
                            NoOfSubscriptions = 20
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
