using System.Windows.Forms;

namespace lobby
{
    public partial class frmUpdateUserPassword : Form
    {
        hotelDataContext hotel = new hotelDataContext();
        public frmUpdateUserPassword(int userID_)
        {
            InitializeComponent();
            if (txbPassword.Text == txbConfirmPassword.Text)
            {
                hotel.spUpdateUserPassword(userID_, txbPassword.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Los passwords no coinciden", "Actualizar password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
