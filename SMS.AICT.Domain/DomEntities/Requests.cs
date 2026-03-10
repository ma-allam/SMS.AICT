using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("requests", Schema = "mission")]
[Index("EntityId", Name = "ix_requests_entity_id")]
[Index("RequestCode", Name = "requests_request_code_key", IsUnique = true)]
[Index("RequestNo", Name = "requests_request_no_key", IsUnique = true)]
public partial class Requests
{
    [Key]
    [Column("request_id")]
    public Guid RequestId { get; set; }

    [Column("request_no")]
    public string RequestNo { get; set; } = null!;

    [Column("request_code")]
    public string? RequestCode { get; set; }

    [Column("entity_id")]
    public Guid EntityId { get; set; }

    [Column("window_from")]
    public DateTime? WindowFrom { get; set; }

    [Column("window_to")]
    public DateTime? WindowTo { get; set; }

    [Column("constraints_text")]
    public string? ConstraintsText { get; set; }

    [Column("created_by")]
    public Guid? CreatedBy { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Request")]
    public virtual ICollection<Attempts> Attempts { get; set; } = new List<Attempts>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("Requests")]
    public virtual Users? CreatedByNavigation { get; set; }

    [ForeignKey("EntityId")]
    [InverseProperty("Requests")]
    public virtual Entities Entity { get; set; } = null!;

    [InverseProperty("Request")]
    public virtual ICollection<IgsAssignments> IgsAssignments { get; set; } = new List<IgsAssignments>();

    [InverseProperty("Request")]
    public virtual ICollection<RequestTargets> RequestTargets { get; set; } = new List<RequestTargets>();

    [ForeignKey("RequestId")]
    [InverseProperty("Request")]
    public virtual ICollection<Contracts> Contract { get; set; } = new List<Contracts>();

    [ForeignKey("RequestId")]
    [InverseProperty("Request")]
    public virtual ICollection<OfficialLetters> Letter { get; set; } = new List<OfficialLetters>();
}
