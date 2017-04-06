using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            label1.Text = "Lobby PMS v" + version.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/gabriel-lopardo-58265435?trk=hp-identity-name");
        }
    }
}
