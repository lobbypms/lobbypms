using lobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lobby.Admin
{
    public static class AdminPerfiles
    {
        #region Methods
        public static List<Perfil> TraerTodos()
        {
            LobbyDB db = new LobbyDB();
            return db.Perfiles.ToList();
        }
        public static Perfil TraerPorDocumento(string documento)
        {
            LobbyDB db = new LobbyDB();
            return db.Perfiles.Where(p => p.NumeroDocumento == documento).FirstOrDefault();
        }
        public static string TraerEmailPorIdReserva(int resvId)
        {
            LobbyDB db = new LobbyDB();
            return (from r in db.Reservas
                    join p in db.Perfiles on r.HuespedID equals p.Id
                    where r.Id == resvId
                    select p.Email).Single();
        }
        public static Perfil TraerPorId(int id)
        {
            LobbyDB db = new LobbyDB();
            return db.Perfiles.Where(p => p.Id == id).Single();
        }
        public static List<Perfil> TraerPorDocumentoOApellido(string documento, string apellido)
        {
            LobbyDB db = new LobbyDB();
            return db.Perfiles.Where(p => p.NumeroDocumento == documento || p.Apellido.Contains(apellido)).ToList();
        }
        public static void Modificar(Perfil perfil)
        {
            LobbyDB db = new LobbyDB();
            Perfil perf = db.Perfiles.Where(p => p.Id == perfil.Id).Single();
            perf = perfil;
            db.SaveChanges();
        }
        public static int Crear(Perfil perfil)
        {
            LobbyDB db = new LobbyDB();
            db.Perfiles.Add(perfil);
            db.SaveChanges();
            return (from p in db.Perfiles
                    orderby p.Id descending
                    select p.Id).First();
        }
        #endregion
    }
}
