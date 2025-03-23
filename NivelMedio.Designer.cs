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
            LblpartidasP.Location = new Point(289, 385);
            LblpartidasP.Name = "LblpartidasP";
            LblpartidasP.Size = new Size(115, 17);
            LblpartidasP.TabIndex = 15;
            LblpartidasP.Text = "Partidas Perdidas";
            // 
            // LblpartidasG
            // 
            LblpartidasG.AutoSize = true;
            LblpartidasG.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblpartidasG.Location = new Point(75, 385);
            LblpartidasG.Name = "LblpartidasG";
            LblpartidasG.Size = new Size(114, 17);
            LblpartidasG.TabIndex = 14;
            LblpartidasG.Text = "Partidas Ganadas";
            // 
            // btnSolucion
            // 
            btnSolucion.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolucion.Location = new Point(362, 412);
            btnSolucion.Name = "btnSolucion";
            btnSolucion.Size = new Size(95, 34);
            btnSolucion.TabIndex = 13;
            btnSolucion.Text = "Solución";
            btnSolucion.UseVisualStyleBackColor = true;
            btnSolucion.Click += btnSolucion_Click;
            // 
            // btnReanudar
            // 
            btnReanudar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReanudar.Location = new Point(243, 412);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(101, 34);
            btnReanudar.TabIndex = 12;
            btnReanudar.Text = "Reanudar";
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click;
            // 
            // btnReinicar
            // 
            btnReinicar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinicar.Location = new Point(136, 412);
            btnReinicar.Name = "btnReinicar";
            btnReinicar.Size = new Size(89, 34);
            btnReinicar.TabIndex = 11;
            btnReinicar.Text = "Reiniciar ";
            btnReinicar.UseVisualStyleBackColor = true;
            btnReinicar.Click += btnReinicar_Click;
            // 
            // btnPausar
            // 
            btnPausar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPausar.ForeColor = Color.Black;
            btnPausar.Location = new Point(42, 412);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(75, 34);
            btnPausar.TabIndex = 10;
            btnPausar.Text = "Pausar";
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTiempo.Location = new Point(380, 23);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(49, 15);
            lblTiempo.TabIndex = 9;
            lblTiempo.Text = "Tiempo";
            // 
            // lblErrores
            // 
            lblErrores.AutoSize = true;
            lblErrores.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrores.Location = new Point(380, 54);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(77, 15);
            lblErrores.TabIndex = 8;
            lblErrores.Text = "Total Errores";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // NivelMedio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(498, 469);
            Controls.Add(LblpartidasP);
            Controls.Add(LblpartidasG);
            Controls.Add(btnSolucion);
            Controls.Add(btnReanudar);
            Controls.Add(btnReinicar);
            Controls.Add(btnPausar);
            Controls.Add(lblTiempo);
            Controls.Add(lblErrores);
            ForeColor = SystemColors.ControlText;
            Name = "NivelMedio";
            Text = "NivelMedio";
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