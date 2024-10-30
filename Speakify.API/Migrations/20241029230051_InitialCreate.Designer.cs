﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Speakify.API.Data;

#nullable disable

namespace Speakify.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241029230051_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Speakify.Shared.Entities.TimeEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtOtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TimeEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
