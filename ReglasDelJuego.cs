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
