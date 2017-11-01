﻿// <auto-generated />
using CgiQuiz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CgiQuiz.Migrations
{
    [DbContext(typeof(OurDbContext))]
    [Migration("20171101115307_question table")]
    partial class questiontable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CgiQuiz.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerA")
                        .IsRequired();

                    b.Property<string>("AnswerB")
                        .IsRequired();

                    b.Property<string>("AnswerC")
                        .IsRequired();

                    b.Property<string>("AnswerD")
                        .IsRequired();

                    b.Property<string>("CorrectAnswer")
                        .IsRequired();

                    b.Property<string>("QuestionText")
                        .IsRequired();

                    b.HasKey("QuestionID");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("CgiQuiz.Models.UserAccount", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("userAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
