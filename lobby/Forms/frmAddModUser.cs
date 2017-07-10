using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using lobby.Model;
using LobbySecurity;
using lobby.Admin;

namespace lobby.Forms
{
    public partial class frmAddModUser : Form
    {
        //borrar
        //public string clave = "cadenadecifrado";
        bool agrega;
        public frmAddModUser(bool add_, string name_, string lastName_, string username_, bool userIsLocked_, bool userIsAdmin_)
        {
            InitializeComponent();
            agrega = add_;

            if (!agrega)
            {
                this.Text = "Modificar usuario";
                btnAddModUser.Text = "Modificar";
                txbUserName.Enabled = false;

                txbUserName.Text = username_;
                txbName.Text = name_;
                txbLastName.Text = lastName_;
                cbIsAdmin.Checked = userIsAdmin_;
                cbLocked.Checked = userIsLocked_;
            }
        }

        

        private void btnAddModUser_Click(object sender, EventArgs e)
        {
            if (txbPassword.Text != "")
            {
                if (agrega)
                {
                    //Crear usuario
                    try
                    {
                        Usuario usuario = new Usuario()
                        {
                            Nombre = txbName.Text,
                            Apellido = txbLastName.Text,
                            Username = txbUserName.Text,
                            Password = Encrypter.Encrypt(txbPassword.Text),
                            Administrador = cbIsAdmin.Checked
                        };

                        AdminUsuarios.Crear(usuario);

                        MessageBox.Show(null, "Usuario creado con éxito", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(null, "Error al crear usuario", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //modificar usuario
                    Usuario usuario = new Usuario()
                    {
                        Nombre = txbName.Text,
                        Apellido = txbLastName.Text,
                        Password = Encrypter.Encrypt(txbPassword.Text),
                        Administrador = cbIsAdmin.Checked,
                        Bloqueado = cbLocked.Checked
                    };
                    AdminUsuarios.Modificar(usuario);
                    MessageBox.Show(null, "Usuario modificado con éxito", "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else
                MessageBox.Show("La contraseña no puede ser vacía", "Completar campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
