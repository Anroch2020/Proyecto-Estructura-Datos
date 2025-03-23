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
/* Copyright (C) 2025 
 
             - Esmeralda Janeth Hernández Alfaro
             - Rosa Hayde Durón Brito
             - Ángel Roberto Chinchilla Erazo
             - Kennet Hernández Valle
             - Selvin Omar Castañeda
             - Ricardo Jose Pinto Mejia

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.*/