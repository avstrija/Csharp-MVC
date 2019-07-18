﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WordCount.Models;

namespace WordCount.Migrations
{
    [DbContext(typeof(WordCountContext))]
    [Migration("20190625142426_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("WordCount.Models.Note", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("date");

                    b.Property<string>("text")
                        .IsRequired();

                    b.Property<string>("title");

                    b.Property<int>("wordCount");

                    b.HasKey("id");

                    b.ToTable("Note");
                });
#pragma warning restore 612, 618
        }
    }
}