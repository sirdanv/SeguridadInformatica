using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeguridadInformatica.Models;

namespace SeguridadInformatica.Data
{
    public class SeguridadInformaticaContext : DbContext
    {
        public SeguridadInformaticaContext (DbContextOptions<SeguridadInformaticaContext> options)
            : base(options)
        {
        }

        public DbSet<SeguridadInformatica.Models.Activos> Activos { get; set; } = default!;

        public DbSet<SeguridadInformatica.Models.Dimensiones>? Dimensiones { get; set; }

        public DbSet<SeguridadInformatica.Models.Usuarios>? Usuarios { get; set; }
    }
}
