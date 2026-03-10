using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("audit_log", Schema = "audit")]
[Index("ActorUserId", Name = "ix_audit_actor")]
[Index("At", Name = "ix_audit_at")]
public partial class AuditLog
{
    [Key]
    [Column("audit_id")]
    public Guid AuditId { get; set; }

    [Column("at")]
    public DateTime At { get; set; }

    [Column("actor_user_id")]
    public Guid? ActorUserId { get; set; }

    [Column("action")]
    public string Action { get; set; } = null!;

    [Column("entity_table")]
    public string EntityTable { get; set; } = null!;

    [Column("entity_id")]
    public Guid? EntityId { get; set; }

    [Column("context", TypeName = "jsonb")]
    public string? Context { get; set; }

    [Column("ip_address")]
    public IPAddress? IpAddress { get; set; }

    [ForeignKey("ActorUserId")]
    [InverseProperty("AuditLog")]
    public virtual Users? ActorUser { get; set; }
}
