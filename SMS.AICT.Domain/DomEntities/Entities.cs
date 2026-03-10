using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("entities", Schema = "core")]
[Index("Name", Name = "entities_name_key", IsUnique = true)]
public partial class Entities
{
    [Key]
    [Column("entity_id")]
    public Guid EntityId { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("contact_name")]
    public string? ContactName { get; set; }

    [Column("contact_phone")]
    public string? ContactPhone { get; set; }

    [Column("contact_email")]
    public string? ContactEmail { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Entity")]
    public virtual ICollection<Contracts> Contracts { get; set; } = new List<Contracts>();

    [InverseProperty("Entity")]
    public virtual ICollection<OfficialLetters> OfficialLetters { get; set; } = new List<OfficialLetters>();

    [InverseProperty("Entity")]
    public virtual ICollection<Requests> Requests { get; set; } = new List<Requests>();
}
