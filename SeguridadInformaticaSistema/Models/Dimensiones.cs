using System.ComponentModel.DataAnnotations;

namespace SeguridadInformatica.Models
{
    public class Dimensiones
    {
        [Key]
        public int DimesionesId { get; set; }
        public String? Tipo { get; set; }
        [Range(0, 10)]
        public int Valor { get; set; }

        public int ActivosId { get; set; }
        public Activos? Activos { get; set; }
    }
}
