using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("igs_assignments", Schema = "mission")]
[Index("RequestId", "TargetId", "ImageryId", Name = "igs_assignments_request_id_target_id_imagery_id_key", IsUnique = true)]
[Index("AssignedTo", Name = "ix_igs_assignments_assigned_to")]
public partial class IgsAssignments
{
    [Key]
    [Column("assignment_id")]
    public Guid AssignmentId { get; set; }

    [Column("request_id")]
    public Guid RequestId { get; set; }

    [Column("target_id")]
    public Guid TargetId { get; set; }

    [Column("imagery_id")]
    public Guid? ImageryId { get; set; }

    [Column("assigned_to")]
    public Guid? AssignedTo { get; set; }

    [Column("assigned_by")]
    public Guid? AssignedBy { get; set; }

    [Column("assigned_at")]
    public DateTime AssignedAt { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [ForeignKey("AssignedBy")]
    [InverseProperty("IgsAssignmentsAssignedByNavigation")]
    public virtual Users? AssignedByNavigation { get; set; }

    [ForeignKey("AssignedTo")]
    [InverseProperty("IgsAssignmentsAssignedToNavigation")]
    public virtual Users? AssignedToNavigation { get; set; }

    [ForeignKey("ImageryId")]
    [InverseProperty("IgsAssignments")]
    public virtual ImageryRecords? Imagery { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("IgsAssignments")]
    public virtual Requests Request { get; set; } = null!;

    [ForeignKey("TargetId")]
    [InverseProperty("IgsAssignments")]
    public virtual Targets Target { get; set; } = null!;
}
