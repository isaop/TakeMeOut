using System;
using System.Collections.Generic;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database;

public partial class TakeMeOutDbContext : DbContext
{
    public TakeMeOutDbContext()
    {
    }

    public TakeMeOutDbContext(DbContextOptions<TakeMeOutDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BusinessAccount> BusinessAccounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAction> UserActions { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TakeMeOutDB;Integrated Security=True;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessAccount>(entity =>
        {
            entity.HasKey(e => e.IdBusinessAccount).HasName("PK__Business__56FB16FB1C8630AA");

            entity.ToTable("BusinessAccount");

            entity.HasIndex(e => e.Name, "UQ__Business__72E12F1B1A9C9650").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Business__AB6E616401B4AC9E").IsUnique();

            entity.Property(e => e.IdBusinessAccount).HasColumnName("idBusinessAccount");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contactNumber");
            entity.Property(e => e.Description)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdVenue).HasColumnName("idVenue");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdVenueNavigation).WithMany(p => p.BusinessAccounts)
                .HasForeignKey(d => d.IdVenue)
                .HasConstraintName("FK__BusinessA__idVen__5FB337D6");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B6D4F47176");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Description)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("PK__Event__B7EA7D76162FB28D");

            entity.ToTable("Event");

            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            
            entity.Property(e => e.Description)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EventName)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.IdBusinessAccount).HasColumnName("idBusinessAccount");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdVenue).HasColumnName("idVenue");

            entity.HasOne(d => d.IdBusinessAccountNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdBusinessAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__idBusines__6D0D32F4");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__idCategor__6E01572D");

            entity.HasOne(d => d.IdVenueNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdVenue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__idVenue__6C190EBB");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Order__C8AAF6FF8AC0F47A");

            entity.ToTable("Order");

            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__Order__idEvent__7A672E12");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Order__idUser__797309D9");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment).HasName("PK__Payment__F22D4A4593E65ED4");

            entity.ToTable("Payment");

            entity.Property(e => e.IdPayment).HasColumnName("idPayment");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Payment__idUser__68487DD7");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("PK__Review__04F7FE1095A9FA06");

            entity.ToTable("Review");

            entity.Property(e => e.IdReview).HasColumnName("idReview");
            entity.Property(e => e.Comment)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdPayment).HasColumnName("idPayment");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__Review__idEvent__70DDC3D8");

            entity.HasOne(d => d.IdPaymentNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdPayment)
                .HasConstraintName("FK__Review__idPaymen__72C60C4A");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Review__idUser__71D1E811");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__3717C9822D17B98F");

            entity.ToTable("User");

            entity.HasIndex(e => e.Name, "UQ__User__72E12F1B653C9BF8").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__AB6E61649F9DA34A").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<UserAction>(entity =>
        {
            entity.HasKey(e => e.IdUserAction).HasName("PK__userActi__7AE3128011D36028");

            entity.ToTable("userAction");

            entity.Property(e => e.IdUserAction).HasColumnName("idUserAction");
            entity.Property(e => e.ActionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("actionName");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__userActio__idEve__75A278F5");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__userActio__idUse__76969D2E");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.IdVenue).HasName("PK__Venue__077D5E69913A4F54");

            entity.ToTable("Venue");

            entity.Property(e => e.IdVenue).HasColumnName("idVenue");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contactNumber");
            entity.Property(e => e.Description)
                .HasMaxLength(2500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<UserRefreshToken>(entity =>
        {
            entity.HasKey(e => e.IDUserRefreshToken).HasName("PK_UserRefreshToken");

            entity.ToTable("UserRefreshToken");

            entity.Property(e => e.RefreshToken)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserRefreshTokens)
                .HasForeignKey(d => d.IDUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRefreshToken_User_IDUser");
        });

        //modelBuilder.Entity<UserRefreshToken>().ToTable("UserRefreshToken");
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
