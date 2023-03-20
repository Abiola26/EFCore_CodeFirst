﻿// <auto-generated />
using System;
using EFCore_CodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore_CodeFirst.Db.Migrations
{
    [DbContext(typeof(CodeFirstDemoContext))]
    [Migration("20230319182447_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCore_CodeFirst.Db.Models.InstrumentType", b =>
                {
                    b.Property<int>("InstrumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentTypeId");

                    b.ToTable("InstrumentTypes");

                    b.HasData(
                        new
                        {
                            InstrumentTypeId = 1,
                            Name = "Acoustic Guitar"
                        },
                        new
                        {
                            InstrumentTypeId = 2,
                            Name = "Electric Guitar"
                        },
                        new
                        {
                            InstrumentTypeId = 3,
                            Name = "Drums"
                        },
                        new
                        {
                            InstrumentTypeId = 4,
                            Name = "Bass"
                        },
                        new
                        {
                            InstrumentTypeId = 5,
                            Name = "Keyboard"
                        });
                });

            modelBuilder.Entity("EFCore_CodeFirst.Db.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"), 1L, 1);

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EFCore_CodeFirst.Db.Models.PlayerInstrument", b =>
                {
                    b.Property<int>("PlayerInstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerInstrumentId"), 1L, 1);

                    b.Property<int>("InstrumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("PlayerInstrumentId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerInstruments");
                });

            modelBuilder.Entity("EFCore_CodeFirst.Db.Models.PlayerInstrument", b =>
                {
                    b.HasOne("EFCore_CodeFirst.Db.Models.Player", null)
                        .WithMany("Instruments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore_CodeFirst.Db.Models.Player", b =>
                {
                    b.Navigation("Instruments");
                });
#pragma warning restore 612, 618
        }
    }
}
