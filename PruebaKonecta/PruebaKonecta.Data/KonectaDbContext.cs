using System.Data.Entity;
using PruebaKonecta.Core; // Referencia a la capa Core

namespace PruebaKonecta.Data
{
    public class KonectaDbContext : DbContext
    {
        public KonectaDbContext() : base("name=CadenaSQL")
        {
        }

        public DbSet<Colaborador> Colaboradores { get; set; }

    }
}
