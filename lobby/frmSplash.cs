using System;
using System.Windows.Forms;

namespace lobby
{
    public partial class frmSplash : Form
    {
        int timeLeft;
        public frmSplash()
        {
            InitializeComponent();
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
