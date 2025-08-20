using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using PruebaKonecta.Core;

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
