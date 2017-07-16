using lobby.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using lobby.Admin;

namespace lobby.Forms
{
    public partial class frmSplash : Form
    {
        int timeLeft;
        public frmSplash()
        {
            InitializeComponent();
            using (var db = new LobbyDB())
            {
                if (AdminUsuarios.TraerPorUsername("GLOPARDO") == null)
                {
                    Usuario usuario = new Usuario()
                    {
                        //Id = 1,
                        Nombre = "Gabriel",
                        Apellido = "Lopardo",
                        Username = "GLOPARDO",
                        Bloqueado = false,
                        Administrador = true,
                        Password = "R+4Yzfuz1Vf2hPnSFB3vfA==",
                        ActualizarPassword = false
                    };

                db.Usuarios.Add(usuario);
                db.SaveChanges();
                }
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timeLeft = 20;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
                timeLeft = timeLeft - 1;
            else
            {
                timer1.Stop();
                Hide();
                new frmMain().Show();
            }
        }
    }
}
