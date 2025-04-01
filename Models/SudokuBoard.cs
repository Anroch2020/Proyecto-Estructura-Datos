using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto.Models
{
    public class SudokuBoard
    {
        private readonly int[,] _solucion;
        private readonly bool[,] _posicionesFijas;
        private readonly TextBox[,] _textBoxes;
        private readonly int _size;
        private readonly int _boxSize;
        private bool _showingSolution = false;
        private TextBox? _focusedTextBox = null;

        public int Size => _size;
        public int BoxSize => _boxSize;
        public bool ShowingSolution => _showingSolution;
        public TextBox[,] TextBoxes => _textBoxes;
        public TextBox? FocusedTextBox
        {
            get => _focusedTextBox;
            set => _focusedTextBox = value;
        }

        public SudokuBoard(int[,] solucion, bool[,] posicionesFijas, int size = 9, int boxSize = 3)
        {
            _solucion = solucion;
            _posicionesFijas = posicionesFijas;
            _size = size;
            _boxSize = boxSize;
            _textBoxes = new TextBox[size, size];
        }

        public void CrearCuadricula(Form formulario, int cellSize, int offset, KeyEventHandler keyDownHandler)
        {
            int cellPadding = 2;
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    TextBox txt = new TextBox
                    {
                        Tag = new Point(fila, columna),
                        Size = new Size(cellSize - cellPadding * 2, cellSize - cellPadding * 2),
                        Location = new Point(columna * cellSize + offset + cellPadding,
                                          fila * cellSize + offset + cellPadding),
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        MaxLength = 1
                    };

                    txt.KeyDown += keyDownHandler;
                    _textBoxes[fila, columna] = txt;
                    formulario.Controls.Add(txt);
                }
            }
        }

        public void LlenarSudoku(EventHandler textChangedHandler, KeyPressEventHandler keyPressHandler, EventHandler enterHandler)
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    TextBox txt = _textBoxes[fila, columna];
                    txt.TextChanged -= textChangedHandler;
                    txt.KeyPress -= keyPressHandler;
                    txt.Enter -= enterHandler;

                    if (_posicionesFijas[fila, columna])
                    {
                        txt.Text = _solucion[fila, columna].ToString();
                        txt.ReadOnly = true;
                        txt.BackColor = Color.FromArgb(173, 216, 230);
                        txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        txt.Text = string.Empty;
                        txt.ReadOnly = false;
                        txt.BackColor = Color.White;
                        txt.ForeColor = Color.DarkBlue;
                        txt.KeyPress += keyPressHandler;
                    }

                    txt.TextChanged += textChangedHandler;
                    txt.Enter += enterHandler;
                }
            }
        }

        public void Reiniciar()
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    TextBox txt = _textBoxes[fila, columna];

                    if (_posicionesFijas[fila, columna])
                    {
                        txt.Text = _solucion[fila, columna].ToString();
                        txt.ReadOnly = true;
                        txt.BackColor = Color.FromArgb(173, 216, 230);
                        txt.ForeColor = Color.Black;
                        txt.Font = new Font("Arial", 14, FontStyle.Bold);
                    }
                    else
                    {
                        txt.Text = string.Empty;
                        txt.ReadOnly = false;
                        txt.BackColor = Color.White;
                        txt.ForeColor = Color.DarkBlue;
                        txt.Font = new Font("Arial", 14, FontStyle.Bold);
                    }
                }
            }
        }

        public bool VerificarSolucion()
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    if (string.IsNullOrEmpty(_textBoxes[fila, columna].Text) ||
                        int.Parse(_textBoxes[fila, columna].Text) != _solucion[fila, columna])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

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

        public void MostrarSolucion()
        {
            _showingSolution = true;
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    _textBoxes[fila, columna].Text = _solucion[fila, columna].ToString();
                    _textBoxes[fila, columna].ForeColor = Color.Green;
                    _textBoxes[fila, columna].Font = new Font("Arial", 14, FontStyle.Italic);
                }
            }
            _showingSolution = false;
        }

        public bool EsNumeroValido(int fila, int columna, int numero)
        {
            if (NumeroRepetido(fila, columna, numero))
                return false;

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

                    if (_textBoxes[currentRow, currentCol].Text == numero.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool NumeroRepetido(int fila, int columna, int numero)
        {
            for (int i = 0; i < _size; i++)
            {
                if (i != columna && _textBoxes[fila, i].Text == numero.ToString())
                {
                    return true;
                }
            }

            for (int i = 0; i < _size; i++)
            {
                if (i != fila && _textBoxes[i, columna].Text == numero.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public void ResaltarConflictos(int fila, int columna, int numero)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_textBoxes[fila, i].Text == numero.ToString())
                    _textBoxes[fila, i].BackColor = Color.LightCoral;
                if (_textBoxes[i, columna].Text == numero.ToString())
                    _textBoxes[i, columna].BackColor = Color.LightCoral;
            }

            int boxStartRow = (fila / _boxSize) * _boxSize;
            int boxStartCol = (columna / _boxSize) * _boxSize;
            for (int i = 0; i < _boxSize; i++)
            {
                for (int j = 0; j < _boxSize; j++)
                {
                    int currentRow = boxStartRow + i;
                    int currentCol = boxStartCol + j;
                    if (_textBoxes[currentRow, currentCol].Text == numero.ToString())
                    {
                        _textBoxes[currentRow, currentCol].BackColor = Color.LightCoral;
                    }
                }
            }
        }

        public void RestaurarColores()
        {
            for (int fila = 0; fila < _size; fila++)
            {
                for (int columna = 0; columna < _size; columna++)
                {
                    TextBox txt = _textBoxes[fila, columna];
                    if (txt.ReadOnly)
                    {
                        txt.BackColor = Color.FromArgb(173, 216, 230);
                    }
                    else
                    {
                        txt.BackColor = (txt == _focusedTextBox) ? Color.LightYellow : Color.White;
                    }
                }
            }
        }

        public void DibujarCuadricula(Graphics g, int cellSize, int offset)
        {
            using (Pen penThick = new Pen(Color.FromArgb(50, 50, 50), 3))
            using (Pen penThin = new Pen(Color.FromArgb(150, 150, 150), 1))
            {
                int tamañoSudoku = cellSize * _size;

                for (int i = 0; i <= _size; i += _boxSize)
                {
                    g.DrawLine(penThick, i * cellSize + offset, offset,
                              i * cellSize + offset, tamañoSudoku + offset);
                    g.DrawLine(penThick, offset, i * cellSize + offset,
                              tamañoSudoku + offset, i * cellSize + offset);
                }

                for (int i = 1; i < _size; i++)
                {
                    if (i % _boxSize != 0)
                    {
                        g.DrawLine(penThin, i * cellSize + offset, offset,
                                  i * cellSize + offset, tamañoSudoku + offset);
                        g.DrawLine(penThin, offset, i * cellSize + offset,
                                  tamañoSudoku + offset, i * cellSize + offset);
                    }
                }
            }
        }
    }
}

