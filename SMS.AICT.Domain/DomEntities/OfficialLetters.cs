using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("official_letters", Schema = "mission")]
[Index("EntityId", Name = "ix_letters_entity_id")]
[Index("LetterNo", Name = "official_letters_letter_no_key", IsUnique = true)]
public partial class OfficialLetters
{
    [Key]
    [Column("letter_id")]
    public Guid LetterId { get; set; }

    [Column("entity_id")]
    public Guid? EntityId { get; set; }

    [Column("letter_no")]
    public string LetterNo { get; set; } = null!;

    [Column("letter_date")]
    public DateOnly LetterDate { get; set; }

    [Column("coverage_from")]
    public DateOnly? CoverageFrom { get; set; }

    [Column("coverage_to")]
    public DateOnly? CoverageTo { get; set; }

    [Column("required_resolution_m")]
    [Precision(10, 3)]
    public decimal? RequiredResolutionM { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("EntityId")]
    [InverseProperty("OfficialLetters")]
    public virtual Entities? Entity { get; set; }

    [ForeignKey("LetterId")]
    [InverseProperty("Letter")]
    public virtual ICollection<Requests> Request { get; set; } = new List<Requests>();
}
