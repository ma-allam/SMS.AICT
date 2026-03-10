using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[PrimaryKey("ImageryId", "TargetId")]
[Table("imagery_target_links", Schema = "ingest")]
public partial class ImageryTargetLinks
{
    [Key]
    [Column("imagery_id")]
    public Guid ImageryId { get; set; }

    [Key]
    [Column("target_id")]
    public Guid TargetId { get; set; }

    [Column("intersects")]
    public bool Intersects { get; set; }

    [Column("intersection_area_m2")]
    public double? IntersectionAreaM2 { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("ImageryId")]
    [InverseProperty("ImageryTargetLinks")]
    public virtual ImageryRecords Imagery { get; set; } = null!;

    [ForeignKey("TargetId")]
    [InverseProperty("ImageryTargetLinks")]
    public virtual Targets Target { get; set; } = null!;
}
