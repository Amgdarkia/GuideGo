﻿// <auto-generated />
using System;
using GuideGoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuideGoAPI.Migrations
{
    [DbContext(typeof(GuideContext))]
    [Migration("20250211182628_AddReviewsTable")]
    partial class AddReviewsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GuideGoAPI.Entities.Guide", b =>
                {
                    b.Property<int>("GuideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuideId"));

                    b.Property<decimal?>("AverageRating")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCar")
                        .HasColumnType("bit");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuideId");

                    b.ToTable("Guides", (string)null);
                });

            modelBuilder.Entity("GuideGoAPI.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GuideId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TouristId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("GuideId");

                    b.HasIndex("TouristId");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("GuideGoAPI.Entities.Tourist", b =>
                {
                    b.Property<int>("TouristId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TouristId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("TouristId");

                    b.ToTable("Tourists");
                });

            modelBuilder.Entity("GuideGoAPI.Entities.Review", b =>
                {
                    b.HasOne("GuideGoAPI.Entities.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuideGoAPI.Entities.Tourist", "Tourist")
                        .WithMany()
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");

                    b.Navigation("Tourist");
                });
#pragma warning restore 612, 618
        }
    }
}
