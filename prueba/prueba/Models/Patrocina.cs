using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    [Table("Patrocina")]
    public partial class Patrocina
    {
        [Key]
        [Column("Id_patrocinio")]
        public int IdPatrocinio { get; set; }
        [Column("Id_patrocinador")]
        public int? IdPatrocinador { get; set; }
        [Column("id_hero")]
        public int? IdHero { get; set; }
        [Column("monto")]
        public int? Monto { get; set; }

        [ForeignKey("IdHero")]
        [InverseProperty("Patrocinas")]
        public virtual Heroe? IdHeroNavigation { get; set; }
        [ForeignKey("IdPatrocinador")]
        [InverseProperty("Patrocinas")]
        public virtual Patrocinador? IdPatrocinadorNavigation { get; set; }
    }
}
