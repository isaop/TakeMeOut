﻿// <auto-generated />
using System;
using BackEnd.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(TakeMeOutDbContext))]
    [Migration("20221218225049_AddedUserRefreshToken")]
    partial class AddedUserRefreshToken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEnd.Models.BusinessAccount", b =>
                {
                    b.Property<int?>("IdBusinessAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idBusinessAccount");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdBusinessAccount"));

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("contactNumber");

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2500)")
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
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.HasKey("IdBusinessAccount")
                        .HasName("PK__Business__56FB16FB1C8630AA");

                    b.HasIndex("IdVenue");

                    b.HasIndex(new[] { "Name" }, "UQ__Business__72E12F1B1A9C9650")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.HasIndex(new[] { "Email" }, "UQ__Business__AB6E616401B4AC9E")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("BusinessAccount", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"));

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdCategory")
                        .HasName("PK__Category__79D361B6D4F47176");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.Event", b =>
                {
                    b.Property<int?>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idEvent");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEvent"));

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2500)")
                        .HasColumnName("description");

                    b.Property<string>("EventName")
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("eventName");

                    b.Property<int?>("IdBusinessAccount")
                        .HasColumnType("int")
                        .HasColumnName("idBusinessAccount");

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int")
                        .HasColumnName("idCategory");

                    b.Property<int?>("IdVenue")
                        .HasColumnType("int")
                        .HasColumnName("idVenue");

                    b.Property<string>("endDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("startDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("startHour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEvent")
                        .HasName("PK__Event__B7EA7D76162FB28D");

                    b.HasIndex("IdBusinessAccount");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdVenue");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idOrder");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrder"));

                    b.Property<int?>("IdEvent")
                        .HasColumnType("int")
                        .HasColumnName("idEvent");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("IdOrder")
                        .HasName("PK__Order__C8AAF6FF8AC0F47A");

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdUser");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.Payment", b =>
                {
                    b.Property<int>("IdPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPayment");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPayment"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.HasKey("IdPayment")
                        .HasName("PK__Payment__F22D4A4593E65ED4");

                    b.HasIndex("IdUser");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.Review", b =>
                {
                    b.Property<int?>("IdReview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idReview");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdReview"));

                    b.Property<string>("Comment")
                        .HasMaxLength(2500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2500)")
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
                        .HasName("PK__Review__04F7FE1095A9FA06");

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdPayment");

                    b.HasIndex("IdUser");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.User", b =>
                {
                    b.Property<int?>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdUser"));

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
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phoneNumber");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("surname");

                    b.HasKey("IdUser")
                        .HasName("PK__User__3717C9822D17B98F");

                    b.HasIndex(new[] { "Name" }, "UQ__User__72E12F1B653C9BF8")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.HasIndex(new[] { "Email" }, "UQ__User__AB6E61649F9DA34A")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.UserAction", b =>
                {
                    b.Property<int>("IdUserAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUserAction");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUserAction"));

                    b.Property<string>("ActionName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("actionName");

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
                        .HasName("PK__userActi__7AE3128011D36028");

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdUser");

                    b.ToTable("userAction", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.Venue", b =>
                {
                    b.Property<int?>("IdVenue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idVenue");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdVenue"));

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("address");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("contactNumber");

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("IdVenue")
                        .HasName("PK__Venue__077D5E69913A4F54");

                    b.ToTable("Venue", (string)null);
                });

            modelBuilder.Entity("BackEnd.Models.BusinessAccount", b =>
                {
                    b.HasOne("BackEnd.Models.Venue", "IdVenueNavigation")
                        .WithMany("BusinessAccounts")
                        .HasForeignKey("IdVenue")
                        .HasConstraintName("FK__BusinessA__idVen__5FB337D6");

                    b.Navigation("IdVenueNavigation");
                });

            modelBuilder.Entity("BackEnd.Models.Event", b =>
                {
                    b.HasOne("BackEnd.Models.BusinessAccount", "IdBusinessAccountNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdBusinessAccount")
                        .HasConstraintName("FK__Event__idBusines__6D0D32F4");

                    b.HasOne("BackEnd.Models.Category", "IdCategoryNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdCategory")
                        .HasConstraintName("FK__Event__idCategor__6E01572D");

                    b.HasOne("BackEnd.Models.Venue", "IdVenueNavigation")
                        .WithMany("Events")
                        .HasForeignKey("IdVenue")
                        .HasConstraintName("FK__Event__idVenue__6C190EBB");

                    b.Navigation("IdBusinessAccountNavigation");

                    b.Navigation("IdCategoryNavigation");

                    b.Navigation("IdVenueNavigation");
                });

            modelBuilder.Entity("BackEnd.Models.Order", b =>
                {
                    b.HasOne("BackEnd.Models.Event", "IdEventNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("FK__Order__idEvent__7A672E12");

                    b.HasOne("BackEnd.Models.User", "IdUserNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Order__idUser__797309D9");

                    b.Navigation("IdEventNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackEnd.Models.Payment", b =>
                {
                    b.HasOne("BackEnd.Models.User", "IdUserNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Payment__idUser__68487DD7");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackEnd.Models.Review", b =>
                {
                    b.HasOne("BackEnd.Models.Event", "IdEventNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("FK__Review__idEvent__70DDC3D8");

                    b.HasOne("BackEnd.Models.Payment", "IdPaymentNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdPayment")
                        .HasConstraintName("FK__Review__idPaymen__72C60C4A");

                    b.HasOne("BackEnd.Models.User", "IdUserNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Review__idUser__71D1E811");

                    b.Navigation("IdEventNavigation");

                    b.Navigation("IdPaymentNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackEnd.Models.UserAction", b =>
                {
                    b.HasOne("BackEnd.Models.Event", "IdEventNavigation")
                        .WithMany("UserActions")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("FK__userActio__idEve__75A278F5");

                    b.HasOne("BackEnd.Models.User", "IdUserNavigation")
                        .WithMany("UserActions")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__userActio__idUse__76969D2E");

                    b.Navigation("IdEventNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackEnd.Models.BusinessAccount", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("BackEnd.Models.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("BackEnd.Models.Event", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("UserActions");
                });

            modelBuilder.Entity("BackEnd.Models.Payment", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BackEnd.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");

                    b.Navigation("Reviews");

                    b.Navigation("UserActions");
                });

            modelBuilder.Entity("BackEnd.Models.Venue", b =>
                {
                    b.Navigation("BusinessAccounts");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}