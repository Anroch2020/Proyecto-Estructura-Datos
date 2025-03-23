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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnIntegrantes_Click(object sender, EventArgs e)
        {
            Integrantes integrantes = new Integrantes();
            integrantes.ShowDialog();
        }

        private void btnReglas_Click(object sender, EventArgs e)
        {
            ReglasDelJuego reglas = new ReglasDelJuego();
            reglas.ShowDialog();
        }

        private void BtnFacil_Click(object sender, EventArgs e)
        {
            FormNivelFacil formNivelFacil = new FormNivelFacil();
            formNivelFacil.ShowDialog();
        }

    }
}
