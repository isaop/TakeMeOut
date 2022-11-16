using Microsoft.EntityFrameworkCore;
using TakeMeOut.Database.Models;

namespace TakeMeOut.Database;

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
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KT0HP0M\\SQLEXPRESS;Initial Catalog=TakeMeOut;Integrated Security=True;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessAccount>(entity =>
        {
            entity.HasKey(e => e.IdBa).HasName("PK__Business__9DB8DE827480C09C");

            entity.ToTable("Business_Account");

            entity.HasIndex(e => e.Name, "UQ__Business__72E12F1B1F6650F8").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Business__AB6E6164FDCFEFBA").IsUnique();

            entity.Property(e => e.IdBa)
                .ValueGeneratedNever()
                .HasColumnName("idBA");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.ContactNo).HasColumnName("contact_No");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
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
                .HasConstraintName("FK__Business___idVen__29572725");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCat).HasName("PK__Category__398E4045C9ECC572");

            entity.ToTable("Category");

            entity.Property(e => e.IdCat)
                .ValueGeneratedNever()
                .HasColumnName("idCat");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("PK__Event__B7EA7D76B3559F2E");

            entity.ToTable("Event");

            entity.Property(e => e.IdEvent)
                .ValueGeneratedNever()
                .HasColumnName("idEvent");
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
                .HasColumnName("event_name");
            entity.Property(e => e.IdBa).HasColumnName("idBA");
            entity.Property(e => e.IdCat).HasColumnName("idCat");
            entity.Property(e => e.IdEstat).HasColumnName("idEstat");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdVenue).HasColumnName("idVenue");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.IdBaNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdBa)
                .HasConstraintName("FK__Event__idBA__3B75D760");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__idCat__3C69FB99");

            entity.HasOne(d => d.IdEstatNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdEstat)
                .HasConstraintName("FK__Event__idEstat__398D8EEE");

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
            entity.HasKey(e => e.IdEstat).HasName("PK__Event_St__6214BC210DE7C9D3");

            entity.ToTable("Event_Status");

            entity.Property(e => e.IdEstat)
                .ValueGeneratedNever()
                .HasColumnName("idEstat");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Orders__C8AAF6FF2034C34B");

            entity.Property(e => e.IdOrder)
                .ValueGeneratedNever()
                .HasColumnName("idOrder");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__Orders__idEvent__48CFD27E");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Orders__idUser__47DBAE45");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment).HasName("PK__Payments__F22D4A45104198F7");

            entity.Property(e => e.IdPayment)
                .ValueGeneratedNever()
                .HasColumnName("idPayment");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Payments__idUser__34C8D9D1");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("PK__Reviews__04F7FE10A1EC1D3C");

            entity.Property(e => e.IdReview)
                .ValueGeneratedNever()
                .HasColumnName("idReview");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdPayment).HasColumnName("idPayment");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__Reviews__idEvent__3F466844");

            entity.HasOne(d => d.IdPaymentNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdPayment)
                .HasConstraintName("FK__Reviews__idPayme__412EB0B6");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Reviews__idUser__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C9824B671996");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61644354BEF8").IsUnique();

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("idUser");
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
            entity.Property(e => e.PhoneNo).HasColumnName("phone_No");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<UserAction>(entity =>
        {
            entity.HasKey(e => e.IdUserAction).HasName("PK__user_act__7AE31280D64B2F5E");

            entity.ToTable("user_action");

            entity.Property(e => e.IdUserAction)
                .ValueGeneratedNever()
                .HasColumnName("idUserAction");
            entity.Property(e => e.ActionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("action_Name");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdEvent).HasColumnName("idEvent");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__user_acti__idEve__440B1D61");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__user_acti__idUse__44FF419A");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.IdVenue).HasName("PK__Venue__077D5E693F07C0A4");

            entity.ToTable("Venue");

            entity.Property(e => e.IdVenue)
                .ValueGeneratedNever()
                .HasColumnName("idVenue");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.ContactNo).HasColumnName("contact_No");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UniqueIden)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("unique_iden");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
