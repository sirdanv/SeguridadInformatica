using System.ComponentModel.DataAnnotations;

namespace SeguridadInformatica.Models
{
    public class Activos
    {
        public int ActivosId { get; set; }
        public String? Nombre { get; set; }
        public String?  Descripcion { get; set; }
        [Range(0, 10)]
        public int Valor { get; set; }
    }
}
