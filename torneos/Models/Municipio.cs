using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace torneos.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [StringLength(30, MinimumLength =4, ErrorMessage ="El campo {0} debe tener entre {2} y {1} caracteres")]
        [Index("IndexNombre", IsUnique = true)]
        [DisplayName("Nombre Municipio")]
        public string Nombre { get; set; }

        //atributo virtual para la relación con Torneo
        public virtual ICollection<Torneo> Torneos { get; set; }
    }
}