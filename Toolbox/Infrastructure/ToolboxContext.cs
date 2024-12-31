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

    public virtual DbSet<JsonItem> JsonItems { get; set; }

    public virtual DbSet<Jsonschema> Jsonschemas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=toolbox.cf42c2woygkb.us-east-1.rds.amazonaws.com,5432;Database=Toolbox;User Id=itheta11;Password=ANUPsweet123;TrustServerCertificate=False;");

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

        modelBuilder.Entity<JsonItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("json_item_pkey");

            entity.ToTable("json_item");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_at");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Value).HasColumnName("value");
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
