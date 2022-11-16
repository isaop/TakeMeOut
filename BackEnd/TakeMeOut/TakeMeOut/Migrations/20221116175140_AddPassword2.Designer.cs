﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakeMeOut.Database;

#nullable disable

namespace TakeMeOut.Migrations
{
    [DbContext(typeof(TakeMeOutContext))]
    [Migration("20221116175140_AddPassword2")]
    partial class AddPassword2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TakeMeOut.Database.Models.BusinessAccount", b =>
                {
                    b.Property<int>("IdBa")
                        .HasColumnType("int")
                        .HasColumnName("idBA");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<float?>("ContactNo")
                        .HasColumnType("real")
                        .HasColumnName("contact_No");

                    b.Property<string>("Country")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("country");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<int?>("IdVenue")
                        .HasColumnType("int")
                        .HasColumnName("idVenue");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBa")
                        .HasName("PK__Business__9DB8DE827480C09C");

                    b.HasIndex("IdVenue");

                    b.HasIndex(new[] { "Name" }, "UQ__Business__72E12F1B1F6650F8")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.HasIndex(new[] { "Email" }, "UQ__Business__AB6E6164FDCFEFBA")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("Business_Account", (string)null);
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Category", b =>
                {
                    b.Property<int>("IdCat")
                        .HasColumnType("int")
                        .HasColumnName("idCat");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdCat")
                        .HasName("PK__Category__398E4045C9ECC572");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Event", b =>
                {
                    b.Property<int>("IdEvent")
                        .HasColumnType("int")
                        .HasColumnName("idEvent");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("description");

                    b.Property<string>("EventName")
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("event_name");

                    b.Property<int?>("IdBa")
                        .HasColumnType("int")
                        .HasColumnName("idBA");

                    b.Property<int>("IdCat")
                        .HasColumnType("int")
                        .HasColumnName("idCat");

                    b.Property<int?>("IdEstat")
                        .HasColumnType("int")
                        .HasColumnName("idEstat");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.Property<int>("IdVenue")
                        .HasColumnType("int")
                        .HasColumnName("idVenue");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time")
                        .HasColumnName("time");

                    b.HasKey("IdEvent")
                        .HasName("PK__Event__B7EA7D76B3559F2E");

                    b.HasIndex("IdBa");

                    b.HasIndex("IdCat");

                    b.HasIndex("IdEstat");

                    b.HasIndex("IdUser");

                    b.HasIndex("IdVenue");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.EventStatus", b =>
                {
                    b.Property<int>("IdEstat")
                        .HasColumnType("int")
                        .HasColumnName("idEstat");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdEstat")
                        .HasName("PK__Event_St__6214BC210DE7C9D3");

                    b.ToTable("Event_Status", (string)null);
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("idOrder");

                    b.Property<int?>("IdEvent")
                        .HasColumnType("int")
                        .HasColumnName("idEvent");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdOrder")
                        .HasName("PK__Orders__C8AAF6FF2034C34B");

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdUser");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Payment", b =>
                {
                    b.Property<int>("IdPayment")
                        .HasColumnType("int")
                        .HasColumnName("idPayment");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.HasKey("IdPayment")
                        .HasName("PK__Payments__F22D4A45104198F7");

                    b.HasIndex("IdUser");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Review", b =>
                {
                    b.Property<int>("IdReview")
                        .HasColumnType("int")
                        .HasColumnName("idReview");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("comment");

                    b.Property<int?>("IdEvent")
                        .HasColumnType("int")
                        .HasColumnName("idEvent");

                    b.Property<int?>("IdPayment")
                        .HasColumnType("int")
                        .HasColumnName("idPayment");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.HasKey("IdReview")
                        .HasName("PK__Reviews__04F7FE10A1EC1D3C");

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdPayment");

                    b.HasIndex("IdUser");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("country");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("PhoneNo")
                        .HasColumnType("real")
                        .HasColumnName("phone_No");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("surname");

                    b.HasKey("IdUser")
                        .HasName("PK__Users__3717C9824B671996");

                    b.HasIndex(new[] { "Email" }, "UQ__Users__AB6E61644354BEF8")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.UserAction", b =>
                {
                    b.Property<int>("IdUserAction")
                        .HasColumnType("int")
                        .HasColumnName("idUserAction");

                    b.Property<string>("ActionName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("action_Name");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("description");

                    b.Property<int?>("IdEvent")
                        .HasColumnType("int")
                        .HasColumnName("idEvent");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.HasKey("IdUserAction")
                        .HasName("PK__user_act__7AE31280D64B2F5E");

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdUser");

                    b.ToTable("user_action", (string)null);
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Venue", b =>
                {
                    b.Property<int>("IdVenue")
                        .HasColumnType("int")
                        .HasColumnName("idVenue");

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("address");

                    b.Property<float?>("ContactNo")
                        .HasColumnType("real")
                        .HasColumnName("contact_No");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("UniqueIden")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("unique_iden");

                    b.HasKey("IdVenue")
                        .HasName("PK__Venue__077D5E693F07C0A4");

                    b.ToTable("Venue", (string)null);
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.BusinessAccount", b =>
                {
                    b.HasOne("TakeMeOut.Database.Models.Venue", "IdVenueNavigation")
                        .WithMany("BusinessAccounts")
                        .HasForeignKey("IdVenue")
                        .HasConstraintName("FK__Business___idVen__29572725");

                    b.Navigation("IdVenueNavigation");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Event", b =>
                {
                    b.HasOne("TakeMeOut.Database.Models.BusinessAccount", "IdBaNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdBa")
                        .HasConstraintName("FK__Event__idBA__3B75D760");

                    b.HasOne("TakeMeOut.Database.Models.Category", "IdCatNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdCat")
                        .IsRequired()
                        .HasConstraintName("FK__Event__idCat__3C69FB99");

                    b.HasOne("TakeMeOut.Database.Models.EventStatus", "IdEstatNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdEstat")
                        .HasConstraintName("FK__Event__idEstat__398D8EEE");

                    b.HasOne("TakeMeOut.Database.Models.User", "IdUserNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Event__idUser__3A81B327");

                    b.HasOne("TakeMeOut.Database.Models.Venue", "IdVenueNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdVenue")
                        .IsRequired()
                        .HasConstraintName("FK__Event__idVenue__38996AB5");

                    b.Navigation("IdBaNavigation");

                    b.Navigation("IdCatNavigation");

                    b.Navigation("IdEstatNavigation");

                    b.Navigation("IdUserNavigation");

                    b.Navigation("IdVenueNavigation");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Order", b =>
                {
                    b.HasOne("TakeMeOut.Database.Models.Event", "IdEventNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("FK__Orders__idEvent__48CFD27E");

                    b.HasOne("TakeMeOut.Database.Models.User", "IdUserNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Orders__idUser__47DBAE45");

                    b.Navigation("IdEventNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Payment", b =>
                {
                    b.HasOne("TakeMeOut.Database.Models.User", "IdUserNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Payments__idUser__34C8D9D1");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Review", b =>
                {
                    b.HasOne("TakeMeOut.Database.Models.Event", "IdEventNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("FK__Reviews__idEvent__3F466844");

                    b.HasOne("TakeMeOut.Database.Models.Payment", "IdPaymentNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdPayment")
                        .HasConstraintName("FK__Reviews__idPayme__412EB0B6");

                    b.HasOne("TakeMeOut.Database.Models.User", "IdUserNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Reviews__idUser__403A8C7D");

                    b.Navigation("IdEventNavigation");

                    b.Navigation("IdPaymentNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.UserAction", b =>
                {
                    b.HasOne("TakeMeOut.Database.Models.Event", "IdEventNavigation")
                        .WithMany("UserActions")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("FK__user_acti__idEve__440B1D61");

                    b.HasOne("TakeMeOut.Database.Models.User", "IdUserNavigation")
                        .WithMany("UserActions")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__user_acti__idUse__44FF419A");

                    b.Navigation("IdEventNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.BusinessAccount", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Event", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("UserActions");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.EventStatus", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Payment", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.User", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Orders");

                    b.Navigation("Payments");

                    b.Navigation("Reviews");

                    b.Navigation("UserActions");
                });

            modelBuilder.Entity("TakeMeOut.Database.Models.Venue", b =>
                {
                    b.Navigation("BusinessAccounts");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
