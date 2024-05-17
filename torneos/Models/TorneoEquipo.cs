using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace torneos.Models
{
    public class TorneoEquipo
    {
        [Key]
        public int TorneoEquipoId { get; set; }
        //Llave foranea para la relación con Torneo
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int TorneoId { get; set; }
        //Llave foranea para la relación con Equipo
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int EquipoId { get; set; }

        //propiedad navigacional para la relación con Torneo
        public virtual Torneo Torneo { get; set; }

        //propiedad navigacional para la relación con Equipo
        public virtual Equipo Equipo { get; set; }
    }
}