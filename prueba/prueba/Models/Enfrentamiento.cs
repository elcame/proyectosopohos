using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    [Table("enfrentamientos")]
    public partial class Enfrentamiento
    {
        [Key]
        [Column("Id_registro")]
        public int IdRegistro { get; set; }
        [Column("Id_hero")]
        public int IdHero { get; set; }
        [Column("Id_villain")]
        public int IdVillain { get; set; }
        [Column("resultado")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Resultado { get; set; }

        [ForeignKey("IdHero")]
        [InverseProperty("Enfrentamientos")]
        public virtual Heroe IdHeroNavigation { get; set; } = null!;
        [ForeignKey("IdVillain")]
        [InverseProperty("Enfrentamientos")]
        public virtual Villano IdVillainNavigation { get; set; } = null!;
    }
}
