using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMS.AICT.Domain.DomEntities;

[Table("contracts", Schema = "mission")]
[Index("ContractNo", Name = "contracts_contract_no_key", IsUnique = true)]
[Index("EntityId", Name = "ix_contracts_entity_id")]
public partial class Contracts
{
    [Key]
    [Column("contract_id")]
    public Guid ContractId { get; set; }

    [Column("entity_id")]
    public Guid EntityId { get; set; }

    [Column("contract_no")]
    public string ContractNo { get; set; } = null!;

    [Column("valid_from")]
    public DateOnly ValidFrom { get; set; }

    [Column("valid_to")]
    public DateOnly ValidTo { get; set; }

    [Column("credit_total")]
    [Precision(18, 2)]
    public decimal? CreditTotal { get; set; }

    [Column("credit_used")]
    [Precision(18, 2)]
    public decimal CreditUsed { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("EntityId")]
    [InverseProperty("Contracts")]
    public virtual Entities Entity { get; set; } = null!;

    [ForeignKey("ContractId")]
    [InverseProperty("Contract")]
    public virtual ICollection<Requests> Request { get; set; } = new List<Requests>();
}
