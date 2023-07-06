﻿// <auto-generated />
using System;
using Failure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Failure.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230420201553_FourthMigration")]
    partial class FourthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Failure.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<bool>("ForSale")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Medium")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PostId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Failure.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Failure.Models.Post", b =>
                {
                    b.HasOne("Failure.Models.User", "Creator")
                        .WithMany("AllPostsCreated")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Failure.Models.User", b =>
                {
                    b.HasOne("Failure.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Failure.Models.User", b =>
                {
                    b.Navigation("AllPostsCreated");
                });
#pragma warning restore 612, 618
        }
    }
}
