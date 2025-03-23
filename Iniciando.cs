using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Iniciando : Form
    {
        private int progressValue = 0;

        public Iniciando()
        {
            InitializeComponent();
        }

        void Timer()
        {
            if (progressValue < 100)
            {
                progressValue += 5;
                progressBar1.Value = progressValue;
            }
            else
            {
                timer1.Stop();
                Intro mainForm = new Intro();
                mainForm.Show();
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer();
        }

        void Play()
        {
            BtnPlay.Enabled = false; // Desactiva el botón mientras carga
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressValue = 0;
            timer1.Start();
            
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

    }
}
