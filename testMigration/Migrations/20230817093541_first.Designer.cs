﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testMigration;

#nullable disable

namespace testMigration.Migrations
{
    [DbContext(typeof(AppDBcontext))]
    [Migration("20230817093541_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("testMigration.Tables.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("testMigration.Tables.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StudentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("testMigration.Tables.StudentCourse", b =>
                {
                    b.Property<int>("IdOfStudent")
                        .HasColumnType("int");

                    b.Property<int>("IdOfCourse")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("IdOfStudent", "IdOfCourse");

                    b.HasIndex("IdOfCourse");

                    b.ToTable("studentCourses");
                });

            modelBuilder.Entity("testMigration.Tables.StudentCourse", b =>
                {
                    b.HasOne("testMigration.Tables.Course", "Course")
                        .WithMany()
                        .HasForeignKey("IdOfCourse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testMigration.Tables.Student", "Student")
                        .WithMany()
                        .HasForeignKey("IdOfStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
