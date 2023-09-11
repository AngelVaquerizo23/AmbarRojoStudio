using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Shared
{
    public class PersonaShared
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo{0} es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "Debe poner un telefono")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "Favor de agregar un numero de WhatsApp")]
        public string WhatsApp { get; set; } = null!;

        [Required(ErrorMessage = "Agrege un correo electronico")]
        public string Correo { get; set; } = null!;

        public DateTime FechaRegistro { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public string IdRoles { get; set; } = null!; 

        public RolesShared? roles { get; set; }
    }
}