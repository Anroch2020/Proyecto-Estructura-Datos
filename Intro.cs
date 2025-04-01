using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Utilities;

namespace Proyecto
{
    public partial class Intro : Form
    {
        // Sistema de audio
        private AudioManager? _audioManager;
        private bool _musicaActiva = true;

        // Constantes para la animación de botones
        private const int ZoomStep = 2;
        private const int MaxZoom = 10;
        private const int ButtonWidth = 300;
        private const int ButtonHeight = 60;

        // Componentes de interfaz
        private Button? _btnMusica;
        private Button? _currentButton;
        private System.Windows.Forms.Timer _animationTimer;
        private bool _zoomIn;

        public Intro()
        {
            InitializeComponent();
            ConfigurarFormulario();
            InicializarComponentes();
            InicializarMusicaAmbiental();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Sudoku - Selecciona la dificultad";
            this.Size = new Size(400, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void InicializarComponentes()
        {
            CrearPaneles();
            ConfigurarAnimacion();
        }

        private void CrearPaneles()
        {
            // Panel principal con título y botones
            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                ColumnCount = 1,
                RowCount = 2
            };
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            this.Controls.Add(mainPanel);

            // Título del juego
            Label lblTitle = new Label
            {
                Text = "NumberMaster",
                Font = new Font("Arial", 36, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            mainPanel.Controls.Add(lblTitle, 0, 0);

            // Panel para los botones
            TableLayoutPanel buttonPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5
            };

            // Configurar filas para que sean iguales
            for (int i = 0; i < 5; i++)
            {
                buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            }

            mainPanel.Controls.Add(buttonPanel, 0, 1);

            // Crear botones de menú
            var buttonConfig = new (string Text, Color Color, EventHandler ClickHandler)[]
            {
                ("Facil", Color.LightGreen, new EventHandler(btnEasy_Click)),
                ("Medio", Color.Goldenrod, new EventHandler(btnMedium_Click)),
                ("Dificil", Color.IndianRed, new EventHandler(btnHard_Click)),
                ("Reglas", Color.SkyBlue, new EventHandler(btnRules_Click)),
                ("Creadores", Color.MediumPurple, new EventHandler(btnCreators_Click))
            };

            // Agregar botones al panel
            for (int i = 0; i < buttonConfig.Length; i++)
            {
                var (text, color, handler) = buttonConfig[i];
                Button btn = CrearBoton(text, color, handler);
                buttonPanel.Controls.Add(btn, 0, i);
            }
        }

        private Button CrearBoton(string texto, Color color, EventHandler clickHandler)
        {
            Button button = new Button
            {
                Text = texto,
                Font = new Font("Verdana", 20, FontStyle.Regular),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(ButtonWidth, ButtonHeight),
                Anchor = AnchorStyles.None
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += clickHandler;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            return button;
        }

        private void ConfigurarAnimacion()
        {
            _animationTimer = new System.Windows.Forms.Timer
            {
                Interval = 15
            };
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            _currentButton = sender as Button;
            _zoomIn = true;
            _animationTimer.Start();
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            _currentButton = sender as Button;
            _zoomIn = false;
            _animationTimer.Start();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (_currentButton == null) return;

            if (_zoomIn)
            {
                if (_currentButton.Width < ButtonWidth + MaxZoom && _currentButton.Height < ButtonHeight + MaxZoom)
                {
                    _currentButton.Width += ZoomStep;
                    _currentButton.Height += ZoomStep;
                }
                else
                {
                    _animationTimer.Stop();
                }
            }
            else
            {
                if (_currentButton.Width > ButtonWidth && _currentButton.Height > ButtonHeight)
                {
                    _currentButton.Width -= ZoomStep;
                    _currentButton.Height -= ZoomStep;
                }
                else
                {
                    _animationTimer.Stop();
                }
            }
        }

        #region Gestión de Audio
        private void InicializarMusicaAmbiental()
        {
            try
            {
                _audioManager?.Dispose();
                _audioManager = new AudioManager("ambient-menu.wav");
                _audioManager.PlayLooping();
                _musicaActiva = true;
                AgregarControlMusica();
                Debug.WriteLine("Menú: Música ambiental inicializada correctamente");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Menú: Error al cargar la música ambiental: {ex.Message}");
            }
        }

        private void AgregarControlMusica()
        {
            if (_btnMusica != null && this.Controls.Contains(_btnMusica))
            {
                _btnMusica.Text = _musicaActiva ? "🔊" : "🔇";
                return;
            }

            _btnMusica = new Button
            {
                Text = "🔊",
                Size = new Size(30, 30),
                Location = new Point(this.ClientSize.Width - 40, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(180, Color.LightBlue)
            };
            _btnMusica.FlatAppearance.BorderSize = 0;
            _btnMusica.Click += (sender, e) => ToggleMusicaAmbiental();
            this.Controls.Add(_btnMusica);
        }

        private void ToggleMusicaAmbiental()
        {
            if (_audioManager != null)
            {
                _audioManager.Toggle();
                _musicaActiva = _audioManager.IsPlaying;
                if (_btnMusica != null)
                {
                    _btnMusica.Text = _musicaActiva ? "🔊" : "🔇";
                }
            }
        }
        #endregion

        #region Navegación entre Formularios
        private void AbrirFormulario<T>(string mensaje) where T : Form, new()
        {
            Debug.WriteLine($"Menú: Abriendo {typeof(T).Name}");
            MessageBox.Show(mensaje);

            // Detener y liberar música
            _audioManager?.Stop();
            _audioManager?.Dispose();
            _audioManager = null;

            // Crear y mostrar nuevo formulario
            T formulario = new T();
            formulario.FormClosed += (s, args) => RegresarAlMenu();
            formulario.Show();
            this.Hide();
        }

        private void RegresarAlMenu()
        {
            Debug.WriteLine("Menú: Regresando al menú principal");
            this.Show();

            // Reanudar música después de un breve retraso
            Task.Delay(100).ContinueWith(t =>
            {
                if (this.IsDisposed) return;
                this.BeginInvoke(new Action(() =>
                {
                    if (this.Visible && _musicaActiva)
                    {
                        ReanudarMusica();
                    }
                }));
            });
        }

        private void ReanudarMusica()
        {
            if (_audioManager == null)
            {
                InicializarMusicaAmbiental();
                return;
            }

            if (_musicaActiva)
            {
                try
                {
                    _audioManager.PlayLooping();
                }
                catch
                {
                    InicializarMusicaAmbiental();
                }
            }
        }
        #endregion

        #region Eventos de Botones
        private void btnEasy_Click(object? sender, EventArgs e)
        {
            AbrirFormulario<FormNivelFacil>("Nivel Facil Seleccionado!");
        }

        private void btnMedium_Click(object? sender, EventArgs e)
        {
            AbrirFormulario<NivelMedio>("Nivel Medio seleccionado!");
        }

        private void btnHard_Click(object? sender, EventArgs e)
        {
            AbrirFormulario<NivelDificil>("Nivel dificil seleccionado!");
        }

        private void btnRules_Click(object? sender, EventArgs e)
        {
            new ReglasDelJuego().Show();
        }

        private void btnCreators_Click(object? sender, EventArgs e)
        {
            new Integrantes().Show();
        }
        #endregion

        #region Eventos del Formulario
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _audioManager?.Dispose();
            base.OnFormClosing(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                Task.Delay(300).ContinueWith(t =>
                {
                    if (this.IsDisposed) return;
                    this.BeginInvoke(new Action(() =>
                    {
                        if (this.Visible && _musicaActiva) ReanudarMusica();
                    }));
                });
            }
            else
            {
                _audioManager?.Stop();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (_audioManager == null) InicializarMusicaAmbiental();
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
