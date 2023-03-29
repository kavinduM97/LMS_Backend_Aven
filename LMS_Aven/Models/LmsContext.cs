using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LMS_Aven.Models;

public partial class LmsContext : DbContext
{
    public LmsContext()
    {
    }

    public LmsContext(DbContextOptions<LmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LeaveDetail> LeaveDetails { get; set; }

    public virtual DbSet<LeaveType> LeaveTypes { get; set; }

    public virtual DbSet<UserLeaveDetail> UserLeaveDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=LMS;Trusted_Connection=True;Encrypt=False; User Id=sa; Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeaveDetail>(entity =>
        {
            entity.HasKey(e => e.DetailsId).HasName("PK__Leave_De__BAC862AC3FACA849");

            entity.ToTable("Leave_Details");

            entity.Property(e => e.DetailsId)
                .HasMaxLength(36)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("DetailsID");
            entity.Property(e => e.CheckedDate).HasColumnType("date");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.LeaveStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LeaveTypeId)
                .HasMaxLength(36)
                .HasColumnName("LeaveTypeID");
            entity.Property(e => e.Reason)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.RequestedDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasColumnName("UserID");

            entity.HasOne(d => d.LeaveType).WithMany(p => p.LeaveDetails)
                .HasForeignKey(d => d.LeaveTypeId)
                .HasConstraintName("FK__Leave_Det__Leave__4D94879B");
        });

        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.HasKey(e => e.LeaveTypeId).HasName("PK__Leave_Ty__43BE8FF4622335AF");

            entity.ToTable("Leave_Type");

            entity.Property(e => e.LeaveTypeId)
                .HasMaxLength(36)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("LeaveTypeID");
            entity.Property(e => e.AboutLeave)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.LeaveType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LeaveType");
        });

        modelBuilder.Entity<UserLeaveDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_Lea__3214EC278E7CB90A");

            entity.ToTable("User_Leave_Detail");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.LeaveTypeId)
                .HasMaxLength(36)
                .HasColumnName("LeaveTypeID");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasColumnName("UserID");

            entity.HasOne(d => d.LeaveType).WithMany(p => p.UserLeaveDetails)
                .HasForeignKey(d => d.LeaveTypeId)
                .HasConstraintName("FK__User_Leav__Numof__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
