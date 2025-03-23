using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Intro : Form
    {
        private Button btnEasy, btnMedium, btnHard, btnRules, btnCreators;
        private System.Windows.Forms.Timer animationTimer;
        private Button currentButton;
        private bool zoomIn;
        private const int ZoomStep = 2;
        private const int MaxZoom = 10;

        public Intro()
        {
            InitializeComponent();
            InitializeButtons();
            InitializeAnimationTimer();
        }

        private void InitializeButtons()
        {
            this.Text = "Sudoku - Selecciona la dificultad";
            this.Size = new Size(400, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Al cerrar Intro, se termina la aplicación.
            this.FormClosed += (s, e) => Application.Exit();

            TableLayoutPanel mainTlp = new TableLayoutPanel();
            mainTlp.Dock = DockStyle.Fill;
            mainTlp.BackColor = Color.Transparent;
            mainTlp.ColumnCount = 1;
            mainTlp.RowCount = 2;
            mainTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            mainTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            this.Controls.Add(mainTlp);

            Label lblTitle = new Label();
            lblTitle.Text = "NumberMaster";
            lblTitle.Font = new Font("Arial", 36, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Fill;
            mainTlp.Controls.Add(lblTitle, 0, 0);

            TableLayoutPanel buttonsTlp = new TableLayoutPanel();
            buttonsTlp.Dock = DockStyle.Fill;
            buttonsTlp.ColumnCount = 1;
            buttonsTlp.RowCount = 5;
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

            btnEasy = new Button();
            btnEasy.Text = "Facil";
            btnEasy.Font = buttonFont;
            btnEasy.BackColor = Color.LightGreen;
            btnEasy.ForeColor = Color.White;
            btnEasy.FlatStyle = flatStyle;
            btnEasy.FlatAppearance.BorderSize = 0;
            btnEasy.Size = new Size(buttonWidth, buttonHeight);
            btnEasy.Anchor = AnchorStyles.None;
            btnEasy.Click += new EventHandler(btnEasy_Click);
            btnEasy.MouseEnter += Button_MouseEnter;
            btnEasy.MouseLeave += Button_MouseLeave;
            buttonsTlp.Controls.Add(btnEasy, 0, 0);

            btnMedium = new Button();
            btnMedium.Text = "Medio";
            btnMedium.Font = buttonFont;
            btnMedium.BackColor = Color.Goldenrod;
            btnMedium.ForeColor = Color.White;
            btnMedium.FlatStyle = flatStyle;
            btnMedium.FlatAppearance.BorderSize = 0;
            btnMedium.Size = new Size(buttonWidth, buttonHeight);
            btnMedium.Anchor = AnchorStyles.None;
            btnMedium.Click += new EventHandler(btnMedium_Click);
            btnMedium.MouseEnter += Button_MouseEnter;
            btnMedium.MouseLeave += Button_MouseLeave;
            buttonsTlp.Controls.Add(btnMedium, 0, 1);

            btnHard = new Button();
            btnHard.Text = "Dificil";
            btnHard.Font = buttonFont;
            btnHard.BackColor = Color.IndianRed;
            btnHard.ForeColor = Color.White;
            btnHard.FlatStyle = flatStyle;
            btnHard.FlatAppearance.BorderSize = 0;
            btnHard.Size = new Size(buttonWidth, buttonHeight);
            btnHard.Anchor = AnchorStyles.None;
            btnHard.Click += new EventHandler(btnHard_Click);
            btnHard.MouseEnter += Button_MouseEnter;
            btnHard.MouseLeave += Button_MouseLeave;
            buttonsTlp.Controls.Add(btnHard, 0, 2);

            btnRules = new Button();
            btnRules.Text = "Reglas";
            btnRules.Font = buttonFont;
            btnRules.BackColor = Color.SkyBlue;
            btnRules.ForeColor = Color.White;
            btnRules.FlatStyle = flatStyle;
            btnRules.FlatAppearance.BorderSize = 0;
            btnRules.Size = new Size(buttonWidth, buttonHeight);
            btnRules.Anchor = AnchorStyles.None;
            btnRules.Click += new EventHandler(btnRules_Click);
            btnRules.MouseEnter += Button_MouseEnter;
            btnRules.MouseLeave += Button_MouseLeave;
            buttonsTlp.Controls.Add(btnRules, 0, 3);

            btnCreators = new Button();
            btnCreators.Text = "Creadores";
            btnCreators.Font = buttonFont;
            btnCreators.BackColor = Color.MediumPurple;
            btnCreators.ForeColor = Color.White;
            btnCreators.FlatStyle = flatStyle;
            btnCreators.FlatAppearance.BorderSize = 0;
            btnCreators.Size = new Size(buttonWidth, buttonHeight);
            btnCreators.Anchor = AnchorStyles.None;
            btnCreators.Click += new EventHandler(btnCreators_Click);
            btnCreators.MouseEnter += Button_MouseEnter;
            btnCreators.MouseLeave += Button_MouseLeave;
            buttonsTlp.Controls.Add(btnCreators, 0, 4);
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            currentButton = sender as Button;
            zoomIn = true;
            animationTimer.Start();
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            currentButton = sender as Button;
            zoomIn = false;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
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

       

        private void btnEasy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nivel Facil Seleccionado!");
            FormNivelFacil nivelFacilForm = new FormNivelFacil();

            nivelFacilForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            nivelFacilForm.Show();
            this.Hide();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nivel Medio seleccionado!");
            NivelMedio nivelMedioForm = new NivelMedio();

            nivelMedioForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            nivelMedioForm.Show();
            this.Hide();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nivel dificil selecionado!");
            NivelDificil hardForm = new NivelDificil();
            hardForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            hardForm.Show();
            this.Hide();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            ReglasDelJuego reglasDelJuego = new ReglasDelJuego();
            reglasDelJuego.Show();
        }

        private void btnCreators_Click(object sender, EventArgs e)
        {
            Integrantes integrantes = new Integrantes();
            integrantes.Show();
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