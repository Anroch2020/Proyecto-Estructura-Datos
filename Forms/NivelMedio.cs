using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;
using System.IO;
using Proyecto.Models;
using Proyecto.Services;
using Proyecto.Utilities;

namespace Proyecto
{
    public partial class NivelMedio : Form
    {
        private AudioManager? _audioManager;
        private bool _musicaActiva = true;

        private const int SudokuSize = 9;
        private const int BoxSize = 3;
        private const int CellSize = 40;
        private const int GridOffset = 10;

        private SudokuBoard _sudokuBoard;
        private GameTimer _gameTimer;
        private GameStats _gameStats;

        private readonly int[,] _sudokuMedio = {
            { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
            { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
            { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
            { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
            { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
            { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
            { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
            { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
        };

        private readonly bool[,] _posicionesFijas = {
            { true,  false, true,  true,  false, true,  false, true,  false },
            { true,  false, true,  false, true,  false, true,  false, true  },
            { true,  true,  false, true,  false, true,  false, false, true  },
            { true,  false, false, true,  true,  false, false, false, true  },
            { false, true,  true,  false, true,  false, true,  false, false },
            { true,  true,  false, true,  false, false, false, true,  false },
            { true,  false, true,  false, true,  false, true,  false, true  },
            { false, true,  false, true,  false, true,  false, true,  false },
            { true,  false, false, false, true,  false, true,  true,  true  }
        };

        public NivelMedio()
        {
            InitializeComponent();
            this.Paint += NivelMedio_Paint;
        }

        private void NivelMedio_Load(object sender, EventArgs e)
        {
            // Inicializar componentes del juego
            InicializarComponentes();

            // Inicializar la música ambiental
            InicializarMusicaAmbiental();
        }

        private void InicializarComponentes()
        {
            // Estilizar botones
            EstilizarBotones();

            // Inicializar tablero de Sudoku
            _sudokuBoard = new SudokuBoard(_sudokuMedio, _posicionesFijas, SudokuSize, BoxSize);
            _sudokuBoard.CrearCuadricula(this, CellSize, GridOffset, TextBox_KeyDown);
            _sudokuBoard.LlenarSudoku(TextBox_TextChanged, ValidarEntrada, TextBox_Enter);

            // Inicializar temporizador del juego
            _gameTimer = new GameTimer(timer1, lblTiempo);
            _gameTimer.Start();
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;

            // Inicializar estadísticas del juego
            _gameStats = new GameStats(lblErrores, LblpartidasG, LblpartidasP);
        }

        private void InicializarMusicaAmbiental()
        {
            try
            {
                // Liberamos cualquier instancia previa
                _audioManager?.Dispose();

                // Inicializamos con el archivo de audio del nivel medio
                _audioManager = new AudioManager("ambient-medium.wav");
                _audioManager.PlayLooping();
                _musicaActiva = true;

                AgregarControlMusica();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar la música ambiental: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Error al cargar la música ambiental: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarControlMusica()
        {
            Button btnMusica = new Button
            {
                Text = "🔊",
                Size = new Size(40, 40),
                Location = new Point(this.ClientSize.Width - 40, 10)
            };
            btnMusica.Click += (sender, e) =>
            {
                ToggleMusicaAmbiental();
                btnMusica.Text = _musicaActiva ? "🔊" : "🔇";
            };
            this.Controls.Add(btnMusica);
        }

        private void ToggleMusicaAmbiental()
        {
            if (_audioManager != null)
            {
                _audioManager.Toggle();
                _musicaActiva = _audioManager.IsPlaying;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _audioManager?.Dispose();
            base.OnFormClosing(e);
        }

        private void EstilizarBotones()
        {
            Color btnBackColor = Color.SandyBrown;
            Color btnMouseOver = Color.DarkSalmon;
            Color btnMouseDown = Color.Sienna;

            ConfigurarBoton(btnPausar, btnBackColor, btnMouseOver, btnMouseDown);
            ConfigurarBoton(btnReanudar, btnBackColor, btnMouseOver, btnMouseDown);
            ConfigurarBoton(btnReinicar, btnBackColor, btnMouseOver, btnMouseDown);
            ConfigurarBoton(btnSolucion, btnBackColor, btnMouseOver, btnMouseDown);
        }

        private void ConfigurarBoton(Button boton, Color backColor, Color mouseOver, Color mouseDown)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = backColor;
            boton.ForeColor = Color.White;
            boton.Font = new Font("Arial", 10, FontStyle.Bold);
            boton.FlatAppearance.MouseOverBackColor = mouseOver;
            boton.FlatAppearance.MouseDownBackColor = mouseDown;
        }

        private void TextBox_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox focusedTxt)
            {
                if (_sudokuBoard.FocusedTextBox != null && !_sudokuBoard.FocusedTextBox.ReadOnly)
                {
                    _sudokuBoard.FocusedTextBox.BackColor = Color.White;
                }
                _sudokuBoard.FocusedTextBox = focusedTxt;
                if (!_sudokuBoard.FocusedTextBox.ReadOnly)
                {
                    _sudokuBoard.FocusedTextBox.BackColor = Color.LightYellow;
                }
            }
        }

        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_sudokuBoard.ShowingSolution) return;

            if (sender is TextBox changedTxt && changedTxt.Tag is Point pos)
            {
                int fila = pos.X;
                int columna = pos.Y;

                if (!_posicionesFijas[fila, columna] && !string.IsNullOrEmpty(changedTxt.Text))
                {
                    changedTxt.ForeColor = Color.DarkBlue;
                }

                // Verificar si el sudoku está completo
                if (_sudokuBoard.EstaCompleto())
                {
                    VerificarJuego();
                }
            }
        }

        private void ValidarEntrada(object? sender, KeyPressEventArgs e)
        {
            if (sender is TextBox txt && txt.Tag is Point pos)
            {
                if (!char.IsDigit(e.KeyChar) || e.KeyChar == '0')
                {
                    if (e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    int fila = pos.X;
                    int columna = pos.Y;
                    int numeroIngresado = int.Parse(e.KeyChar.ToString());

                    if (!_sudokuBoard.EsNumeroValido(fila, columna, numeroIngresado))
                    {
                        e.Handled = true;
                        _gameStats.IncrementarErrores();
                        MessageBox.Show($"El número {numeroIngresado} no es válido en esta posición.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txt.BackColor = Color.LightCoral;
                        _sudokuBoard.ResaltarConflictos(fila, columna, numeroIngresado);

                        var timer = new System.Threading.Timer((obj) =>
                        {
                            txt.Invoke(new Action(() =>
                            {
                                if (!txt.ReadOnly) txt.BackColor = Color.White;
                                _sudokuBoard.RestaurarColores();
                            }));
                            ((System.Threading.Timer?)obj)?.Dispose();
                        }, null, 200, System.Threading.Timeout.Infinite);
                    }
                }
            }
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            _gameTimer.ActualizarDisplay();

            // Verificar tiempo límite (3 minutos)
            if (_gameTimer.ElapsedTime >= TimeSpan.FromMinutes(3))
            {
                PerderTiempo();
            }
        }

        private void VerificarJuego()
        {
            _gameTimer.Stop();

            if (_sudokuBoard.VerificarSolucion())
            {
                _gameStats.RegistrarVictoria();
                MessageBox.Show($"¡Felicidades! Has completado el Sudoku en {_gameTimer.ElapsedTime:hh\\:mm\\:ss} con {_gameStats.Errores} errores.",
                                "Victoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _gameStats.RegistrarDerrota();
                MessageBox.Show("El Sudoku no está resuelto correctamente. Intenta de nuevo.",
                                "Intento Fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _gameTimer.Start();
            }
        }

        private void PausarReanudar()
        {
            if (_gameTimer.IsPaused)
            {
                _gameTimer.Resume();
                btnPausar.Text = "Pausar";
                btnReanudar.Enabled = false;
            }
            else
            {
                _gameTimer.Pause();
                btnPausar.Text = "Pausado";
                btnReanudar.Enabled = true;
            }
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            PausarReanudar();
        }

        private void btnReanudar_Click(object sender, EventArgs e)
        {
            if (_gameTimer.IsPaused) PausarReanudar();
        }

        private void Reiniciar()
        {
            _gameTimer.Reset();
            _gameStats.Reiniciar();
            btnPausar.Text = "Pausar";
            btnReanudar.Enabled = false;
            _sudokuBoard.Reiniciar();
        }

        private void btnReinicar_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void SolucionSudoku()
        {
            _sudokuBoard.MostrarSolucion();
            _gameStats.RegistrarDerrota();
            MessageBox.Show("Se ha mostrado la solución. Esta partida se contará como perdida.",
                           "Solución Mostrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSolucion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres ver la solución? Se contará como una partida perdida.",
                                                 "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SolucionSudoku();
            }
        }

        private void NivelMedio_Paint(object? sender, PaintEventArgs e)
        {
            if (_sudokuBoard != null)
            {
                _sudokuBoard.DibujarCuadricula(e.Graphics, CellSize, GridOffset);
            }
        }

        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is TextBox txt && txt.Tag is Point pos)
            {
                int fila = pos.X;
                int columna = pos.Y;
                var textBoxes = _sudokuBoard.TextBoxes;

                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (columna > 0) textBoxes[fila, columna - 1].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Right:
                        if (columna < SudokuSize - 1) textBoxes[fila, columna + 1].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Up:
                        if (fila > 0) textBoxes[fila - 1, columna].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Down:
                        if (fila < SudokuSize - 1) textBoxes[fila + 1, columna].Focus();
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }

        private void PerderTiempo()
        {
            _gameTimer.Stop();
            _gameStats.RegistrarDerrota();
            MessageBox.Show("Se ha agotado el tiempo. Esta partida se contará como perdida.",
                          "Tiempo Agotado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
 along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
