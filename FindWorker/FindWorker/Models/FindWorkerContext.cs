using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FindWorker.Models;

public partial class FindWorkerContext : DbContext
{
    private static FindWorkerContext _context;
    public static FindWorkerContext GetContext()
    {
        if (_context == null)
            _context = new FindWorkerContext();
        return _context;
    }
    public FindWorkerContext()
    {
    }

    public FindWorkerContext(DbContextOptions<FindWorkerContext> options)
        : base(options)
    {
    }

    

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    //=> optionsBuilder.UseSqlServer("Server=LAPTOP-DEUGJ3J3\\SQLEXPRESS;Database=FindWorker;Trusted_Connection=True;TrustServerCertificate=True;");
    //=> optionsBuilder.UseSqlServer("Server=44-4\\SQLEXPRESS;Database=FW;Trusted_Connection=True;TrustServerCertificate=True;");
    => optionsBuilder.UseSqlServer("Server=44-6\\SQLEXPRESS01;Database=FindWorker;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.ToTable("Offer");

            entity.Property(e => e.Heading).HasMaxLength(50);
            entity.Property(e => e.IdOrganization).HasColumnName("Id_Organization");
            entity.Property(e => e.IdPost).HasColumnName("Id_post");
            entity.Property(e => e.IdUser).HasColumnName("Id_user");

            entity.HasOne(d => d.IdOrganizationNavigation).WithMany(p => p.Offers)
                .HasForeignKey(d => d.IdOrganization)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("FK_Offer_Organization");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Offers)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offer_Post");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Offers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offer_User");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.ToTable("Organization");

            entity.Property(e => e.IdUserrole).HasColumnName("Id_userrole");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.NameOrganization).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PersonalAccount).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.IdUserroleNavigation).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.IdUserrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organization_UserRole");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdUserrole).HasColumnName("Id_userrole");
            entity.Property(e => e.Inn)
                .HasMaxLength(50)
                .HasColumnName("INN");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.NumberPassport).HasMaxLength(6);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.SerialPassport).HasMaxLength(4);

            entity.HasOne(d => d.IdUserroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUserrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserRole");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
