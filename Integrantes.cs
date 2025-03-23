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
    public partial class Integrantes : Form
    {
        public Integrantes()
        {
            InitializeComponent();  
            CargarIntegrantes();
        }

        private void CargarIntegrantes()
        {
            rtbIntegrantes.Rtf = @"{\rtf1\ansi
          \b Catedrático: \b0 Ing. Arnold Roberto Hernández\par
          \par
          \b Integrantes:\b0\par
             - Esmeralda Janeth Hernández Alfaro\par
             - Rosa Hayde Durón Brito\par
             - Ángel Roberto Chinchilla Erazo\par
             - Kennet Hernández Valle\par
             - Selvin Omar Castañeda\par
             - Ricardo Jose Pinto Mejia\par
          }";
        }
    }
}
