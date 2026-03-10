using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[PrimaryKey("RequestId", "TargetId")]
[Table("request_targets", Schema = "mission")]
public partial class RequestTargets
{
    [Key]
    [Column("request_id")]
    public Guid RequestId { get; set; }

    [Key]
    [Column("target_id")]
    public Guid TargetId { get; set; }

    [Column("covered_area_m2")]
    public double? CoveredAreaM2 { get; set; }

    [Column("target_area_m2")]
    public double? TargetAreaM2 { get; set; }

    [Column("coverage_pct")]
    [Precision(6, 2)]
    public decimal? CoveragePct { get; set; }

    [Column("last_coverage_at")]
    public DateTime? LastCoverageAt { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("RequestTargets")]
    public virtual Requests Request { get; set; } = null!;

    [ForeignKey("TargetId")]
    [InverseProperty("RequestTargets")]
    public virtual Targets Target { get; set; } = null!;
}
