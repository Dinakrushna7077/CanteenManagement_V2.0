using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

public partial class CanteenDbContext : DbContext
{
    public CanteenDbContext()
    {
    }

    public CanteenDbContext(DbContextOptions<CanteenDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Amount> Amounts { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AttendanceExtra> AttendanceExtras { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<ExtraItem> ExtraItems { get; set; }

    public virtual DbSet<ExtraItemCategory> ExtraItemCategories { get; set; }

    public virtual DbSet<ExtraSubCategory> ExtraSubCategories { get; set; }

    public virtual DbSet<Honour> Honours { get; set; }

    public virtual DbSet<MealLog> MealLogs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<OnlinePayment> OnlinePayments { get; set; }

    public virtual DbSet<PublicQuery> PublicQueries { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC0786D36CAB");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admins__UserId__440B1D61");
        });

        modelBuilder.Entity<Amount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Amount__3214EC073AE5F206");

            entity.Property(e => e.UpdatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AliasNavigation).WithOne(p => p.Amount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Amount__Alias__628FA481");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC0700CA937A");

            entity.HasOne(d => d.AliasNavigation).WithMany(p => p.Attendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Alias__5535A963");
        });

        modelBuilder.Entity<AttendanceExtra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC0776D699FA");

            entity.HasOne(d => d.Att).WithMany(p => p.AttendanceExtras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Att_I__5CD6CB2B");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Alias).HasName("PK__Customer__70F4A9E101F1B4CD");

            entity.Property(e => e.MealStatus).HasDefaultValue(true);

            entity.HasOne(d => d.Department).WithMany(p => p.Customers).HasConstraintName("FK__Customer__Depart__4F7CD00D");

            entity.HasOne(d => d.Honours).WithMany(p => p.Customers).HasConstraintName("FK__Customer__Honour__5070F446");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__UserId__4E88ABD4");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07E76D1E17");
        });

        modelBuilder.Entity<ExtraItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExtraIte__3214EC07D665B7D3");

            entity.HasOne(d => d.Category).WithMany(p => p.ExtraItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExtraItem__Categ__02084FDA");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.ExtraItems).HasConstraintName("FK__ExtraItem__SubCa__02FC7413");
        });

        modelBuilder.Entity<ExtraItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExtraIte__3214EC075FE2B1E5");
        });

        modelBuilder.Entity<ExtraSubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExtraSub__3214EC07A4EE83EE");

            entity.HasOne(d => d.Category).WithMany(p => p.ExtraSubCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExtraSubC__Categ__7B5B524B");
        });

        modelBuilder.Entity<Honour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Honours__3214EC075593CDB9");

            entity.HasOne(d => d.Dept).WithMany(p => p.Honours)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Honours__DeptId__4AB81AF0");
        });

        modelBuilder.Entity<MealLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MealLogs__3214EC077EAC12DD");

            entity.Property(e => e.ApproveStatus).HasDefaultValue("Pending");
            entity.Property(e => e.RequestedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AliasNavigation).WithMany(p => p.MealLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MealLogs__Alias__6FE99F9F");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.MealLogs).HasConstraintName("FK__MealLogs__Approv__74AE54BC");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menu__3214EC07B11591B2");
        });

        modelBuilder.Entity<OnlinePayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OnlinePa__3214EC0746DD315C");

            entity.Property(e => e.PayStatus).HasDefaultValue("Pending");

            entity.HasOne(d => d.AliasNavigation).WithMany(p => p.OnlinePayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OnlinePay__Alias__08B54D69");
        });

        modelBuilder.Entity<PublicQuery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Public_Q__3214EC07A088F8B5");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("Pending");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC07D1901E7B");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AliasNavigation).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Alias__68487DD7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07C06B6D5D");

            entity.Property(e => e.ActiveStatus).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__3D5E1FD2");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC07F1C4DD49");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
