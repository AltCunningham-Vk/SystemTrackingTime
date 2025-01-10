using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Data;

/* 
TimeTrackingSystemContext перегружен тебе его нужно резать на несколько
AdminContext (UserContext), AttendancelogContext, EmployeeContext, ReportContext
*/

public partial class TimeTrackingSystemContext : DbContext
{
    public TimeTrackingSystemContext()
    {
    }

    public TimeTrackingSystemContext(DbContextOptions<TimeTrackingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Attendancelog> Attendancelogs { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=82.208.78.201;  Port=5432; Username=postgres; Password=12345; Database = time_tracking_system");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Adminid).HasName("admins_pkey");

            entity.ToTable("admins");

            entity.HasIndex(e => e.Username, "admins_username_key").IsUnique();

            entity.Property(e => e.Adminid).HasColumnName("adminid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Employee).WithMany(p => p.Admins)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("admins_employeeid_fkey");
        });

        modelBuilder.Entity<Attendancelog>(entity =>
        {
            entity.HasKey(e => e.Logid).HasName("attendancelogs_pkey");

            entity.ToTable("attendancelogs");

            entity.HasIndex(e => e.Eventtime, "idx_attendance_eventtime");

            entity.Property(e => e.Logid).HasColumnName("logid");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Eventtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("eventtime");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(10)
                .HasColumnName("eventtype");
            entity.Property(e => e.NfcTagid)
                .HasMaxLength(50)
                .HasColumnName("nfc_tagid");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttendancelogEmployees)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("attendancelogs_employeeid_fkey");

            entity.HasOne(d => d.NfcTag).WithMany(p => p.AttendancelogNfcTags)
                .HasPrincipalKey(p => p.NfcTagid)
                .HasForeignKey(d => d.NfcTagid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("attendancelogs_nfc_tagid_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => e.NfcTagid, "employees_nfc_tagid_key").IsUnique();

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.NfcTagid)
                .HasMaxLength(50)
                .HasColumnName("nfc_tagid");
            entity.Property(e => e.Photo).HasColumnName("photo");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Reportid).HasName("reports_pkey");

            entity.ToTable("reports");

            entity.Property(e => e.Reportid).HasColumnName("reportid");
            entity.Property(e => e.Checkintime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("checkintime");
            entity.Property(e => e.Checkouttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("checkouttime");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");

            entity.HasOne(d => d.Employee).WithMany(p => p.Reports)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("reports_employeeid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
