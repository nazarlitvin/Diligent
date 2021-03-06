﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DiligentDarkSide.Data;

namespace DiligentDarkSide.Migrations
{
    [DbContext(typeof(DiligentContext))]
    [Migration("20170523123335_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("DiligentDarkSide.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("Translate");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });
        }
    }
}
