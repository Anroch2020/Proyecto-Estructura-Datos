using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Proyecto.Models;
using Proyecto.Services;
using Proyecto.Utilities;

namespace Proyecto
{
    public partial class NivelDificil : Form
    {
        #region Constantes y campos estáticos

        // Constantes del juego
        private const int SudokuSize = 9;
        private const int BoxSize = 3;
        private const int CellSize = 40;
        private const int GridOffset = 10;
        private const int TiempoLimiteMinutos = 2; // Tiempo más corto para el nivel difícil

        // Colores predefinidos
        private static readonly Color ColorCeldaFija = Color.FromArgb(173, 216, 230);
        private static readonly Color ColorCeldaSeleccionada = Color.LightYellow;
        private static readonly Color ColorCeldaError = Color.LightCoral;
        private static readonly Color ColorTextoNormal = Color.DarkBlue;
        private static readonly Color ColorTextoFijo = Color.Black;
        private static readonly Color ColorTextoSolucion = Color.Green;
        private static readonly Color ColorBoton = Color.IndianRed;
        private static readonly Color ColorBotonHover = Color.Firebrick;
        private static readonly Color ColorBotonPress = Color.DarkRed;

        #endregion

        #region Campos privados

        private AudioManager? _audioManager;
        private bool _musicaActiva = true;
        private SudokuBoard _sudokuBoard;
        private GameTimer _gameTimer;
        private GameStats _gameStats;
        private System.Windows.Forms.Timer _restoreColorsTimer;

        private readonly int[,] _sudokuDificil = {
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
            { false, true,  false, true,  false, false, true,  false, false },
            { false, false, false, false, true,  false, false, false, true },
            { true,  false, false, false, false, false, false, false, true },
            { false, false, true,  false, false, true,  false, false, false },
            { false, true,  false, true,  true,  false, true,  false, false },
            { false, false, false, true,  false, false, true,  false, true },
            { true,  false, true,  false, false, true,  false, false, true },
            { false, false, false, false, true,  false, false, true,  false },
            { false, true,  false, false, false, false, false, true,  false }
        };

        #endregion

        #region Inicialización

        /// <summary>
        /// Constructor del formulario de nivel difícil
        /// </summary>
        public NivelDificil()
        {
            InitializeComponent();

            // Inicializar temporizador reutilizable para restauración de colores
            _restoreColorsTimer = new System.Windows.Forms.Timer()
            {
                Interval = 200,
                Enabled = false
            };

            _restoreColorsTimer.Tick += (s, e) => {
                _sudokuBoard?.RestaurarColores();
                _restoreColorsTimer.Stop();
            };
        }

        /// <summary>
        /// Evento de carga del formulario
        /// </summary>
        private void NivelDificil_Load(object sender, EventArgs e)
        {
            InicializarComponentes();
            InicializarMusicaAmbiental();
        }

        /// <summary>
        /// Inicializa todos los componentes del juego
        /// </summary>
        private void InicializarComponentes()
        {
            // Estilizar botones
            EstilizarBotones();

            // Inicializar tablero de Sudoku
            _sudokuBoard = new SudokuBoard(_sudokuDificil, _posicionesFijas, SudokuSize, BoxSize);
            _sudokuBoard.CrearCuadricula(this, CellSize, GridOffset, TextBox_KeyDown);
            _sudokuBoard.LlenarSudoku(TextBox_TextChanged, ValidarEntrada, TextBox_Enter);

            // Inicializar temporizador del juego
            _gameTimer = new GameTimer(timer1, lblTiempo);
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            _gameTimer.Start();

            // Inicializar estadísticas del juego
            _gameStats = new GameStats(lblErrores, LblpartidasG, LblpartidasP);
        }

        #endregion

        #region Música ambiental

        /// <summary>
        /// Inicializa la música ambiental del juego
        /// </summary>
        private void InicializarMusicaAmbiental()
        {
            try
            {
                _audioManager?.Dispose();
                _audioManager = new AudioManager("ambient-hard.wav");
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

        /// <summary>
        /// Agrega el botón de control de música a la interfaz
        /// </summary>
        private void AgregarControlMusica()
        {
            Button btnMusica = new Button
            {
                Text = "🔊",
                Size = new Size(40, 40),
                Location = new Point(ClientSize.Width - 50, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(220, 20, 60), // Rojo intenso para este nivel
                ForeColor = Color.White
            };

            btnMusica.Click += (sender, e) =>
            {
                ToggleMusicaAmbiental();
                btnMusica.Text = _musicaActiva ? "🔊" : "🔇";
            };
            Controls.Add(btnMusica);
        }

        /// <summary>
        /// Activa o desactiva la música ambiental
        /// </summary>
        private void ToggleMusicaAmbiental()
        {
            if (_audioManager != null)
            {
                _audioManager.Toggle();
                _musicaActiva = _audioManager.IsPlaying;
            }
        }

        /// <summary>
        /// Evento ejecutado al cerrar el formulario
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _audioManager?.Dispose();
            _restoreColorsTimer?.Dispose();
            base.OnFormClosing(e);
        }

        #endregion

        #region Eventos de TextBox

        /// <summary>
        /// Evento disparado cuando un TextBox obtiene el foco
        /// </summary>
        private void TextBox_Enter(object? sender, EventArgs e)
        {
            if (sender is not TextBox focusedTxt)
                return;

            if (_sudokuBoard.FocusedTextBox != null && !_sudokuBoard.FocusedTextBox.ReadOnly)
            {
                _sudokuBoard.FocusedTextBox.BackColor = Color.White;
            }

            _sudokuBoard.FocusedTextBox = focusedTxt;

            if (!_sudokuBoard.FocusedTextBox.ReadOnly)
            {
                _sudokuBoard.FocusedTextBox.BackColor = ColorCeldaSeleccionada;
            }
        }

        /// <summary>
        /// Evento disparado cuando cambia el texto de un TextBox
        /// </summary>
        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_sudokuBoard.ShowingSolution)
                return;

            if (sender is TextBox changedTxt && changedTxt.Tag is Point pos)
            {
                int fila = pos.X;
                int columna = pos.Y;

                if (!_posicionesFijas[fila, columna] && !string.IsNullOrEmpty(changedTxt.Text))
                {
                    changedTxt.ForeColor = ColorTextoNormal;
                }
            }

            // Verificar si el sudoku está completo - mover a un hilo separado para no bloquear
            if (_sudokuBoard.EstaCompleto())
            {
                BeginInvoke(new Action(VerificarJuego));
            }
        }

        /// <summary>
        /// Valida la entrada de texto en los TextBox del Sudoku
        /// </summary>
        private void ValidarEntrada(object? sender, KeyPressEventArgs e)
        {
            if (sender is not TextBox txt || txt.Tag is not Point pos)
                return;

            // Solo permite números del 1-9 y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) || e.KeyChar == '0')
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                return;
            }

            int fila = pos.X;
            int columna = pos.Y;
            int numeroIngresado = int.Parse(e.KeyChar.ToString());

            if (!_sudokuBoard.EsNumeroValido(fila, columna, numeroIngresado))
            {
                e.Handled = true;
                _gameStats.IncrementarErrores();

                // Mostrar mensaje de error
                MessageBox.Show($"El número {numeroIngresado} no es válido en esta posición.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Resaltar error
                txt.BackColor = ColorCeldaError;
                _sudokuBoard.ResaltarConflictos(fila, columna, numeroIngresado);

                // Restaurar colores después de un tiempo
                _restoreColorsTimer.Stop();
                _restoreColorsTimer.Start();
            }
        }

        /// <summary>
        /// Maneja las teclas de navegación entre celdas
        /// </summary>
        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not TextBox txt || txt.Tag is not Point pos)
                return;

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

        #endregion

        #region Eventos del juego

        /// <summary>
        /// Evento Tick del temporizador principal
        /// </summary>
        private void timer1_Tick(object? sender, EventArgs e)
        {
            _gameTimer.ActualizarDisplay();

            // Verificar tiempo límite
            if (_gameTimer.ElapsedTime >= TimeSpan.FromMinutes(TiempoLimiteMinutos))
            {
                PerderTiempo();
            }
        }

        /// <summary>
        /// Verifica si el juego se ha completado correctamente
        /// </summary>
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

        /// <summary>
        /// Muestra la solución del Sudoku
        /// </summary>
        private void SolucionSudoku()
        {
            _sudokuBoard.MostrarSolucion();
            _gameStats.RegistrarDerrota();
            MessageBox.Show("Se ha mostrado la solución. Esta partida se contará como perdida.",
                "Solución Mostrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Maneja la pérdida por tiempo agotado
        /// </summary>
        private void PerderTiempo()
        {
            _gameTimer.Stop();
            _gameStats.RegistrarDerrota();
            MessageBox.Show($"Se ha agotado el tiempo límite de {TiempoLimiteMinutos} minutos. Esta partida se contará como perdida.",
                "Tiempo Agotado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Reinicia el juego a su estado inicial
        /// </summary>
        private void Reiniciar()
        {
            _gameTimer.Reset();
            _gameStats.Reiniciar();
            btnPausar.Enabled = true;
            btnReanudar.Enabled = false;
            btnPausar.BackColor = ColorBoton;
            btnReanudar.BackColor = ColorBoton;
            _sudokuBoard.Reiniciar();
        }

        /// <summary>
        /// Maneja la pausa y reanudación del juego
        /// </summary>
        private void PausarReanudar()
        {
            if (_gameTimer.IsPaused)
            {
                _gameTimer.Resume();
                btnPausar.BackColor = ColorBoton;
                btnReanudar.BackColor = ColorBoton;
                btnPausar.Enabled = true;
                btnReanudar.Enabled = false;
            }
            else
            {
                _gameTimer.Pause();
                btnPausar.BackColor = Color.FromArgb(173, 216, 230); // Light blue
                btnReanudar.BackColor = ColorBotonHover;
                btnPausar.Enabled = false;
                btnReanudar.Enabled = true;
            }
        }

        #endregion

        #region Eventos de botones

        private void btnPausar_Click(object? sender, EventArgs e) => PausarReanudar();

        private void btnReanudar_Click(object? sender, EventArgs e)
        {
            if (_gameTimer.IsPaused)
            {
                PausarReanudar();
            }
        }

        private void btnReinicar_Click(object? sender, EventArgs e) => Reiniciar();

        private void btnSolucion_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que quieres ver la solución? Se contará como una partida perdida.",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SolucionSudoku();
            }
        }

        #endregion

        #region Gráficos e interfaz

        /// <summary>
        /// Evento Paint del formulario para dibujar la cuadrícula
        /// </summary>
        private void NivelDificil_Paint(object? sender, PaintEventArgs e)
        {
            _sudokuBoard?.DibujarCuadricula(e.Graphics, CellSize, GridOffset);
        }

        /// <summary>
        /// Estiliza un botón con apariencia estandarizada
        /// </summary>
        private void EstilizarBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = ColorBoton;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Arial", 10, FontStyle.Bold);
            btn.FlatAppearance.MouseOverBackColor = ColorBotonHover;
            btn.FlatAppearance.MouseDownBackColor = ColorBotonPress;
        }

        /// <summary>
        /// Aplica estilo a todos los botones del formulario
        /// </summary>
        private void EstilizarBotones()
        {
            // Mantener las imágenes de fondo originales
            Image? pausarBg = btnPausar.BackgroundImage;
            Image? reanudarBg = btnReanudar.BackgroundImage;
            Image? reiniciarBg = btnReinicar.BackgroundImage;
            Image? solucionBg = btnSolucion.BackgroundImage;

            // Aplicar estilos
            EstilizarBoton(btnPausar);
            EstilizarBoton(btnReanudar);
            EstilizarBoton(btnReinicar);
            EstilizarBoton(btnSolucion);

            // Restaurar imágenes de fondo
            btnPausar.BackgroundImage = pausarBg;
            btnReanudar.BackgroundImage = reanudarBg;
            btnReinicar.BackgroundImage = reiniciarBg;
            btnSolucion.BackgroundImage = solucionBg;

            // Mantener layout de imágenes
            btnPausar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReanudar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReinicar.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolucion.BackgroundImageLayout = ImageLayout.Stretch;
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
 along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
