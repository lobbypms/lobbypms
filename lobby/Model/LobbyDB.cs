using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using lobby.Model;

namespace lobby.Model
{
    public class LobbyDB : DbContext
    {
        //static LobbyDB()  // runs once
        //{
        //    Database.SetInitializer<LobbyDB>(new CreateDatabaseIfNotExists<LobbyDB>());
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public LobbyDB() : base("Data Source=.\\LOBBYSERVER;Initial Catalog=lobby;User ID=sa;Password=lobbypms")
        {
        }

        public DbSet<CodigoTransaccion> CodigosTransacciones { get; set; }
        public DbSet<CotMonExtr> CotMonExtrs { get; set; }
        public DbSet<ctGrupo> ctGrupos { get; set; }
        public DbSet<ctSubgrupo> ctSubgrupos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<TipoHabitacion> HabitacionTipos { get; set; }
        public DbSet<MonedaExtranjera> MonedaExtranjeras { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Patente> Patentes { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Propiedad> Propiedad { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<RangoFiscal> RangosFiscales { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaNoche> ReservasNoches { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
