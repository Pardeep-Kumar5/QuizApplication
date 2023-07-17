﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizApplicationBackend.Data;

namespace QuizApplicationBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230707052230_participant")]
    partial class participant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizApplicationBackend.Model.ParticipantTable", b =>
                {
                    b.Property<int>("ParticipatntID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUserid")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStarted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("ParticipatntID");

                    b.HasIndex("CreatedByUserid");

                    b.ToTable("participantTables");
                });

            modelBuilder.Entity("QuizApplicationBackend.Model.QuestionTable", b =>
                {
                    b.Property<int>("Question_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParticipantTableParticipatntID")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Question_Id");

                    b.HasIndex("ParticipantTableParticipatntID");

                    b.ToTable("questionTables");
                });

            modelBuilder.Entity("QuizApplicationBackend.Model.RegisterTable", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("RegisterTable");
                });

            modelBuilder.Entity("QuizApplicationBackend.Model.TeacherTable", b =>
                {
                    b.Property<int>("Teacher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Teacher_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Teacher_Id");

                    b.ToTable("teacherTable");
                });

            modelBuilder.Entity("QuizApplicationBackend.Model.ParticipantTable", b =>
                {
                    b.HasOne("QuizApplicationBackend.Model.RegisterTable", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserid");

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("QuizApplicationBackend.Model.QuestionTable", b =>
                {
                    b.HasOne("QuizApplicationBackend.Model.ParticipantTable", null)
                        .WithMany("Questions")
                        .HasForeignKey("ParticipantTableParticipatntID");
                });

            modelBuilder.Entity("QuizApplicationBackend.Model.ParticipantTable", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
