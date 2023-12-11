using System.ComponentModel.DataAnnotations;

namespace SeguridadInformatica.Models
{
    public class Dimensiones
    {
        public int DimensionesId { get; set; }
        
        [Required(ErrorMessage = "El campo tipo de disponibilidad es obligatorio.")]
        [Range(0, 10)]
        public int Disponibilidad { get; set; }

        [Required(ErrorMessage = "El campo tipo de disponibilidad es obligatorio.")]
        [Range(0, 10)]
        public int Integridad { get; set; }

        [Required(ErrorMessage = "El campo tipo de disponibilidad es obligatorio.")]
        [Range(0, 10)]
        public int Confidencialidad { get; set; }

        public int Evaluacion { get; set; }

        [Required(ErrorMessage = "El campo seleccione usuario es obligatorio.")]
        public String UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set; }

        [Required(ErrorMessage = "El campo seleccione activo es obligatorio.")]
        public String ActivosId { get; set; }
        public Activos? Activos { get; set; }
    }
}
