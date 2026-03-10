using Microsoft.EntityFrameworkCore;
using SMS.AICT.Application.AppContracts;
using SMS.AICT.Domain.DomEntities;
using System;
using System.Collections.Generic;

namespace SMS.AICT.Persistence.Context;

public partial class DatabaseService : DbContext, IDataBaseService
{
    public DatabaseService()
    {
    }

    public DatabaseService(DbContextOptions<DatabaseService> options)
        : base(options)
    {
    }

    public virtual DbSet<Attempts> Attempts { get; set; }

    public virtual DbSet<AuditLog> AuditLog { get; set; }

    public virtual DbSet<Contracts> Contracts { get; set; }

    public virtual DbSet<Entities> Entities { get; set; }

    public virtual DbSet<IgsAssignments> IgsAssignments { get; set; }

    public virtual DbSet<ImageryRecords> ImageryRecords { get; set; }

    public virtual DbSet<ImageryTargetLinks> ImageryTargetLinks { get; set; }

    public virtual DbSet<OfficialLetters> OfficialLetters { get; set; }

    public virtual DbSet<RequestTargets> RequestTargets { get; set; }

    public virtual DbSet<Requests> Requests { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Satellites> Satellites { get; set; }

    public virtual DbSet<Targets> Targets { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=172.16.31.33;Database=AICT_allam;Username=postgres;Password=N!ghtfury48", x => x.UseNetTopologySuite());

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder
    //        .HasPostgresEnum("core", "entity_type", new[] { "Military", "Civilian", "Other" })
    //        .HasPostgresEnum("core", "sensor_type", new[] { "Optical", "SAR", "Multispectral", "Hyperspectral", "Other" })
    //        .HasPostgresEnum("ingest", "ql_status", new[] { "Accepted", "Rejected", "Proposed" })
    //        .HasPostgresEnum("mission", "attempt_status", new[] { "Planned", "Done", "Not Done" })
    //        .HasPostgresEnum("mission", "igs_target_status", new[] { "Not Assigned", "Assigned", "In Analysis", "Report Ready", "Delivered" })
    //        .HasPostgresEnum("mission", "letter_product", new[] { "Image", "Report", "Both" })
    //        .HasPostgresEnum("mission", "letter_type", new[] { "Periodic", "Ordinary", "Urgent" })
    //        .HasPostgresEnum("mission", "priority_level", new[] { "Dedicated", "Urgent", "Standard" })
    //        .HasPostgresEnum("mission", "request_status", new[] { "Created", "Received", "Planned Review", "Planned", "In Progress", "Partially Covered", "Fully Covered", "Delivered", "Closed" })
    //        .HasPostgresEnum("mission", "sms_target_status", new[] { "Pending", "Attempted", "Covered", "Partially Covered", "Rejected / Needs Replan" })
    //        .HasPostgresExtension("citext")
    //        .HasPostgresExtension("pgcrypto")
    //        .HasPostgresExtension("postgis");

    //    modelBuilder.Entity<Attempts>(entity =>
    //    {
    //        entity.HasKey(e => e.AttemptId).HasName("attempts_pkey");

    //        entity.Property(e => e.AttemptId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Attempts).HasConstraintName("attempts_created_by_fkey");

    //        entity.HasOne(d => d.Request).WithMany(p => p.Attempts).HasConstraintName("attempts_request_id_fkey");

    //        entity.HasOne(d => d.Satellite).WithMany(p => p.Attempts)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("attempts_satellite_id_fkey");

    //        entity.HasOne(d => d.Target).WithMany(p => p.Attempts).HasConstraintName("attempts_target_id_fkey");
    //    });

    //    modelBuilder.Entity<AuditLog>(entity =>
    //    {
    //        entity.HasKey(e => e.AuditId).HasName("audit_log_pkey");

    //        entity.Property(e => e.AuditId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.At).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.ActorUser).WithMany(p => p.AuditLog).HasConstraintName("audit_log_actor_user_id_fkey");
    //    });

    //    modelBuilder.Entity<Contracts>(entity =>
    //    {
    //        entity.HasKey(e => e.ContractId).HasName("contracts_pkey");

    //        entity.Property(e => e.ContractId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.Entity).WithMany(p => p.Contracts)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("contracts_entity_id_fkey");
    //    });

    //    modelBuilder.Entity<Entities>(entity =>
    //    {
    //        entity.HasKey(e => e.EntityId).HasName("entities_pkey");

    //        entity.Property(e => e.EntityId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
    //    });

    //    modelBuilder.Entity<IgsAssignments>(entity =>
    //    {
    //        entity.HasKey(e => e.AssignmentId).HasName("igs_assignments_pkey");

    //        entity.Property(e => e.AssignmentId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.AssignedAt).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.IgsAssignmentsAssignedByNavigation).HasConstraintName("igs_assignments_assigned_by_fkey");

    //        entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.IgsAssignmentsAssignedToNavigation).HasConstraintName("igs_assignments_assigned_to_fkey");

    //        entity.HasOne(d => d.Imagery).WithMany(p => p.IgsAssignments).HasConstraintName("igs_assignments_imagery_id_fkey");

    //        entity.HasOne(d => d.Request).WithMany(p => p.IgsAssignments).HasConstraintName("igs_assignments_request_id_fkey");

    //        entity.HasOne(d => d.Target).WithMany(p => p.IgsAssignments)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("igs_assignments_target_id_fkey");
    //    });

    //    modelBuilder.Entity<ImageryRecords>(entity =>
    //    {
    //        entity.HasKey(e => e.ImageryId).HasName("imagery_records_pkey");

    //        entity.HasIndex(e => e.Bbox, "ix_imagery_bbox_gist").HasMethod("gist");

    //        entity.HasIndex(e => e.Footprint, "ix_imagery_footprint_gist").HasMethod("gist");

    //        entity.Property(e => e.ImageryId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.Attempt).WithMany(p => p.ImageryRecords)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("imagery_records_attempt_id_fkey");

    //        entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ImageryRecords).HasConstraintName("imagery_records_created_by_fkey");
    //    });

    //    modelBuilder.Entity<ImageryTargetLinks>(entity =>
    //    {
    //        entity.HasKey(e => new { e.ImageryId, e.TargetId }).HasName("imagery_target_links_pkey");

    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.Intersects).HasDefaultValue(true);

    //        entity.HasOne(d => d.Imagery).WithMany(p => p.ImageryTargetLinks).HasConstraintName("imagery_target_links_imagery_id_fkey");

    //        entity.HasOne(d => d.Target).WithMany(p => p.ImageryTargetLinks)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("imagery_target_links_target_id_fkey");
    //    });

    //    modelBuilder.Entity<OfficialLetters>(entity =>
    //    {
    //        entity.HasKey(e => e.LetterId).HasName("official_letters_pkey");

    //        entity.Property(e => e.LetterId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.Entity).WithMany(p => p.OfficialLetters).HasConstraintName("official_letters_entity_id_fkey");
    //    });

    //    modelBuilder.Entity<RequestTargets>(entity =>
    //    {
    //        entity.HasKey(e => new { e.RequestId, e.TargetId }).HasName("request_targets_pkey");

    //        entity.HasOne(d => d.Request).WithMany(p => p.RequestTargets).HasConstraintName("request_targets_request_id_fkey");

    //        entity.HasOne(d => d.Target).WithMany(p => p.RequestTargets)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("request_targets_target_id_fkey");
    //    });

    //    modelBuilder.Entity<Requests>(entity =>
    //    {
    //        entity.HasKey(e => e.RequestId).HasName("requests_pkey");

    //        entity.Property(e => e.RequestId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Requests).HasConstraintName("requests_created_by_fkey");

    //        entity.HasOne(d => d.Entity).WithMany(p => p.Requests)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("requests_entity_id_fkey");

    //        entity.HasMany(d => d.Contract).WithMany(p => p.Request)
    //            .UsingEntity<Dictionary<string, object>>(
    //                "RequestContracts",
    //                r => r.HasOne<Contracts>().WithMany()
    //                    .HasForeignKey("ContractId")
    //                    .OnDelete(DeleteBehavior.ClientSetNull)
    //                    .HasConstraintName("request_contracts_contract_id_fkey"),
    //                l => l.HasOne<Requests>().WithMany()
    //                    .HasForeignKey("RequestId")
    //                    .HasConstraintName("request_contracts_request_id_fkey"),
    //                j =>
    //                {
    //                    j.HasKey("RequestId", "ContractId").HasName("request_contracts_pkey");
    //                    j.ToTable("request_contracts", "mission");
    //                    j.IndexerProperty<Guid>("RequestId").HasColumnName("request_id");
    //                    j.IndexerProperty<Guid>("ContractId").HasColumnName("contract_id");
    //                });

    //        entity.HasMany(d => d.Letter).WithMany(p => p.Request)
    //            .UsingEntity<Dictionary<string, object>>(
    //                "RequestLetters",
    //                r => r.HasOne<OfficialLetters>().WithMany()
    //                    .HasForeignKey("LetterId")
    //                    .OnDelete(DeleteBehavior.ClientSetNull)
    //                    .HasConstraintName("request_letters_letter_id_fkey"),
    //                l => l.HasOne<Requests>().WithMany()
    //                    .HasForeignKey("RequestId")
    //                    .HasConstraintName("request_letters_request_id_fkey"),
    //                j =>
    //                {
    //                    j.HasKey("RequestId", "LetterId").HasName("request_letters_pkey");
    //                    j.ToTable("request_letters", "mission");
    //                    j.IndexerProperty<Guid>("RequestId").HasColumnName("request_id");
    //                    j.IndexerProperty<Guid>("LetterId").HasColumnName("letter_id");
    //                });
    //    });

    //    modelBuilder.Entity<Roles>(entity =>
    //    {
    //        entity.HasKey(e => e.RoleId).HasName("roles_pkey");

    //        entity.Property(e => e.RoleId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //    });

    //    modelBuilder.Entity<Satellites>(entity =>
    //    {
    //        entity.HasKey(e => e.SatelliteId).HasName("satellites_pkey");

    //        entity.Property(e => e.SatelliteId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
    //    });

    //    modelBuilder.Entity<Targets>(entity =>
    //    {
    //        entity.HasKey(e => e.TargetId).HasName("targets_pkey");

    //        entity.HasIndex(e => e.Geom, "ix_targets_geom_gist").HasMethod("gist");

    //        entity.Property(e => e.TargetId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.IsPermanent).HasDefaultValue(false);
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

    //        entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Targets).HasConstraintName("targets_created_by_fkey");
    //    });

    //    modelBuilder.Entity<Users>(entity =>
    //    {
    //        entity.HasKey(e => e.UserId).HasName("users_pkey");

    //        entity.Property(e => e.UserId).HasDefaultValueSql("gen_random_uuid()");
    //        entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    //        entity.Property(e => e.IsActive).HasDefaultValue(true);
    //        entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

    //        entity.HasMany(d => d.Role).WithMany(p => p.User)
    //            .UsingEntity<Dictionary<string, object>>(
    //                "UserRoles",
    //                r => r.HasOne<Roles>().WithMany()
    //                    .HasForeignKey("RoleId")
    //                    .HasConstraintName("user_roles_role_id_fkey"),
    //                l => l.HasOne<Users>().WithMany()
    //                    .HasForeignKey("UserId")
    //                    .HasConstraintName("user_roles_user_id_fkey"),
    //                j =>
    //                {
    //                    j.HasKey("UserId", "RoleId").HasName("user_roles_pkey");
    //                    j.ToTable("user_roles", "auth");
    //                    j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
    //                    j.IndexerProperty<Guid>("RoleId").HasColumnName("role_id");
    //                });
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
