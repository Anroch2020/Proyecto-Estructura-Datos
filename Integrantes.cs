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