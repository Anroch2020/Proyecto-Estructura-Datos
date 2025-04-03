using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto.Models
{
    /// <summary>
    /// Representa un tablero de Sudoku con su lógica de juego
    /// </summary>
    public class SudokuBoard
    {
        #region Campos estáticos y constantes

        // Colores predefinidos para los diferentes estados de las celdas
        private static readonly Color ColorCeldaFija = Color.FromArgb(173, 216, 230);
        private static readonly Color ColorCeldaSeleccionada = Color.LightYellow;
        private static readonly Color ColorCeldaError = Color.LightCoral;
        private static readonly Color ColorTextoCelda = Color.DarkBlue;
        private static readonly Color ColorTextoCeldaFija = Color.Black;
        private static readonly Color ColorTextoSolucion = Color.Green;

        // Estilos de texto
        private static readonly Font FuenteNormal = new Font("Arial", 14, FontStyle.Bold);
        private static readonly Font FuenteSolucion = new Font("Arial", 14, FontStyle.Italic);

        // Estilos de líneas para dibujar la cuadrícula
        private static readonly Color ColorLineaGruesa = Color.FromArgb(50, 50, 50);
        private static readonly Color ColorLineaFina = Color.FromArgb(150, 150, 150);
        private const float AnchoLineaGruesa = 3f;
        private const float AnchoLineaFina = 1f;

        #endregion

        #region Campos privados

        private readonly int[,] _solucion;
        private readonly bool[,] _posicionesFijas;
        private readonly TextBox[,] _textBoxes;
        private readonly int _size;
        private readonly int _boxSize;
        private bool _showingSolution = false;
        private TextBox? _focusedTextBox = null;

        #endregion

        #region Propiedades

        /// <summary>
        /// Tamaño del tablero (por defecto 9x9)
        /// </summary>
        public int Size => _size;

        /// <summary>
        /// Tamaño de cada subcuadrícula (por defecto 3x3)
        /// </summary>
        public int BoxSize => _boxSize;

        /// <summary>
        /// Indica si se está mostrando la solución actualmente
        /// </summary>
        public bool ShowingSolution => _showingSolution;

        /// <summary>
        /// Matriz de TextBox que componen el tablero
        /// </summary>
        public TextBox[,] TextBoxes => _textBoxes;

        /// <summary>
        /// TextBox que tiene el foco actualmente
        /// </summary>
        public TextBox? FocusedTextBox
        {
            get => _focusedTextBox;
            set => _focusedTextBox = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Crea un nuevo tablero de Sudoku
        /// </summary>
        /// <param name="solucion">Matriz con la solución final del sudoku</param>
        /// <param name="posicionesFijas">Matriz que indica qué celdas son fijas (pistas)</param>
        /// <param name="size">Tamaño del tablero (default: 9)</param>
        /// <param name="boxSize">Tamaño de cada subcuadrícula (default: 3)</param>
        public SudokuBoard(int[,] solucion, bool[,] posicionesFijas, int size = 9, int boxSize = 3)
        {
            _solucion = solucion;
            _posicionesFijas = posicionesFijas;
            _size = size;
            _boxSize = boxSize;
            _textBoxes = new TextBox[size, size];
        }

        #endregion

        #region Inicialización del tablero

        /// <summary>
        /// Crea la cuadrícula visual del tablero de Sudoku en el formulario
        /// </summary>
        public void CrearCuadricula(Form formulario, int cellSize, int offset, KeyEventHandler keyDownHandler)
        {
            // Utilizar un FlowLayoutPanel para mejorar el rendimiento al añadir controles
            const int cellPadding = 2;

            // Crear los TextBox para cada celda
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    var txt = CrearCeldaSudoku(fila, columna, cellSize, cellPadding, offset);
                    txt.KeyDown += keyDownHandler;
                    _textBoxes[fila, columna] = txt;
                    formulario.Controls.Add(txt);
                }
            }
        }

        /// <summary>
        /// Crea un TextBox configurado para una celda del sudoku
        /// </summary>
        private TextBox CrearCeldaSudoku(int fila, int columna, int cellSize, int cellPadding, int offset)
        {
            return new TextBox
            {
                Tag = new Point(fila, columna),
                Size = new Size(cellSize - cellPadding * 2, cellSize - cellPadding * 2),
                Location = new Point(columna * cellSize + offset + cellPadding,
                                  fila * cellSize + offset + cellPadding),
                TextAlign = HorizontalAlignment.Center,
                Font = FuenteNormal,
                MaxLength = 1,
                TabStop = false // Mejora la experiencia de navegación con teclado
            };
        }

        /// <summary>
        /// Llena el tablero con los valores iniciales y configura los manejadores de eventos
        /// </summary>
        public void LlenarSudoku(EventHandler textChangedHandler, KeyPressEventHandler keyPressHandler, EventHandler enterHandler)
        {
            // Desuscribir eventos antes de configurar (para evitar disparar eventos no deseados)
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    TextBox txt = _textBoxes[fila, columna];
                    DesuscribirEventos(txt, textChangedHandler, keyPressHandler, enterHandler);
                    ConfigurarCelda(txt, fila, columna, keyPressHandler);
                    SuscribirEventos(txt, textChangedHandler, enterHandler);
                }
            }
        }

        /// <summary>
        /// Desuscribe los manejadores de eventos de un TextBox
        /// </summary>
        private void DesuscribirEventos(TextBox txt, EventHandler textChangedHandler, KeyPressEventHandler keyPressHandler, EventHandler enterHandler)
        {
            txt.TextChanged -= textChangedHandler;
            txt.KeyPress -= keyPressHandler;
            txt.Enter -= enterHandler;
        }

        /// <summary>
        /// Configura una celda según sea fija o editable
        /// </summary>
        private void ConfigurarCelda(TextBox txt, int fila, int columna, KeyPressEventHandler keyPressHandler)
        {
            if (_posicionesFijas[fila, columna])
            {
                ConfigurarCeldaFija(txt, fila, columna);
            }
            else
            {
                ConfigurarCeldaEditable(txt, keyPressHandler);
            }
        }

        /// <summary>
        /// Configura una celda fija (no editable) del sudoku
        /// </summary>
        private void ConfigurarCeldaFija(TextBox txt, int fila, int columna)
        {
            txt.Text = _solucion[fila, columna].ToString();
            txt.ReadOnly = true;
            txt.BackColor = ColorCeldaFija;
            txt.ForeColor = ColorTextoCeldaFija;
        }

        /// <summary>
        /// Configura una celda editable del sudoku
        /// </summary>
        private void ConfigurarCeldaEditable(TextBox txt, KeyPressEventHandler keyPressHandler)
        {
            txt.Text = string.Empty;
            txt.ReadOnly = false;
            txt.BackColor = Color.White;
            txt.ForeColor = ColorTextoCelda;
            txt.KeyPress += keyPressHandler;
        }

        /// <summary>
        /// Suscribe los manejadores de eventos comunes a un TextBox
        /// </summary>
        private void SuscribirEventos(TextBox txt, EventHandler textChangedHandler, EventHandler enterHandler)
        {
            txt.TextChanged += textChangedHandler;
            txt.Enter += enterHandler;
        }

        #endregion

        #region Gestión del juego

        /// <summary>
        /// Reinicia el tablero a su estado inicial
        /// </summary>
        public void Reiniciar()
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    TextBox txt = _textBoxes[fila, columna];

                    if (_posicionesFijas[fila, columna])
                    {
                        ConfigurarCeldaReinicio(txt, fila, columna, true);
                    }
                    else
                    {
                        ConfigurarCeldaReinicio(txt, fila, columna, false);
                    }
                }
            }
        }

        /// <summary>
        /// Configura una celda durante el reinicio del juego
        /// </summary>
        private void ConfigurarCeldaReinicio(TextBox txt, int fila, int columna, bool esFija)
        {
            if (esFija)
            {
                txt.Text = _solucion[fila, columna].ToString();
                txt.ReadOnly = true;
                txt.BackColor = ColorCeldaFija;
                txt.ForeColor = ColorTextoCeldaFija;
            }
            else
            {
                txt.Text = string.Empty;
                txt.ReadOnly = false;
                txt.BackColor = Color.White;
                txt.ForeColor = ColorTextoCelda;
            }
            txt.Font = FuenteNormal;
        }

        /// <summary>
        /// Verifica si la solución actual es correcta
        /// </summary>
        public bool VerificarSolucion()
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    string texto = _textBoxes[fila, columna].Text;
                    if (string.IsNullOrEmpty(texto) ||
                        !int.TryParse(texto, out int valor) ||
                        valor != _solucion[fila, columna])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica si todas las celdas del tablero están llenas
        /// </summary>
        public bool EstaCompleto()
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    if (string.IsNullOrEmpty(_textBoxes[fila, columna].Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Muestra la solución completa del sudoku
        /// </summary>
        public void MostrarSolucion()
        {
            try
            {
                _showingSolution = true;

                for (int fila = 0; fila < _size; fila++)
                {
                    for (int columna = 0; columna < _size; columna++)
                    {
                        var txt = _textBoxes[fila, columna];
                        txt.Text = _solucion[fila, columna].ToString();
                        txt.ForeColor = ColorTextoSolucion;
                        txt.Font = FuenteSolucion;
                    }
                }
            }
            finally
            {
                _showingSolution = false;
            }
        }

        #endregion

        #region Validación de reglas

        /// <summary>
        /// Verifica si un número es válido según las reglas del Sudoku
        /// </summary>
        public bool EsNumeroValido(int fila, int columna, int numero)
        {
            // Primero verificamos filas y columnas (es más rápido)
            if (NumeroRepetido(fila, columna, numero))
                return false;

            // Luego verificamos la subcuadrícula (es más costoso)
            return !NumeroRepetidoEnRegion(fila, columna, numero);
        }

        /// <summary>
        /// Verifica si un número ya existe en la misma fila o columna
        /// </summary>
        private bool NumeroRepetido(int fila, int columna, int numero)
        {
            string numeroStr = numero.ToString();

            // Verificar fila
            for (int i = 0; i < _size; i++)
            {
                if (i != columna && _textBoxes[fila, i].Text == numeroStr)
                {
                    return true;
                }
            }

            // Verificar columna
            for (int i = 0; i < _size; i++)
            {
                if (i != fila && _textBoxes[i, columna].Text == numeroStr)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si un número ya existe en la misma región (subcuadrícula)
        /// </summary>
        private bool NumeroRepetidoEnRegion(int fila, int columna, int numero)
        {
            string numeroStr = numero.ToString();
            int boxStartRow = (fila / _boxSize) * _boxSize;
            int boxStartCol = (columna / _boxSize) * _boxSize;

            for (int i = 0; i < _boxSize; i++)
            {
                for (int j = 0; j < _boxSize; j++)
                {
                    int currentRow = boxStartRow + i;
                    int currentCol = boxStartCol + j;

                    if (currentRow == fila && currentCol == columna)
                        continue;

                    if (_textBoxes[currentRow, currentCol].Text == numeroStr)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Resaltado visual

        /// <summary>
        /// Resalta las celdas que tienen conflicto con un número ingresado
        /// </summary>
        public void ResaltarConflictos(int fila, int columna, int numero)
        {
            string numeroStr = numero.ToString();

            // Resaltar conflictos en fila y columna
            for (int i = 0; i < _size; i++)
            {
                if (_textBoxes[fila, i].Text == numeroStr)
                    _textBoxes[fila, i].BackColor = ColorCeldaError;

                if (_textBoxes[i, columna].Text == numeroStr)
                    _textBoxes[i, columna].BackColor = ColorCeldaError;
            }

            // Resaltar conflictos en la región
            int boxStartRow = (fila / _boxSize) * _boxSize;
            int boxStartCol = (columna / _boxSize) * _boxSize;

            for (int i = 0; i < _boxSize; i++)
            {
                for (int j = 0; j < _boxSize; j++)
                {
                    int currentRow = boxStartRow + i;
                    int currentCol = boxStartCol + j;

                    if (_textBoxes[currentRow, currentCol].Text == numeroStr)
                    {
                        _textBoxes[currentRow, currentCol].BackColor = ColorCeldaError;
                    }
                }
            }
        }

        /// <summary>
        /// Restaura los colores originales de las celdas
        /// </summary>
        public void RestaurarColores()
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    TextBox txt = _textBoxes[fila, columna];

                    if (txt.ReadOnly)
                    {
                        txt.BackColor = ColorCeldaFija;
                    }
                    else
                    {
                        txt.BackColor = (txt == _focusedTextBox) ? ColorCeldaSeleccionada : Color.White;
                    }
                }
            }
        }

        #endregion

        #region Dibujo de cuadrícula

        /// <summary>
        /// Dibuja la cuadrícula del Sudoku sobre el gráfico proporcionado
        /// </summary>
        public void DibujarCuadricula(Graphics g, int cellSize, int offset)
        {
            if (g == null) return;

            int tamañoSudoku = cellSize * _size;

            // Usar objetos cache para evitar recrear pens constantemente
            using (Pen penThick = new Pen(ColorLineaGruesa, AnchoLineaGruesa))
            using (Pen penThin = new Pen(ColorLineaFina, AnchoLineaFina))
            {
                // Dibujar líneas gruesas (bordes de regiones)
                DibujarLineasGruesas(g, penThick, cellSize, offset, tamañoSudoku);

                // Dibujar líneas delgadas (separadores de celdas)
                DibujarLineasFinas(g, penThin, cellSize, offset, tamañoSudoku);
            }
        }

        /// <summary>
        /// Dibuja las líneas gruesas que delimitan las regiones
        /// </summary>
        private void DibujarLineasGruesas(Graphics g, Pen pen, int cellSize, int offset, int tamañoSudoku)
        {
            for (int i = 0; i <= _size; i += _boxSize)
            {
                // Línea vertical
                g.DrawLine(
                    pen,
                    i * cellSize + offset, offset,
                    i * cellSize + offset, tamañoSudoku + offset
                );

                // Línea horizontal
                g.DrawLine(
                    pen,
                    offset, i * cellSize + offset,
                    tamañoSudoku + offset, i * cellSize + offset
                );
            }
        }

        /// <summary>
        /// Dibuja las líneas finas que separan las celdas
        /// </summary>
        private void DibujarLineasFinas(Graphics g, Pen pen, int cellSize, int offset, int tamañoSudoku)
        {
            for (int i = 1; i < _size; i++)
            {
                if (i % _boxSize != 0)
                {
                    // Línea vertical
                    g.DrawLine(
                        pen,
                        i * cellSize + offset, offset,
                        i * cellSize + offset, tamañoSudoku + offset
                    );

                    // Línea horizontal
                    g.DrawLine(
                        pen,
                        offset, i * cellSize + offset,
                        tamañoSudoku + offset, i * cellSize + offset
                    );
                }
            }
        }

        #endregion
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