using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Shared
{
    public class PersonasShared
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string WhatsApp { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Correo { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdRoles { get; set; } 

        public DateTime FechaRegitro { get; set; }

        public RolesShared? Roles { get; set; }
    }
}
