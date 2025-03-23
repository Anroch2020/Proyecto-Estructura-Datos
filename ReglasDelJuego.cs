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
    public partial class ReglasDelJuego : Form
    {
        public ReglasDelJuego()
        {
            InitializeComponent();
            CargarReglas();
        }


        private void CargarReglas()
        {
            rtbReglas.Rtf = @"{\rtf1\ansi
         \b 1. Cuadrícula 9x9: \b0 El tablero está formado por 81 celdas, distribuidas en 9 filas y 9 columnas. Además, la cuadrícula se divide en 9 subcuadrículas de 3x3 celdas.\par
         \b 2. Números del 1 al 9: \b0 Cada fila, cada columna y cada subcuadrícula de 3x3 deben contener los números del 1 al 9, sin repetir ninguno dentro de la misma fila, columna ni subcuadrícula.\par
         \b 3. Celdas Prellenadas: \b0 Algunas celdas ya están llenas con números al iniciar el juego. Estos números son pistas que te ayudarán a completar el resto del tablero.\par
         \b 4. Objetivo: \b0 El objetivo del juego es llenar todas las celdas vacías con los números correctos, asegurándote de que no se repita ningún número en una fila, columna ni subcuadrícula.
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