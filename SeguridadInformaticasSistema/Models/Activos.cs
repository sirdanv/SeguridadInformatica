using System.ComponentModel.DataAnnotations;

namespace SeguridadInformatica.Models
{
    public class Activos
    {
        public int ActivosId { get; set; }
        
        [Required(ErrorMessage = "El campo Tipo de activo es obligatorio.")]
        public String Tipo { get; set; }
        
        [Required(ErrorMessage = "El campo peso de disponibilida es obligatorio.")]
        [Range(0.0, 1.0)]
        public float Disponibilidad { get; set; }
        
        [Required(ErrorMessage = "El campo peso de integridad es obligatorio.")]
        [Range(0.0, 1.0)]
        public float Integridad { get; set; }
        
        [Required(ErrorMessage = "El campo peso de confidencialidad es obligatorio.")]
        [Range(0.0, 1.0)]
        public float Confidencialidad { get; set; }
        
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        public String Descripcion { get; set; }
        
        [Required(ErrorMessage = "ELcampo selecionar usuario es obligatorio.")]
        public String UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set; }
    }
}
