using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace pruevabooster1
{
    public partial class Messagebox : Form
    {
        public Messagebox()
        {
            InitializeComponent();
        }

        private void Messagebox_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            label1.Hide();
            timer1.Stop();
            circularProgressBar1.Value = 0;
            timer1.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 7;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 105;
            if (circularProgressBar1.Value == 105)
            {
                timer1.Stop();
                circularProgressBar1.Value = 0;
                pictureBox1.Show();
                circularProgressBar1.Hide();
                label1.Show();
            }

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Messagebox_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
