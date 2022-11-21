using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TakeMeOutBE.Models;

namespace TakeMeOutBE.Database;

public partial class TakeMeOutContext : DbContext
{
    public TakeMeOutContext()
    {
    }

    public TakeMeOutContext(DbContextOptions<TakeMeOutContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BusinessAccount> BusinessAccounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAction> UserActions { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TakeMeOut;Integrated Security=True;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessAccount>(entity =>
        {
            entity.HasKey(e => e.IdBa).HasName("PK__Business__9DB8DE821DC1CC20");

            entity.ToTable("BusinessAccount");

            entity.HasIndex(e => e.Name, "UQ__Business__72E12F1B2D4BF3CD").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Business__AB6E6164DDECB8BD").IsUnique();

            entity.Property(e => e.IdBa).HasColumnName("idBA");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("contactNumber");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdVenue).HasColumnName("idVenue");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdVenueNavigation).WithMany(p => p.BusinessAccounts)
                .HasForeignKey(d => d.IdVenue)
                .HasConstraintName("FK__BusinessA__idVen__29572725");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B6C333322B");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("PK__Event__B7EA7D7610802020");

            entity.ToTable("Event");

            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EventName)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.IdBa).HasColumnName("idBA");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdEventStatus).HasColumnName("idEventStatus");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdVenue).HasColumnName("idVenue");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.IdBaNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdBa)
                .HasConstraintName("FK__Event__idBA__3B75D760");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__idCategor__3C69FB99");

            entity.HasOne(d => d.IdEventStatusNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdEventStatus)
                .HasConstraintName("FK__Event__idEventSt__398D8EEE");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Event__idUser__3A81B327");

            entity.HasOne(d => d.IdVenueNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdVenue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__idVenue__38996AB5");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.IdEventStatus).HasName("PK__EventSta__8BA84D2113D948A2");

            entity.ToTable("EventStatus");

            entity.Property(e => e.IdEventStatus).HasColumnName("idEventStatus");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Order__C8AAF6FF94A636C9");

            entity.ToTable("Order");

            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__Order__idEvent__48CFD27E");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Order__idUser__47DBAE45");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment).HasName("PK__Payment__F22D4A455175E55E");

            entity.ToTable("Payment");

            entity.Property(e => e.IdPayment).HasColumnName("idPayment");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Payment__idUser__34C8D9D1");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("PK__Review__04F7FE1049D2A0B7");

            entity.ToTable("Review");

            entity.Property(e => e.IdReview).HasColumnName("idReview");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdPayment).HasColumnName("idPayment");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__Review__idEvent__3F466844");

            entity.HasOne(d => d.IdPaymentNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdPayment)
                .HasConstraintName("FK__Review__idPaymen__412EB0B6");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Review__idUser__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__3717C982F140C6B3");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__AB6E6164986D442F").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<UserAction>(entity =>
        {
            entity.HasKey(e => e.IdUserAction).HasName("PK__userActi__7AE31280C8489D16");

            entity.ToTable("userAction");

            entity.Property(e => e.IdUserAction).HasColumnName("idUserAction");
            entity.Property(e => e.ActionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("actionName");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__userActio__idEve__440B1D61");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__userActio__idUse__44FF419A");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.IdVenue).HasName("PK__Venue__077D5E69C89A79A3");

            entity.ToTable("Venue");

            entity.Property(e => e.IdVenue).HasColumnName("idVenue");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("contactNumber");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UniqueIden)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("uniqueIden");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
