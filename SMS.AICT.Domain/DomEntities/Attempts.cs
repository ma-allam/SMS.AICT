using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("attempts", Schema = "mission")]
[Index("PlannedAt", Name = "ix_attempts_planned_at")]
[Index("RequestId", Name = "ix_attempts_request_id")]
[Index("SatelliteId", Name = "ix_attempts_satellite_id")]
[Index("TargetId", Name = "ix_attempts_target_id")]
[Index("AttemptGroupId", "Version", Name = "ux_attempts_group_version", IsUnique = true)]
public partial class Attempts
{
    [Key]
    [Column("attempt_id")]
    public Guid AttemptId { get; set; }

    [Column("attempt_group_id")]
    public Guid AttemptGroupId { get; set; }

    [Column("version")]
    public int Version { get; set; }

    [Column("request_id")]
    public Guid RequestId { get; set; }

    [Column("target_id")]
    public Guid? TargetId { get; set; }

    [Column("satellite_id")]
    public Guid SatelliteId { get; set; }

    [Column("planned_at")]
    public DateTime PlannedAt { get; set; }

    [Column("incidence_angle_deg")]
    [Precision(8, 3)]
    public decimal? IncidenceAngleDeg { get; set; }

    [Column("other_angle_meta", TypeName = "jsonb")]
    public string? OtherAngleMeta { get; set; }

    [Column("failure_reason")]
    public string? FailureReason { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("created_by")]
    public Guid? CreatedBy { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("Attempts")]
    public virtual Users? CreatedByNavigation { get; set; }

    [InverseProperty("Attempt")]
    public virtual ICollection<ImageryRecords> ImageryRecords { get; set; } = new List<ImageryRecords>();

    [ForeignKey("RequestId")]
    [InverseProperty("Attempts")]
    public virtual Requests Request { get; set; } = null!;

    [ForeignKey("SatelliteId")]
    [InverseProperty("Attempts")]
    public virtual Satellites Satellite { get; set; } = null!;

    [ForeignKey("TargetId")]
    [InverseProperty("Attempts")]
    public virtual Targets? Target { get; set; }
}
