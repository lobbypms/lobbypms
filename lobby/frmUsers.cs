using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmUsers : Form
    {
        int globalUserID;
        public frmUsers(int glbUserID_)
        {
            InitializeComponent();
            globalUserID = glbUserID_;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'lobbyDataSet.USUARIOS' Puede moverla o quitarla según sea necesario.
            this.uSUARIOSTableAdapter1.Fill(this.lobbyDataSet.USUARIOS);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddModUser formAddUser = new frmAddModUser(true, "", "", "", false, false);
            formAddUser.ShowDialog();
            this.uSUARIOSTableAdapter1.Fill(this.lobbyDataSet.USUARIOS);
        }

        private void btnModUser_Click(object sender, EventArgs e)
        {
        if (dgvUsers.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgvUsers.SelectedRows[0];
                string name = row.Cells[0].Value.ToString();
                string lastName = row.Cells[1].Value.ToString();
                string username = row.Cells[2].Value.ToString();
                bool isLocked = Convert.ToBoolean(row.Cells[3].Value);
                bool isAdmin = Convert.ToBoolean(row.Cells[4].Value);

                frmAddModUser formAddModUser = new frmAddModUser(false, name, lastName, username, isLocked, isAdmin);

                if (username == "GLOPARDO")
                {
                    if (globalUserID == 1)
                    {
                        formAddModUser.ShowDialog();
                        this.uSUARIOSTableAdapter1.Fill(this.lobbyDataSet.USUARIOS);
                    }
                    else
                        MessageBox.Show("Su usuario no posee los privilegios necesarios para modificar a este usuario", "Error al modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    formAddModUser.ShowDialog();
                    this.uSUARIOSTableAdapter1.Fill(this.lobbyDataSet.USUARIOS);
                }
            }
        }
    }
}
