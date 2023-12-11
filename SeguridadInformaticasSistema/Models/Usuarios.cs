using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeguridadInformatica.Models
{
    public class Usuarios
    {
        public int UsuariosId { get; set; }

        [Required(ErrorMessage = "El campo Empresa es obligatorio.")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "El campo Cargo es obligatorio.")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

    }
}
