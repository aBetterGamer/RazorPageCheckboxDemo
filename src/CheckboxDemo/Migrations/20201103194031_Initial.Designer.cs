﻿// <auto-generated />
using CheckboxDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CheckboxDemo.Migrations
{
    [DbContext(typeof(CheckboxDemoDbContext))]
    [Migration("20201103194031_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheckboxDemo.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Children");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsSelected = true,
                            Name = "First Child"
                        },
                        new
                        {
                            Id = 2,
                            IsSelected = false,
                            Name = "Second Child"
                        },
                        new
                        {
                            Id = 3,
                            IsSelected = true,
                            Name = "Third Child"
                        },
                        new
                        {
                            Id = 4,
                            IsSelected = false,
                            Name = "Fourth Child"
                        },
                        new
                        {
                            Id = 5,
                            IsSelected = true,
                            Name = "Fifth Child"
                        },
                        new
                        {
                            Id = 6,
                            IsSelected = false,
                            Name = "Sixth Child"
                        });
                });

            modelBuilder.Entity("CheckboxDemo.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "First Parent"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Second Parent"
                        });
                });

            modelBuilder.Entity("CheckboxDemo.ParentChild", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("ParentChild");

                    b.HasData(
                        new
                        {
                            ParentId = 1,
                            ChildId = 1
                        },
                        new
                        {
                            ParentId = 1,
                            ChildId = 2
                        },
                        new
                        {
                            ParentId = 1,
                            ChildId = 3
                        },
                        new
                        {
                            ParentId = 2,
                            ChildId = 4
                        },
                        new
                        {
                            ParentId = 2,
                            ChildId = 5
                        },
                        new
                        {
                            ParentId = 2,
                            ChildId = 6
                        });
                });

            modelBuilder.Entity("CheckboxDemo.ParentChild", b =>
                {
                    b.HasOne("CheckboxDemo.Child", "Child")
                        .WithMany("Parents")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheckboxDemo.Parent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
