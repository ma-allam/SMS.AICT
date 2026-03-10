using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace SMS.AICT.Domain.DomEntities;

[Table("targets", Schema = "core")]
public partial class Targets
{
    [Key]
    [Column("target_id")]
    public Guid TargetId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("is_permanent")]
    public bool IsPermanent { get; set; }

    [Column("target_kind")]
    public string TargetKind { get; set; } = null!;

    [Column("geom", TypeName = "geometry(Geometry,4326)")]
    public Geometry Geom { get; set; } = null!;

    [Column("source_file_name")]
    public string? SourceFileName { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("created_by")]
    public Guid? CreatedBy { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Target")]
    public virtual ICollection<Attempts> Attempts { get; set; } = new List<Attempts>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("Targets")]
    public virtual Users? CreatedByNavigation { get; set; }

    [InverseProperty("Target")]
    public virtual ICollection<IgsAssignments> IgsAssignments { get; set; } = new List<IgsAssignments>();

    [InverseProperty("Target")]
    public virtual ICollection<ImageryTargetLinks> ImageryTargetLinks { get; set; } = new List<ImageryTargetLinks>();

    [InverseProperty("Target")]
    public virtual ICollection<RequestTargets> RequestTargets { get; set; } = new List<RequestTargets>();
}
