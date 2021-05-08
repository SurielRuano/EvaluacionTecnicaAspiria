using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JugueteriaFrontend.Models
{
    public class Producto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        [StringLength(50, ErrorMessage = "El {0} no puede exceder {1} caracteres. ")]
        public string Nombre { get; set; }
        [StringLength(100, ErrorMessage = "La {0} no puede exceder {1} caracteres. ")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [Range(0, 100, ErrorMessage = "La {0} debe ser entre {1} y {2}.")]
        [Display(Name = "Edad máxima")]
        public int? RestriccionEdad { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "La {0} no puede exceder {1} caracteres. ")]
        public string Compania { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        [Range(1, 1000, ErrorMessage = "El valor del {0} debe ser entre {1} y {2}.")]
        public decimal? Precio { get; set; }
    }
}
