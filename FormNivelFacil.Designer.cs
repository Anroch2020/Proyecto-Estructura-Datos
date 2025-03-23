namespace Proyecto
{
    partial class FormNivelFacil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            lblErrores = new Label();
            lblTiempo = new Label();
            btnPausar = new Button();
            btnReinicar = new Button();
            btnReanudar = new Button();
            btnSolucion = new Button();
            LblpartidasG = new Label();
            LblpartidasP = new Label();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += Timer1_Tick;
            // 
            // lblErrores
            // 
            lblErrores.AutoSize = true;
            lblErrores.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrores.Location = new Point(432, 73);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(98, 20);
            lblErrores.TabIndex = 0;
            lblErrores.Text = "Total Errores";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTiempo.Location = new Point(432, 32);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(62, 20);
            lblTiempo.TabIndex = 1;
            lblTiempo.Text = "Tiempo";
            // 
            // btnPausar
            // 
            btnPausar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPausar.ForeColor = Color.Black;
            btnPausar.Location = new Point(46, 551);
            btnPausar.Margin = new Padding(3, 4, 3, 4);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(86, 45);
            btnPausar.TabIndex = 2;
            btnPausar.Text = "Pausar";
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click_1;
            // 
            // btnReinicar
            // 
            btnReinicar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinicar.Location = new Point(153, 551);
            btnReinicar.Margin = new Padding(3, 4, 3, 4);
            btnReinicar.Name = "btnReinicar";
            btnReinicar.Size = new Size(102, 45);
            btnReinicar.TabIndex = 3;
            btnReinicar.Text = "Reiniciar ";
            btnReinicar.UseVisualStyleBackColor = true;
            btnReinicar.Click += btnReinicar_Click;
            // 
            // btnReanudar
            // 
            btnReanudar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReanudar.Location = new Point(275, 551);
            btnReanudar.Margin = new Padding(3, 4, 3, 4);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(115, 45);
            btnReanudar.TabIndex = 4;
            btnReanudar.Text = "Reanudar";
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click_1;
            // 
            // btnSolucion
            // 
            btnSolucion.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolucion.Location = new Point(411, 551);
            btnSolucion.Margin = new Padding(3, 4, 3, 4);
            btnSolucion.Name = "btnSolucion";
            btnSolucion.Size = new Size(109, 45);
            btnSolucion.TabIndex = 5;
            btnSolucion.Text = "Solución";
            btnSolucion.UseVisualStyleBackColor = true;
            btnSolucion.Click += btnSolucion_Click_1;
            // 
            // LblpartidasG
            // 
            LblpartidasG.AutoSize = true;
            LblpartidasG.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblpartidasG.Location = new Point(83, 515);
            LblpartidasG.Name = "LblpartidasG";
            LblpartidasG.Size = new Size(147, 23);
            LblpartidasG.TabIndex = 6;
            LblpartidasG.Text = "Partidas Ganadas";
            // 
            // LblpartidasP
            // 
            LblpartidasP.AutoSize = true;
            LblpartidasP.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblpartidasP.Location = new Point(328, 515);
            LblpartidasP.Name = "LblpartidasP";
            LblpartidasP.Size = new Size(148, 23);
            LblpartidasP.TabIndex = 7;
            LblpartidasP.Text = "Partidas Perdidas";
            // 
            // FormNivelFacil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_03_21_at_20_40_13_0620133f;
            ClientSize = new Size(565, 612);
            Controls.Add(LblpartidasP);
            Controls.Add(LblpartidasG);
            Controls.Add(btnSolucion);
            Controls.Add(btnReanudar);
            Controls.Add(btnReinicar);
            Controls.Add(btnPausar);
            Controls.Add(lblTiempo);
            Controls.Add(lblErrores);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormNivelFacil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormNivelFacil";
            Load += FormNivelFacil_Load;
            Paint += FormNivelFacil_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label lblErrores;
        private Label lblTiempo;
        private Button btnPausar;
        private Button btnReinicar;
        private Button btnReanudar;
        private Button btnSolucion;
        private Label LblpartidasG;
        private Label LblpartidasP;
    }
}