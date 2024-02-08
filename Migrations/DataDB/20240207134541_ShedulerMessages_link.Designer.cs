﻿// <auto-generated />
using System;
using Bot.AdminPanel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bot.AdminPanel.Migrations.DataDB
{
    [DbContext(typeof(DataDBContext))]
    [Migration("20240207134541_ShedulerMessages_link")]
    partial class ShedulerMessages_link
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bot.AdminPanel.Data.Types.ScheduledMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Periodicity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("SubscriberId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.ToTable("ScheduledMessages");
                });

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

                    b.Property<int?>("CityCode")
                        .HasColumnType("int");

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

                    b.Property<DateTime>("ReceivedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReplyMessageContent")
                        .HasColumnType("longtext");

                    b.Property<string>("Update")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TelegramUpdates");
                });

            modelBuilder.Entity("Bot.AdminPanel.Data.Types.ScheduledMessage", b =>
                {
                    b.HasOne("Bot.AdminPanel.Data.Types.Subscriber", null)
                        .WithMany("ScheduledMessages")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bot.AdminPanel.Data.Types.Subscriber", b =>
                {
                    b.Navigation("ScheduledMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
