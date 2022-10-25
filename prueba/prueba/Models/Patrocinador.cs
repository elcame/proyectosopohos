using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    [Table("Patrocinador")]
    public partial class Patrocinador
    {
        public Patrocinador()
        {
            Patrocinas = new HashSet<Patrocina>();
        }

        [Key]
        [Column("Id_patrocinador")]
        public int IdPatrocinador { get; set; }
        [Column("origen_dinero")]
        [StringLength(100)]
        [Unicode(false)]
        public string? OrigenDinero { get; set; }
        [Column("nombre")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Nombre { get; set; }

        [InverseProperty("IdPatrocinadorNavigation")]
        public virtual ICollection<Patrocina> Patrocinas { get; set; }
    }
}
