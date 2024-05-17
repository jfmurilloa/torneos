using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace torneos.Models
{
    public class Entrenador
    {
        [Key]
        public int EntrenadorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Index("IndexDocumento", IsUnique = true)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Apellidos { get; set; }

        public string FullName { get{ return (this.Nombres + " " + this.Apellidos); } }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Rh { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Eps { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Arl { get; set; }

        [StringLength(10, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(3000000000,3999999999,ErrorMessage ="En el campo {0} debe ingresar valores entre {1} y {2} ")]
        public string Celular { get; set; }

        //propiedad navigacional para la relación con Equipo
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}