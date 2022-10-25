using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    [Table("villano")]
    public partial class Villano
    {
        public Villano()
        {
            Enfrentamientos = new HashSet<Enfrentamiento>();
        }

        [Key]
        [Column("Id_villain")]
        public int IdVillain { get; set; }
        [Column("Nombre_Completo")]
        [StringLength(100)]
        [Unicode(false)]
        public string NombreCompleto { get; set; } = null!;
        public int? Edad { get; set; }
        [Column("Habilidades_Poderes")]
        [StringLength(100)]
        [Unicode(false)]
        public string HabilidadesPoderes { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string? Debilidades { get; set; }
        [Column("origen")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Origen { get; set; }

        [InverseProperty("IdVillainNavigation")]
        public virtual ICollection<Enfrentamiento> Enfrentamientos { get; set; }
    }
}
