using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace torneos.Models
{
    public class Equipo
    {
        [Key]
        public int EquipoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Disciplina { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Categoria { get; set; }

        //Llave foranea para la relacion uno a uno con Entrenador
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Index("IndexEntrenador", IsUnique = true)]
        public int EntrenadorId { get; set; }
        //Propiedad navigacional para la relación con Entrenador
        public virtual Entrenador Entrenador { get; set; }

        //Propiedad navigacional para la relacion con TorneoEquipo
        public virtual ICollection<TorneoEquipo> TorneoEquipos { get; set; }

        //Propiedad navigacional para la relacion con Deportista
        public virtual ICollection<Deportista> Deportistas { get; set; }

    }
}