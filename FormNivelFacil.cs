using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto
{
    public partial class FormNivelFacil : Form
    {
        private SoundPlayer? _musicaAmbiental;
        private bool _musicaActiva = true;

        private const int SudokuSize = 9;
        private const int BoxSize = 3;
        private const int CellSize = 40;
        private const int GridOffset = 10;
        private const string TextBoxNamePrefix = "txt";

        private int _errores = 0;
        private int _partidasGanadas = 0;
        private int _partidasPerdidas = 0;
        private Stopwatch _cronometro = new Stopwatch();
        private bool _isPaused = false;
        private TextBox[,] _textBoxes = new TextBox[SudokuSize, SudokuSize];
        private bool _showingSolution = false;
        private TextBox? _focusedTextBox = null;

        private readonly int[,] _sudokuFacil = {
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
            { true, true, true, false, false, false, true, true, true },
            { true, true, true, false, true, false, true, true, true },
            { true, true, true, false, false, false, true, true, true },
            { false, false, false, true, true, true, false, false, false },
            { false, true, false, true, true, true, false, true, false },
            { false, false, false, true, true, true, false, false, false },
            { true, true, true, false, false, false, true, true, true },
            { true, true, true, false, true, false, true, true, true },
            { true, true, true, false, false, false, true, true, true }
        };

        public FormNivelFacil()
        {
            InitializeComponent();
        }

        private void FormNivelFacil_Load(object sender, EventArgs e)
        {
            EstilizarBotones();
            CrearCuadricula();
            LlenarSudoku();
            ConfigurarCronometro();
            InicializarMusicaAmbiental();
        }

        private void InicializarMusicaAmbiental()
        {
            try
            {
                // Primero, detener y liberar cualquier reproductor de música existente
                _musicaAmbiental?.Stop();
                _musicaAmbiental?.Dispose();
                _musicaAmbiental = null;

                var assembly = Assembly.GetExecutingAssembly();
                Debug.WriteLine("Recursos disponibles:");
                foreach (var resourceName in assembly.GetManifestResourceNames())
                {
                    Debug.WriteLine($" - {resourceName}");
                }

                // Intentar cargar desde un recurso incrustado
                using (Stream? stream = assembly.GetManifestResourceStream("Proyecto.Resources.ambient-easy.wav"))
                {
                    if (stream != null)
                    {
                        Debug.WriteLine("Cargando música desde recurso incrustado");
                        _musicaAmbiental = new SoundPlayer(stream);
                        _musicaAmbiental.PlayLooping();
                        AgregarControlMusica();
                        return;
                    }
                }

                string? rutaMusica = null;
                Debug.WriteLine($"Ruta base: {Application.StartupPath}");

                string[] posiblesRutas = new string[]
                {
                    Path.Combine(Application.StartupPath, "Resources", "ambient-easy.wav"),
                    Path.Combine(Application.StartupPath, "ambient-easy.wav"),
                    Path.Combine(Application.StartupPath, "..", "..", "Resources", "ambient-easy.wav"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ambient-easy.wav")
                };

                foreach (var ruta in posiblesRutas)
                {
                    Debug.WriteLine($"Intentando: {ruta} - Existe: {File.Exists(ruta)}");
                    if (File.Exists(ruta))
                    {
                        rutaMusica = ruta;
                        Debug.WriteLine($"Encontrado archivo en: {ruta}");
                        break;
                    }
                }

                if (rutaMusica == null)
                {
                    string customPath = Path.Combine(Application.StartupPath, "ambient-easy.wav");
                    if (!File.Exists(customPath))
                    {
                        using (Stream? stream = assembly.GetManifestResourceStream("Proyecto.Resources.ambient-easy.wav"))
                        {
                            if (stream != null)
                            {
                                using (FileStream fileStream = File.Create(customPath))
                                {
                                    stream.CopyTo(fileStream);
                                }
                                rutaMusica = customPath;
                                Debug.WriteLine($"Archivo extraído a: {customPath}");
                            }
                        }
                    }
                    else
                    {
                        rutaMusica = customPath;
                        Debug.WriteLine($"Usando archivo existente en: {customPath}");
                    }
                }

                if (rutaMusica == null)
                {
                    Debug.WriteLine("No se pudo encontrar el archivo de audio");
                    MessageBox.Show("No se pudo encontrar el archivo de audio 'ambient-easy.wav'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Debug.WriteLine($"Reproduciendo música desde: {rutaMusica}");
                _musicaAmbiental = new SoundPlayer(rutaMusica);
                _musicaAmbiental.PlayLooping();
                Debug.WriteLine("Música iniciada correctamente");
                AgregarControlMusica();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar la música ambiental: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Error al cargar la música ambiental: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarControlMusica()
        {
            Button btnMusica = new Button
            {
                Text = "🔊",
                Size = new Size(30, 30),
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
            if (_musicaActiva)
            {
                _musicaAmbiental?.Stop();
                _musicaActiva = false;
            }
            else
            {
                _musicaAmbiental?.PlayLooping();
                _musicaActiva = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _musicaAmbiental?.Stop();
            _musicaAmbiental?.Dispose();
            base.OnFormClosing(e);
        }

        private void LlenarSudoku()
        {
            for (int fila = 0; fila < SudokuSize; fila++)
            {
                for (int columna = 0; columna < SudokuSize; columna++)
                {
                    TextBox txt = _textBoxes[fila, columna];
                    txt.TextChanged -= TextBox_TextChanged;
                    txt.KeyPress -= ValidarEntrada;
                    txt.Enter -= TextBox_Enter;

                    if (_posicionesFijas[fila, columna])
                    {
                        txt.Text = _sudokuFacil[fila, columna].ToString();
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
                        txt.KeyPress += ValidarEntrada;
                    }
                    txt.TextChanged += TextBox_TextChanged;
                    txt.Enter += TextBox_Enter;
                }
            }
        }

        private void TextBox_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox focusedTxt)
            {
                if (_focusedTextBox != null && !_focusedTextBox.ReadOnly)
                {
                    _focusedTextBox.BackColor = Color.White;
                }
                _focusedTextBox = focusedTxt;
                if (!_focusedTextBox.ReadOnly)
                {
                    _focusedTextBox.BackColor = Color.LightYellow;
                }
            }
        }

        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            if (_showingSolution)
            {
                return;
            }

            if (sender is TextBox changedTxt && changedTxt.Tag is Point pos)
            {
                int fila = pos.X;
                int columna = pos.Y;
                if (!_posicionesFijas[fila, columna] && !string.IsNullOrEmpty(changedTxt.Text))
                {
                    changedTxt.ForeColor = Color.DarkBlue;
                }
            }

            bool isComplete = true;
            for (int fila = 0; fila < SudokuSize; fila++)
            {
                for (int columna = 0; columna < SudokuSize; columna++)
                {
                    if (string.IsNullOrEmpty(_textBoxes[fila, columna].Text))
                    {
                        isComplete = false;
                        break;
                    }
                }
                if (!isComplete) break;
            }

            if (isComplete)
            {
                VerificarJuego();
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

                    if (!EsNumeroValido(fila, columna, numeroIngresado))
                    {
                        e.Handled = true;
                        _errores++;
                        lblErrores.Text = $"Total de errores: {_errores}";
                        MessageBox.Show($"El número {numeroIngresado} no es válido en esta posición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txt.BackColor = Color.LightCoral;
                        ResaltarConflictos(fila, columna, numeroIngresado);

                        System.Threading.Timer? timer = null;
                        timer = new System.Threading.Timer((obj) =>
                        {
                            txt.Invoke(new Action(() =>
                            {
                                if (!txt.ReadOnly)
                                {
                                    txt.BackColor = Color.White;
                                }
                                RestaurarColoresConflicto();
                            }));
                            timer?.Dispose();
                        }, null, 200, System.Threading.Timeout.Infinite);
                    }
                }
            }
        }

        private bool NumeroRepetido(int fila, int columna, int numero)
        {
            for (int i = 0; i < SudokuSize; i++)
            {
                if (i != columna && _textBoxes[fila, i].Text == numero.ToString())
                {
                    return true;
                }
            }

            for (int i = 0; i < SudokuSize; i++)
            {
                if (i != fila && _textBoxes[i, columna].Text == numero.ToString())
                {
                    return true;
                }
            }

            return false;
        }

        private bool EsNumeroValido(int fila, int columna, int numero)
        {
            if (NumeroRepetido(fila, columna, numero))
            {
                return false;
            }

            int boxStartRow = (fila / BoxSize) * BoxSize;
            int boxStartCol = (columna / BoxSize) * BoxSize;

            for (int i = 0; i < BoxSize; i++)
            {
                for (int j = 0; j < BoxSize; j++)
                {
                    int currentRow = boxStartRow + i;
                    int currentCol = boxStartCol + j;

                    if (currentRow == fila && currentCol == columna)
                    {
                        continue;
                    }

                    if (_textBoxes[currentRow, currentCol].Text == numero.ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void CrearCuadricula()
        {
            int cellPadding = 2;
            for (int fila = 0; fila < SudokuSize; fila++)
            {
                for (int columna = 0; columna < SudokuSize; columna++)
                {
                    TextBox txt = new TextBox
                    {
                        Name = $"{TextBoxNamePrefix}{fila}{columna}",
                        Tag = new Point(fila, columna),
                        Size = new Size(CellSize - cellPadding * 2, CellSize - cellPadding * 2),
                        Location = new Point(columna * CellSize + GridOffset + cellPadding, fila * CellSize + GridOffset + cellPadding),
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        MaxLength = 1
                    };
                    _textBoxes[fila, columna] = txt;
                    txt.KeyDown += TextBox_KeyDown;
                    this.Controls.Add(txt);
                }
            }
        }

        private void ConfigurarCronometro()
        {
            _cronometro.Start();
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void VerificarJuego()
        {
            bool isCorrect = true;

            for (int fila = 0; fila < SudokuSize; fila++)
            {
                for (int columna = 0; columna < SudokuSize; columna++)
                {
                    if (string.IsNullOrEmpty(_textBoxes[fila, columna].Text) || int.Parse(_textBoxes[fila, columna].Text) != _sudokuFacil[fila, columna])
                    {
                        isCorrect = false;
                        break;
                    }
                }
                if (!isCorrect) break;
            }

            _cronometro.Stop();
            timer1.Stop();

            if (isCorrect)
            {
                _partidasGanadas++;
                LblpartidasG.Text = $"Partidas Ganadas: {_partidasGanadas}";
                MessageBox.Show($"¡Felicidades! Has completado el Sudoku en {_cronometro.Elapsed:hh\\:mm\\:ss} con {_errores} errores.", "Victoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _partidasPerdidas++;
                LblpartidasP.Text = $"Partidas Perdidas: {_partidasPerdidas}";
                MessageBox.Show("El Sudoku no está resuelto correctamente. Intenta de nuevo.", "Intento Fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cronometro.Start();
                timer1.Start();
            }
        }

        private void PausarReanudar()
        {
            if (_isPaused)
            {
                _cronometro.Start();
                timer1.Start();
                _isPaused = false;
                btnPausar.Text = "Pausar";
                btnReanudar.Enabled = false;
            }
            else
            {
                _cronometro.Stop();
                timer1.Stop();
                _isPaused = true;
                btnPausar.Text = "Pausado";
                btnReanudar.Enabled = true;
            }
        }

        private void btnPausar_Click_1(object sender, EventArgs e)
        {
            PausarReanudar();
        }

        private void btnReanudar_Click_1(object sender, EventArgs e)
        {
            if (_isPaused)
            {
                PausarReanudar();
            }
        }

        private void Reiniciar()
        {
            _cronometro.Reset();
            _cronometro.Start();
            timer1.Start();
            _errores = 0;
            lblErrores.Text = "Total de errores: 0";
            _isPaused = false;
            btnPausar.Text = "Pausar";
            btnReanudar.Enabled = false;
            LlenarSudoku();
            for (int fila = 0; fila < SudokuSize; fila++)
            {
                for (int columna = 0; columna < SudokuSize; columna++)
                {
                    _textBoxes[fila, columna].ForeColor = _posicionesFijas[fila, columna] ? Color.Black : Color.DarkBlue;
                    _textBoxes[fila, columna].Font = new Font("Arial", 14, FontStyle.Bold);
                }
            }
        }

        private void btnReinicar_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void SolucionSudoku()
        {
            _showingSolution = true;
            for (int fila = 0; fila < SudokuSize; fila++)
            {
                for (int columna = 0; columna < SudokuSize; columna++)
                {
                    _textBoxes[fila, columna].Text = _sudokuFacil[fila, columna].ToString();
                    _textBoxes[fila, columna].ForeColor = Color.Green;
                    _textBoxes[fila, columna].Font = new Font("Arial", 14, FontStyle.Italic);
                }
            }
            _showingSolution = false;

            _partidasPerdidas++;
            LblpartidasP.Text = $"Partidas Perdidas: {_partidasPerdidas}";
            MessageBox.Show("Se ha mostrado la solución. Esta partida se contará como perdida.", "Solución Mostrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSolucion_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres ver la solución? Se contará como una partida perdida.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SolucionSudoku();
            }
        }

        private void Tiempo()
        {
            TimeSpan tiempoTranscurrido = _cronometro.Elapsed;
            lblTiempo.Text = $"Tiempo: {tiempoTranscurrido:hh\\:mm\\:ss}";
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            Tiempo();
            if (_cronometro.Elapsed >= TimeSpan.FromMinutes(5))
            {
                PerderTiempo();
            }
        }

        private void FormNivelFacil_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Pen penThick = new Pen(Color.FromArgb(50, 50, 50), 3))
            using (Pen penThin = new Pen(Color.FromArgb(150, 150, 150), 1))
            {
                int tamañoSudoku = CellSize * SudokuSize;

                for (int i = 0; i <= SudokuSize; i += BoxSize)
                {
                    g.DrawLine(penThick, i * CellSize + GridOffset, GridOffset, i * CellSize + GridOffset, tamañoSudoku + GridOffset); // Vertical lines
                    g.DrawLine(penThick, GridOffset, i * CellSize + GridOffset, tamañoSudoku + GridOffset, i * CellSize + GridOffset); // Horizontal lines
                }

                for (int i = 1; i < SudokuSize; i++)
                {
                    if (i % BoxSize != 0)
                    {
                        g.DrawLine(penThin, i * CellSize + GridOffset, GridOffset, i * CellSize + GridOffset, tamañoSudoku + GridOffset); // Vertical lines
                        g.DrawLine(penThin, GridOffset, i * CellSize + GridOffset, tamañoSudoku + GridOffset, i * CellSize + GridOffset); // Horizontal lines
                    }
                }
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            VerificarJuego();
        }

        private void PerderTiempo()
        {
            _cronometro.Stop();
            timer1.Stop();
            _partidasPerdidas++;
            LblpartidasP.Text = $"Partidas Perdidas: {_partidasPerdidas}";
            MessageBox.Show("Se ha agotado el tiempo. Esta partida se contará como perdida.", "Tiempo Agotado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // No llamar a Reiniciar aquí
        }

        private void ResaltarConflictos(int fila, int columna, int numero)
        {
            for (int i = 0; i < SudokuSize; i++)
            {
                if (_textBoxes[fila, i].Text == numero.ToString())
                {
                    _textBoxes[fila, i].BackColor = Color.LightCoral;
                }
                if (_textBoxes[i, columna].Text == numero.ToString())
                {
                    _textBoxes[i, columna].BackColor = Color.LightCoral;
                }
            }

            int boxStartRow = (fila / BoxSize) * BoxSize;
            int boxStartCol = (columna / BoxSize) * BoxSize;
            for (int i = 0; i < BoxSize; i++)
            {
                for (int j = 0; j < BoxSize; j++)
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

        private void RestaurarColoresConflicto()
        {
            for (int fila = 0; fila < SudokuSize; fila++)
            {
                for (int columna = 0; columna < SudokuSize; columna++)
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

        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is TextBox txt && txt.Tag is Point pos)
            {
                int fila = pos.X;
                int columna = pos.Y;
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (columna > 0)
                            _textBoxes[fila, columna - 1].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Right:
                        if (columna < SudokuSize - 1)
                            _textBoxes[fila, columna + 1].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Up:
                        if (fila > 0)
                            _textBoxes[fila - 1, columna].Focus();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Down:
                        if (fila < SudokuSize - 1)
                            _textBoxes[fila + 1, columna].Focus();
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }

        private void EstilizarBotones()
        {
            Color btnBackColor = Color.MediumSeaGreen;
            Color btnMouseOver = Color.SeaGreen;
            Color btnMouseDown = Color.DarkGreen;

            btnPausar.FlatStyle = FlatStyle.Flat;
            btnPausar.FlatAppearance.BorderSize = 0;
            btnPausar.BackColor = btnBackColor;
            btnPausar.ForeColor = Color.White;
            btnPausar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnPausar.FlatAppearance.MouseOverBackColor = btnMouseOver;
            btnPausar.FlatAppearance.MouseDownBackColor = btnMouseDown;

            btnReanudar.FlatStyle = FlatStyle.Flat;
            btnReanudar.FlatAppearance.BorderSize = 0;
            btnReanudar.BackColor = btnBackColor;
            btnReanudar.ForeColor = Color.White;
            btnReanudar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnReanudar.FlatAppearance.MouseOverBackColor = btnMouseOver;
            btnReanudar.FlatAppearance.MouseDownBackColor = btnMouseDown;

            btnReinicar.FlatStyle = FlatStyle.Flat;
            btnReinicar.FlatAppearance.BorderSize = 0;
            btnReinicar.BackColor = btnBackColor;
            btnReinicar.ForeColor = Color.White;
            btnReinicar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnReinicar.FlatAppearance.MouseOverBackColor = btnMouseOver;
            btnReinicar.FlatAppearance.MouseDownBackColor = btnMouseDown;

            btnSolucion.FlatStyle = FlatStyle.Flat;
            btnSolucion.FlatAppearance.BorderSize = 0;
            btnSolucion.BackColor = btnBackColor;
            btnSolucion.ForeColor = Color.White;
            btnSolucion.Font = new Font("Arial", 10, FontStyle.Bold);
            btnSolucion.FlatAppearance.MouseOverBackColor = btnMouseOver;
            btnSolucion.FlatAppearance.MouseDownBackColor = btnMouseDown;
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