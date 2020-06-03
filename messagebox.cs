using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pruevabooster1
{
    public partial class messagebox : Form
    {
        public messagebox()
        {
            InitializeComponent();
        }
        
        private void messagebox_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            BtnCerrar.Hide();
            button1.Hide();
            label1.Hide();
            timer1.Stop();
            circularProgressBar1.Value = 0;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 4;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                circularProgressBar1.Value = 0;
                label1.Show();
                BtnCerrar.Show();
                button1.Show();
                pictureBox1.Show();
                circularProgressBar1.Hide();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       


    }
}
