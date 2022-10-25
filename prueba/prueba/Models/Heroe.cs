using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    [Table("HEROE")]
    public partial class Heroe
    {
        public Heroe()
        {
            Enfrentamientos = new HashSet<Enfrentamiento>();
            Patrocinas = new HashSet<Patrocina>();
            Relaciones = new HashSet<Relacione>();
        }

        [Key]
        [Column("Id_hero")]
        public int IdHero { get; set; }
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
        [Column("disponibilidad", TypeName = "date")]
        public DateTime? Disponibilidad { get; set; }

        [InverseProperty("IdHeroNavigation")]
        public virtual ICollection<Enfrentamiento> Enfrentamientos { get; set; }
        [InverseProperty("IdHeroNavigation")]
        public virtual ICollection<Patrocina> Patrocinas { get; set; }
        [InverseProperty("IdHeroNavigation")]
        public virtual ICollection<Relacione> Relaciones { get; set; }
    }
}
