using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Toolbox.Infrastructure;

public partial class ToolboxContext : DbContext
{
    public ToolboxContext()
    {
    }

    public ToolboxContext(DbContextOptions<ToolboxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cheatsheet> Cheatsheets { get; set; }

    public virtual DbSet<ExacliDrawing> ExacliDrawings { get; set; }

    public virtual DbSet<Jsonschema> Jsonschemas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cheatsheet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cheatsheet_pkey");

            entity.ToTable("cheatsheet");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_at");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<ExacliDrawing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exacli_drawing_pkey");

            entity.ToTable("exacli_drawing");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_at");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Jsonschema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jsonschema_pkey");

            entity.ToTable("jsonschema");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_at");
            entity.Property(e => e.Schema).HasColumnName("schema");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
