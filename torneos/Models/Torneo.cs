using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Foolproof;

namespace torneos.Models
{
    public class Torneo
    {
        [Key]
        public int TorneoId { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(25,MinimumLength =6, ErrorMessage ="El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres ")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [GreaterThan("FechaInicio", ErrorMessage = "El campo {0} debe ser mayor que {1}")]
        public DateTime FechaFin {  get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CantidadEquipos { get; set; }

        //Llave foranea para la relación con Municipio
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }

        //Propiedad navigacional para la relacion con TorneoEquipo
        public virtual ICollection<TorneoEquipo> TorneoEquipos { get; set; }
    }
}