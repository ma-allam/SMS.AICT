using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("roles", Schema = "auth")]
[Index("RoleKey", Name = "roles_role_key_key", IsUnique = true)]
public partial class Roles
{
    [Key]
    [Column("role_id")]
    public Guid RoleId { get; set; }

    [Column("role_key")]
    public string RoleKey { get; set; } = null!;

    [Column("role_name")]
    public string RoleName { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Role")]
    public virtual ICollection<Users> User { get; set; } = new List<Users>();
}
