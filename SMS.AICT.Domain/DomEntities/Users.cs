using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("users", Schema = "auth")]
[Index("Email", Name = "users_email_key", IsUnique = true)]
[Index("Username", Name = "users_username_key", IsUnique = true)]
public partial class Users
{
    [Key]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("username", TypeName = "citext")]
    public string Username { get; set; } = null!;

    [Column("email", TypeName = "citext")]
    public string? Email { get; set; }

    [Column("display_name")]
    public string DisplayName { get; set; } = null!;

    [Column("password_hash")]
    public string? PasswordHash { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("last_login_at")]
    public DateTime? LastLoginAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Attempts> Attempts { get; set; } = new List<Attempts>();

    [InverseProperty("ActorUser")]
    public virtual ICollection<AuditLog> AuditLog { get; set; } = new List<AuditLog>();

    [InverseProperty("AssignedByNavigation")]
    public virtual ICollection<IgsAssignments> IgsAssignmentsAssignedByNavigation { get; set; } = new List<IgsAssignments>();

    [InverseProperty("AssignedToNavigation")]
    public virtual ICollection<IgsAssignments> IgsAssignmentsAssignedToNavigation { get; set; } = new List<IgsAssignments>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ImageryRecords> ImageryRecords { get; set; } = new List<ImageryRecords>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Requests> Requests { get; set; } = new List<Requests>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Targets> Targets { get; set; } = new List<Targets>();

    [ForeignKey("UserId")]
    [InverseProperty("User")]
    public virtual ICollection<Roles> Role { get; set; } = new List<Roles>();
}
