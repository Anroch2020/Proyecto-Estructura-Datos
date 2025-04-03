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
        #region Constantes y campos estáticos

        // Constantes para la animación de botones
        private const int ZoomStep = 2;
        private const int MaxZoom = 10;
        private const int ButtonWidth = 300;
        private const int ButtonHeight = 60;

        // Colores para los botones
        private static readonly Color ColorMenuFacil = Color.LightGreen;
        private static readonly Color ColorMenuMedio = Color.Goldenrod;
        private static readonly Color ColorMenuDificil = Color.IndianRed;
        private static readonly Color ColorMenuReglas = Color.SkyBlue;
        private static readonly Color ColorMenuCreadores = Color.MediumPurple;
        private static readonly Color ColorBotonMusica = Color.FromArgb(180, 211, 211, 255); // Celeste transparente

        #endregion

        #region Campos privados

        // Sistema de audio
        private AudioManager? _audioManager;
        private bool _musicaActiva = true;

        // Componentes de interfaz
        private Button? _btnMusica;
        private Button? _currentButton;
        private System.Windows.Forms.Timer? _animationTimer;
        private bool _zoomIn;

        #endregion

        #region Inicialización

        /// <summary>
        /// Constructor del formulario principal
        /// </summary>
        public Intro()
        {
            InitializeComponent();

            // Cancelar la disposición automática si el diseñador creó un timer
            if (components != null && components.Components.Count > 0)
            {
                foreach (var component in components.Components)
                {
                    if (component is System.Windows.Forms.Timer timer)
                    {
                        timer.Dispose();
                    }
                }
            }

            ConfigurarFormulario();
            InicializarComponentes();
            InicializarMusicaAmbiental();
        }

        /// <summary>
        /// Configura las propiedades básicas del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.Text = "Sudoku - Selecciona la dificultad";
            this.Size = new Size(400, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (s, e) => Application.Exit();
        }

        /// <summary>
        /// Inicializa todos los componentes de interfaz
        /// </summary>
        private void InicializarComponentes()
        {
            CrearPaneles();
            ConfigurarAnimacion();
        }

        /// <summary>
        /// Configura el timer de animación
        /// </summary>
        private void ConfigurarAnimacion()
        {
            // Crear un nuevo timer para evitar problemas con el Designer
            _animationTimer = new System.Windows.Forms.Timer
            {
                Interval = 15
            };
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        #endregion

        #region Creación de interfaz

        /// <summary>
        /// Crea los paneles y botones de la interfaz principal
        /// </summary>
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

            // Configuración de botones (texto, color, manejador de evento)
            var buttonConfig = new[]
            {
                (Text: "Facil", Color: ColorMenuFacil, Handler: new EventHandler(btnEasy_Click)),
                (Text: "Medio", Color: ColorMenuMedio, Handler: new EventHandler(btnMedium_Click)),
                (Text: "Dificil", Color: ColorMenuDificil, Handler: new EventHandler(btnHard_Click)),
                (Text: "Reglas", Color: ColorMenuReglas, Handler: new EventHandler(btnRules_Click)),
                (Text: "Creadores", Color: ColorMenuCreadores, Handler: new EventHandler(btnCreators_Click))
            };

            // Crear y agregar botones al panel
            for (int i = 0; i < buttonConfig.Length; i++)
            {
                var (text, color, handler) = buttonConfig[i];
                Button btn = CrearBoton(text, color, handler);
                buttonPanel.Controls.Add(btn, 0, i);
            }
        }

        /// <summary>
        /// Crea un botón con estilos y eventos estándar
        /// </summary>
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

        #endregion

        #region Animación de botones

        /// <summary>
        /// Maneja el evento de entrada del ratón en un botón
        /// </summary>
        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is not Button btn)
                return;

            _currentButton = btn;
            _zoomIn = true;
            _animationTimer?.Start();
        }

        /// <summary>
        /// Maneja el evento de salida del ratón de un botón
        /// </summary>
        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is not Button btn)
                return;

            _currentButton = btn;
            _zoomIn = false;
            _animationTimer?.Start();
        }

        /// <summary>
        /// Gestiona la animación de zoom de los botones
        /// </summary>
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
                    _animationTimer?.Stop();
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
                    _animationTimer?.Stop();
                }
            }
        }

        #endregion

        #region Gestión de Audio

        /// <summary>
        /// Inicializa la música ambiental del menú
        /// </summary>
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

        /// <summary>
        /// Agrega el botón de control de música a la interfaz
        /// </summary>
        private void AgregarControlMusica()
        {
            if (_btnMusica != null && this.Controls.Contains(_btnMusica))
            {
                _btnMusica.Text = _musicaActiva ? "🔊" : "🔇";
                return;
            }

            _btnMusica = new Button
            {
                Text = _musicaActiva ? "🔊" : "🔇",
                Size = new Size(40, 40),
                Location = new Point(this.ClientSize.Width - 50, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = ColorBotonMusica,
                ForeColor = Color.DarkBlue,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            _btnMusica.FlatAppearance.BorderSize = 0;
            _btnMusica.Click += (sender, e) => ToggleMusicaAmbiental();
            this.Controls.Add(_btnMusica);
            _btnMusica.BringToFront();
        }

        /// <summary>
        /// Activa o desactiva la música ambiental
        /// </summary>
        private void ToggleMusicaAmbiental()
        {
            if (_audioManager == null)
                return;

            _audioManager.Toggle();
            _musicaActiva = _audioManager.IsPlaying;

            if (_btnMusica != null)
            {
                _btnMusica.Text = _musicaActiva ? "🔊" : "🔇";
            }
        }

        /// <summary>
        /// Reanuda la reproducción de música ambiental
        /// </summary>
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
                    // Reintentar la inicialización si falla la reproducción
                    InicializarMusicaAmbiental();
                }
            }
        }

        #endregion

        #region Navegación entre Formularios

        /// <summary>
        /// Abre un formulario de nivel específico
        /// </summary>
        private void AbrirFormulario<T>(string mensaje) where T : Form, new()
        {
            Debug.WriteLine($"Menú: Abriendo {typeof(T).Name}");
            MessageBox.Show(mensaje, "Nivel Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Detener y liberar música para evitar superposición
            _audioManager?.Stop();
            _audioManager?.Dispose();
            _audioManager = null;

            // Crear y mostrar nuevo formulario
            T formulario = new T();
            formulario.FormClosed += (s, args) => RegresarAlMenu();
            formulario.Show();
            this.Hide();
        }

        /// <summary>
        /// Regresa al menú principal desde otro formulario
        /// </summary>
        private void RegresarAlMenu()
        {
            if (this.IsDisposed)
                return;

            Debug.WriteLine("Menú: Regresando al menú principal");
            this.Show();

            // Reanudar música después de un breve retraso para evitar problemas
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

        #endregion

        #region Eventos de Botones

        /// <summary>
        /// Abre el nivel fácil del juego
        /// </summary>
        private void btnEasy_Click(object? sender, EventArgs e) =>
            AbrirFormulario<FormNivelFacil>("¡Nivel Fácil Seleccionado!");

        /// <summary>
        /// Abre el nivel medio del juego
        /// </summary>
        private void btnMedium_Click(object? sender, EventArgs e) =>
            AbrirFormulario<NivelMedio>("¡Nivel Medio Seleccionado!");

        /// <summary>
        /// Abre el nivel difícil del juego
        /// </summary>
        private void btnHard_Click(object? sender, EventArgs e) =>
            AbrirFormulario<NivelDificil>("¡Nivel Difícil Seleccionado!");

        /// <summary>
        /// Muestra las reglas del juego
        /// </summary>
        private void btnRules_Click(object? sender, EventArgs e) =>
            new ReglasDelJuego().Show();

        /// <summary>
        /// Muestra información sobre los creadores
        /// </summary>
        private void btnCreators_Click(object? sender, EventArgs e) =>
            new Integrantes().Show();

        #endregion

        #region Eventos del Formulario

        /// <summary>
        /// Maneja el cierre del formulario
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _animationTimer?.Stop();
            _animationTimer?.Dispose();
            _audioManager?.Dispose();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Maneja los cambios de visibilidad del formulario
        /// </summary>
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
                        if (this.Visible && _musicaActiva)
                            ReanudarMusica();
                    }));
                });
            }
            else
            {
                _audioManager?.Stop();
            }
        }

        /// <summary>
        /// Maneja el evento de mostrar el formulario
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_audioManager == null)
                InicializarMusicaAmbiental();

            if (_btnMusica != null)
                _btnMusica.BringToFront();
        }

        /// <summary>
        /// Redimensiona el formulario y reposiciona el botón de música
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_btnMusica != null)
            {
                _btnMusica.Location = new Point(this.ClientSize.Width - 50, 10);
                _btnMusica.BringToFront();
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
 along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

