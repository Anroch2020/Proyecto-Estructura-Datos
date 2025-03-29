namespace Proyecto
{
    partial class NivelMedio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NivelMedio));
            LblpartidasP = new Label();
            LblpartidasG = new Label();
            btnSolucion = new Button();
            btnReanudar = new Button();
            btnReinicar = new Button();
            btnPausar = new Button();
            lblTiempo = new Label();
            lblErrores = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // LblpartidasP
            // 
            LblpartidasP.AutoSize = true;
            LblpartidasP.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblpartidasP.Location = new Point(322, 579);
            LblpartidasP.Name = "LblpartidasP";
            LblpartidasP.Size = new Size(148, 23);
            LblpartidasP.TabIndex = 15;
            LblpartidasP.Text = "Partidas Perdidas";
            // 
            // LblpartidasG
            // 
            LblpartidasG.AutoSize = true;
            LblpartidasG.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblpartidasG.Location = new Point(11, 579);
            LblpartidasG.Name = "LblpartidasG";
            LblpartidasG.Size = new Size(147, 23);
            LblpartidasG.TabIndex = 14;
            LblpartidasG.Text = "Partidas Ganadas";
            // 
            // btnSolucion
            // 
            btnSolucion.BackgroundImage = Properties.Resources.solucioj;
            btnSolucion.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolucion.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolucion.Location = new Point(154, 611);
            btnSolucion.Margin = new Padding(3, 4, 3, 4);
            btnSolucion.Name = "btnSolucion";
            btnSolucion.Size = new Size(50, 38);
            btnSolucion.TabIndex = 13;
            btnSolucion.UseVisualStyleBackColor = true;
            btnSolucion.Click += btnSolucion_Click;
            // 
            // btnReanudar
            // 
            btnReanudar.BackgroundImage = Properties.Resources.Reanudar;
            btnReanudar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReanudar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReanudar.Location = new Point(107, 611);
            btnReanudar.Margin = new Padding(3, 4, 3, 4);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(41, 38);
            btnReanudar.TabIndex = 12;
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click;
            // 
            // btnReinicar
            // 
            btnReinicar.BackgroundImage = Properties.Resources.reinciar3;
            btnReinicar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReinicar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinicar.Location = new Point(11, 611);
            btnReinicar.Margin = new Padding(3, 4, 3, 4);
            btnReinicar.Name = "btnReinicar";
            btnReinicar.Size = new Size(43, 38);
            btnReinicar.TabIndex = 11;
            btnReinicar.UseVisualStyleBackColor = true;
            btnReinicar.Click += btnReinicar_Click;
            // 
            // btnPausar
            // 
            btnPausar.BackgroundImage = Properties.Resources.Pausar2;
            btnPausar.BackgroundImageLayout = ImageLayout.Stretch;
            btnPausar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPausar.ForeColor = Color.Black;
            btnPausar.Location = new Point(60, 611);
            btnPausar.Margin = new Padding(3, 4, 3, 4);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(43, 38);
            btnPausar.TabIndex = 10;
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTiempo.Location = new Point(11, 544);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(62, 20);
            lblTiempo.TabIndex = 9;
            lblTiempo.Text = "Tiempo";
            // 
            // lblErrores
            // 
            lblErrores.AutoSize = true;
            lblErrores.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrores.Location = new Point(322, 544);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(98, 20);
            lblErrores.TabIndex = 8;
            lblErrores.Text = "Total Errores";
            // 
            // NivelMedio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            BackgroundImage = Properties.Resources.medio2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(483, 657);
            Controls.Add(LblpartidasP);
            Controls.Add(LblpartidasG);
            Controls.Add(btnSolucion);
            Controls.Add(btnReanudar);
            Controls.Add(btnReinicar);
            Controls.Add(btnPausar);
            Controls.Add(lblTiempo);
            Controls.Add(lblErrores);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NivelMedio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NumberMaster (Medio)";
            Load += NivelMedio_Load;
            Paint += NivelMedio_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblpartidasP;
        private Label LblpartidasG;
        private Button btnSolucion;
        private Button btnReanudar;
        private Button btnReinicar;
        private Button btnPausar;
        private Label lblTiempo;
        private Label lblErrores;
        private System.Windows.Forms.Timer timer1;
    }
}