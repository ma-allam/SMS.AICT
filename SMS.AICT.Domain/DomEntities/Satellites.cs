using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("satellites", Schema = "core")]
[Index("Name", Name = "satellites_name_key", IsUnique = true)]
public partial class Satellites
{
    [Key]
    [Column("satellite_id")]
    public Guid SatelliteId { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("provider")]
    public string? Provider { get; set; }

    [Column("resolution_m")]
    [Precision(10, 3)]
    public decimal? ResolutionM { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Satellite")]
    public virtual ICollection<Attempts> Attempts { get; set; } = new List<Attempts>();
}
