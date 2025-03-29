using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Intro : Form
    {
        // Sistema de audio
        private SoundPlayer? _musicaAmbiental;
        private Stream? _streamMusica;  // Mantener una referencia al stream
        private bool _musicaActiva = true;
        private Button? _btnMusica;

        private Button btnEasy, btnMedium, btnHard, btnRules, btnCreators;
        private System.Windows.Forms.Timer animationTimer;
        private Button? currentButton;
        private bool zoomIn;
        private const int ZoomStep = 2;
        private const int MaxZoom = 10;

        public Intro()
        {
            InitializeComponent();
            InitializeButtons();
            InitializeAnimationTimer();
            InicializarMusicaAmbiental();
            btnEasy = new Button();
            btnMedium = new Button();
            btnHard = new Button();
            btnRules = new Button();
            btnCreators = new Button();
            animationTimer = new System.Windows.Forms.Timer();
        }

        private void InicializarMusicaAmbiental()
        {
            try
            {
                LimpiarRecursosAudio();

                // Listar los recursos disponibles para depuración
                var assembly = Assembly.GetExecutingAssembly();
                Debug.WriteLine("Recursos disponibles en el menú:");
                foreach (var resourceName in assembly.GetManifestResourceNames())
                {
                    Debug.WriteLine($" - {resourceName}");
                }

                // Intentar cargar desde un recurso incrustado
                _streamMusica = assembly.GetManifestResourceStream("Proyecto.Resources.ambient-menu.wav");
                if (_streamMusica != null)
                {
                    Debug.WriteLine("Menú: Cargando música desde recurso incrustado");
                    _musicaAmbiental = new SoundPlayer(_streamMusica);
                    _musicaAmbiental.PlayLooping();
                    AgregarControlMusica();
                    return;
                }

                // Si no se encuentra como recurso incrustado, intentar con las rutas de archivo
                string? rutaMusica = null;

                // Depuración para ver dónde está buscando
                Debug.WriteLine($"Menú: Ruta base: {Application.StartupPath}");

                // Intentar varias rutas posibles
                string[] posiblesRutas = new string[]
                {
                    Path.Combine(Application.StartupPath, "Resources", "ambient-menu.wav"),
                    Path.Combine(Application.StartupPath, "ambient-menu.wav"),
                    Path.Combine(Application.StartupPath, "..", "..", "Resources", "ambient-menu.wav"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ambient-menu.wav")
                };

                // Mostrar todas las rutas para depuración
                foreach (var ruta in posiblesRutas)
                {
                    Debug.WriteLine($"Menú: Intentando: {ruta} - Existe: {File.Exists(ruta)}");
                    if (File.Exists(ruta))
                    {
                        rutaMusica = ruta;
                        break;
                    }
                }

                if (rutaMusica == null)
                {
                    Debug.WriteLine("Menú: No se pudo encontrar ningún archivo de audio");
                    return;
                }

                Debug.WriteLine($"Menú: Reproduciendo música desde archivo: {rutaMusica}");
                _musicaAmbiental = new SoundPlayer(rutaMusica);
                _musicaAmbiental.PlayLooping(); // Reproducir en bucle
                Debug.WriteLine("Menú: Reproducción iniciada correctamente");

                // Agregar un botón para controlar el volumen
                AgregarControlMusica();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Menú: Error al cargar la música ambiental: {ex.Message}");
                Debug.WriteLine($"Menú: Stack trace: {ex.StackTrace}");
            }
        }

        private void AgregarControlMusica()
        {
            if (_btnMusica != null && this.Controls.Contains(_btnMusica))
            {
                Debug.WriteLine("Menú: Botón de música ya existe, actualizando");
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
            Debug.WriteLine("Menú: Botón de música agregado");
        }

        private void ToggleMusicaAmbiental()
        {
            _musicaActiva = !_musicaActiva;
            if (_musicaActiva)
            {
                _musicaAmbiental?.PlayLooping();
                if (_btnMusica != null) _btnMusica.Text = "🔊";
            }
            else
            {
                _musicaAmbiental?.Stop();
                if (_btnMusica != null) _btnMusica.Text = "🔇";
            }
        }

        private void DetenerMusica()
        {
            _musicaAmbiental?.Stop();
        }

        private void ReanudarMusica()
        {
            Debug.WriteLine("Menú: Intentando reanudar música");

            if (_musicaAmbiental == null)
            {
                Debug.WriteLine("Menú: Reproductor nulo, reinicializando música");
                InicializarMusicaAmbiental();
                return;
            }

            if (_musicaActiva)
            {
                Debug.WriteLine("Menú: Reanudando música");
                try
                {
                    _musicaAmbiental.PlayLooping();
                    Debug.WriteLine("Menú: Música reanudada correctamente");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Menú: Error al reanudar música: {ex.Message}");
                    InicializarMusicaAmbiental();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Debug.WriteLine("Menú: Cerrando formulario, liberando recursos");
            LimpiarRecursosAudio();
            base.OnFormClosing(e);
        }

        private void InitializeButtons()
        {
            this.Text = "Sudoku - Selecciona la dificultad";
            this.Size = new Size(400, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormClosed += (s, e) => Application.Exit();

            TableLayoutPanel mainTlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                ColumnCount = 1,
                RowCount = 2
            };
            mainTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            mainTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            this.Controls.Add(mainTlp);

            Label lblTitle = new Label
            {
                Text = "NumberMaster",
                Font = new Font("Arial", 36, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            mainTlp.Controls.Add(lblTitle, 0, 0);

            TableLayoutPanel buttonsTlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5
            };
            buttonsTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTlp.Controls.Add(buttonsTlp, 0, 1);

            int buttonWidth = 300;
            int buttonHeight = 60;
            Font buttonFont = new Font("Verdana", 20, FontStyle.Regular);
            FlatStyle flatStyle = FlatStyle.Flat;

            btnEasy = CreateButton("Facil", buttonFont, Color.LightGreen, buttonWidth, buttonHeight, flatStyle, btnEasy_Click);
            buttonsTlp.Controls.Add(btnEasy, 0, 0);

            btnMedium = CreateButton("Medio", buttonFont, Color.Goldenrod, buttonWidth, buttonHeight, flatStyle, btnMedium_Click);
            buttonsTlp.Controls.Add(btnMedium, 0, 1);

            btnHard = CreateButton("Dificil", buttonFont, Color.IndianRed, buttonWidth, buttonHeight, flatStyle, btnHard_Click);
            buttonsTlp.Controls.Add(btnHard, 0, 2);

            btnRules = CreateButton("Reglas", buttonFont, Color.SkyBlue, buttonWidth, buttonHeight, flatStyle, btnRules_Click);
            buttonsTlp.Controls.Add(btnRules, 0, 3);

            btnCreators = CreateButton("Creadores", buttonFont, Color.MediumPurple, buttonWidth, buttonHeight, flatStyle, btnCreators_Click);
            buttonsTlp.Controls.Add(btnCreators, 0, 4);
        }

        private Button CreateButton(string text, Font font, Color backColor, int width, int height, FlatStyle flatStyle, EventHandler clickHandler)
        {
            Button button = new Button
            {
                Text = text,
                Font = font,
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = flatStyle,
                Size = new Size(width, height),
                Anchor = AnchorStyles.None
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += clickHandler;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            return button;
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new System.Windows.Forms.Timer
            {
                Interval = 15
            };
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            currentButton = sender as Button;
            zoomIn = true;
            animationTimer.Start();
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            currentButton = sender as Button;
            zoomIn = false;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (currentButton != null)
            {
                if (zoomIn)
                {
                    if (currentButton.Width < 300 + MaxZoom && currentButton.Height < 60 + MaxZoom)
                    {
                        currentButton.Width += ZoomStep;
                        currentButton.Height += ZoomStep;
                    }
                    else
                    {
                        animationTimer.Stop();
                    }
                }
                else
                {
                    if (currentButton.Width > 300 && currentButton.Height > 60)
                    {
                        currentButton.Width -= ZoomStep;
                        currentButton.Height -= ZoomStep;
                    }
                    else
                    {
                        animationTimer.Stop();
                    }
                }
            }
        }

        private void btnEasy_Click(object? sender, EventArgs e)
        {
            Debug.WriteLine("Menú: Click en nivel fácil");
            MessageBox.Show("Nivel Facil Seleccionado!");

            DetenerMusica();
            LimpiarRecursosAudio();

            FormNivelFacil nivelFacilForm = new FormNivelFacil();
            nivelFacilForm.FormClosed += (s, args) =>
            {
                Debug.WriteLine("Menú: Formulario fácil cerrado");
                this.Show();
                Task.Delay(100).ContinueWith(t =>
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        ReanudarMusica();
                    }));
                });
            };

            nivelFacilForm.Show();
            this.Hide();
        }

        private void btnMedium_Click(object? sender, EventArgs e)
        {
            Debug.WriteLine("Menú: Click en nivel medio");
            MessageBox.Show("Nivel Medio seleccionado!");

            DetenerMusica();
            LimpiarRecursosAudio();

            NivelMedio nivelMedioForm = new NivelMedio();
            nivelMedioForm.FormClosed += (s, args) =>
            {
                Debug.WriteLine("Menú: Formulario medio cerrado");
                this.Show();
                Task.Delay(100).ContinueWith(t =>
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        ReanudarMusica();
                    }));
                });
            };

            nivelMedioForm.Show();
            this.Hide();
        }

        private void btnHard_Click(object? sender, EventArgs e)
        {
            Debug.WriteLine("Menú: Click en nivel difícil");
            MessageBox.Show("Nivel dificil seleccionado!");

            DetenerMusica();
            LimpiarRecursosAudio();

            NivelDificil hardForm = new NivelDificil();
            hardForm.FormClosed += (s, args) =>
            {
                Debug.WriteLine("Menú: Formulario difícil cerrado");
                this.Show();
                Task.Delay(100).ContinueWith(t =>
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        ReanudarMusica();
                    }));
                });
            };

            hardForm.Show();
            this.Hide();
        }

        private void btnRules_Click(object? sender, EventArgs e)
        {
            ReglasDelJuego reglasDelJuego = new ReglasDelJuego();
            reglasDelJuego.Show();
        }

        private void btnCreators_Click(object? sender, EventArgs e)
        {
            Integrantes integrantes = new Integrantes();
            integrantes.Show();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            Debug.WriteLine($"Menú: Visibilidad cambiada. Visible: {this.Visible}, MusicaActiva: {_musicaActiva}");

            if (this.Visible)
            {
                Task.Delay(300).ContinueWith(t =>
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
            else if (!this.Visible)
            {
                DetenerMusica();
            }
        }

        private void LimpiarRecursosAudio()
        {
            if (_musicaAmbiental != null)
            {
                Debug.WriteLine("Menú: Deteniendo reproductor anterior");
                _musicaAmbiental.Stop();
                _musicaAmbiental.Dispose();
                _musicaAmbiental = null;
            }

            if (_streamMusica != null)
            {
                Debug.WriteLine("Menú: Cerrando stream anterior");
                _streamMusica.Dispose();
                _streamMusica = null;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Debug.WriteLine("Menú: Formulario mostrado");

            if (_musicaAmbiental == null || _streamMusica == null)
            {
                Debug.WriteLine("Menú: Recursos de audio nulos al mostrar, reinicializando");
                InicializarMusicaAmbiental();
            }
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