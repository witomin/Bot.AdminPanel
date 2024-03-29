﻿// <auto-generated />
using System;
using Bot.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bot.AdminPanel.Migrations.DataDB
{
    [DbContext(typeof(DataDBContext))]
    partial class DataDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bot.Data.Core.Types.ScheduledMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("HangfireJobId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MessageType")
                        .HasColumnType("int");

                    b.Property<int>("Periodicity")
                        .HasColumnType("int");

                    b.Property<long>("SubscriberId")
                        .HasColumnType("bigint");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.ToTable("ScheduledMessages");
                });

            modelBuilder.Entity("Bot.Data.Core.Types.Subscriber", b =>
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

            modelBuilder.Entity("Bot.Data.Core.Types.TelegramUpdate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ReceivedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReplyMessageContent")
                        .HasColumnType("longtext");

                    b.Property<long>("SubscriberId")
                        .HasColumnType("bigint");

                    b.Property<string>("Update")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.ToTable("TelegramUpdates");
                });

            modelBuilder.Entity("Bot.Data.Core.Types.ScheduledMessage", b =>
                {
                    b.HasOne("Bot.Data.Core.Types.Subscriber", null)
                        .WithMany("ScheduledMessages")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bot.Data.Core.Types.TelegramUpdate", b =>
                {
                    b.HasOne("Bot.Data.Core.Types.Subscriber", null)
                        .WithMany("TelegramUpdates")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bot.Data.Core.Types.Subscriber", b =>
                {
                    b.Navigation("ScheduledMessages");

                    b.Navigation("TelegramUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}
