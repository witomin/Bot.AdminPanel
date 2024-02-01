﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tools.niap.ru.Data;

#nullable disable

namespace Bot.AdminPanel.Migrations.DataDB
{
    [DbContext(typeof(DataDBContext))]
    [Migration("20240131101905_Add_CityCode")]
    partial class Add_CityCode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bot.AdminPanel.Data.Types.Subscriber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool?>("AddedToAttachmentMenu")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("CanJoinGroups")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("CanReadAllGroupMessages")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("CityCode")
                        .HasColumnType("longtext");

                    b.Property<string>("CompanyName")
                        .HasColumnType("longtext");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsBot")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPremium")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Social")
                        .HasColumnType("longtext");

                    b.Property<bool?>("SupportsInlineQueries")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("Bot.AdminPanel.Data.Types.TelegramUpdate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("MessageContent")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReceivedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReplyMessageContent")
                        .HasColumnType("longtext");

                    b.Property<int>("TelegramUpdateId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TelegramUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}