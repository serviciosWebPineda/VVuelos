using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V_Vuelo.Models;

namespace V_Vuelo.Data
{
    public class VuelosContext : DbContext
    {
        public VuelosContext(DbContextOptions<VuelosContext> options) : base(options)
        {
        }

        public DbSet<FavoriteBand> FavoriteBands { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Consecutivos> Consecutivos { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Aerolinea> Aerolineas { get; set; }
        public DbSet<Puerta> Puertas { get; set; }
    }
}
