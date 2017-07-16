using lobby.Admin;
using lobby.Model;
using System.Windows.Forms;

namespace lobby.Forms
{
    public partial class frmUpdateUserPassword : Form
    {
        public frmUpdateUserPassword(int userID_)
        {
            InitializeComponent();
            if (txbPassword.Text == txbConfirmPassword.Text)
            {
                Usuario usuario = new Usuario()
                {
                    Id = userID_,
                    Password = txbPassword.Text
                };

                AdminUsuarios.Modificar(usuario);
                this.Close();
            }
            else
            {
                MessageBox.Show("Los passwords no coinciden", "Actualizar password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
