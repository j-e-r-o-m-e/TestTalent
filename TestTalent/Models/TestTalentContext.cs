using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestTalent.Models;

public partial class TestTalentContext : DbContext
{
    public TestTalentContext()
    {
    }

    public TestTalentContext(DbContextOptions<TestTalentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Utilistaeur> Utilistaeurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TestTalent;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utilistaeur>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
