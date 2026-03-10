using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace SMS.AICT.Domain.DomEntities;

[Table("imagery_records", Schema = "ingest")]
[Index("AttemptId", Name = "ix_imagery_attempt_id")]
public partial class ImageryRecords
{
    [Key]
    [Column("imagery_id")]
    public Guid ImageryId { get; set; }

    [Column("attempt_id")]
    public Guid AttemptId { get; set; }

    [Column("provider_imagery_id")]
    public string? ProviderImageryId { get; set; }

    [Column("acquisition_time")]
    public DateTime? AcquisitionTime { get; set; }

    [Column("footprint", TypeName = "geometry(Geometry,4326)")]
    public Geometry? Footprint { get; set; }

    [Column("bbox", TypeName = "geometry(Polygon,4326)")]
    public Polygon? Bbox { get; set; }

    [Column("raw_xml")]
    public string? RawXml { get; set; }

    [Column("raw_xml_sha256")]
    public string? RawXmlSha256 { get; set; }

    [Column("preview_path")]
    public string? PreviewPath { get; set; }

    [Column("created_by")]
    public Guid? CreatedBy { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("AttemptId")]
    [InverseProperty("ImageryRecords")]
    public virtual Attempts Attempt { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ImageryRecords")]
    public virtual Users? CreatedByNavigation { get; set; }

    [InverseProperty("Imagery")]
    public virtual ICollection<IgsAssignments> IgsAssignments { get; set; } = new List<IgsAssignments>();

    [InverseProperty("Imagery")]
    public virtual ICollection<ImageryTargetLinks> ImageryTargetLinks { get; set; } = new List<ImageryTargetLinks>();
}
