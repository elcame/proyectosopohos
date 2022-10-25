using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    public partial class Relacione
    {
        [Key]
        [Column("id_relacion")]
        public int IdRelacion { get; set; }
        [Column("id_hero")]
        public int? IdHero { get; set; }
        [Column("tipo")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Tipo { get; set; }
        [Column("contacto")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Contacto { get; set; }

        [ForeignKey("IdHero")]
        [InverseProperty("Relaciones")]
        public virtual Heroe? IdHeroNavigation { get; set; }
    }
}
