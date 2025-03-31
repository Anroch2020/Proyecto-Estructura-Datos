namespace Proyecto
{
    partial class NivelDificil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NivelDificil));
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
            LblpartidasP.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            LblpartidasP.ForeColor = Color.White;
            LblpartidasP.Location = new Point(384, 166);
            LblpartidasP.Name = "LblpartidasP";
            LblpartidasP.Size = new Size(235, 17);
            LblpartidasP.TabIndex = 15;
            LblpartidasP.Text = "Partidas Perdidas";
            // 
            // LblpartidasG
            // 
            LblpartidasG.AutoSize = true;
            LblpartidasG.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            LblpartidasG.ForeColor = Color.White;
            LblpartidasG.Location = new Point(384, 225);
            LblpartidasG.Name = "LblpartidasG";
            LblpartidasG.Size = new Size(227, 17);
            LblpartidasG.TabIndex = 14;
            LblpartidasG.Text = "Partidas Ganadas";
            // 
            // btnSolucion
            // 
            btnSolucion.BackColor = Color.White;
            btnSolucion.BackgroundImage = Properties.Resources.solucioj;
            btnSolucion.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolucion.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolucion.Location = new Point(256, 420);
            btnSolucion.Name = "btnSolucion";
            btnSolucion.Size = new Size(65, 44);
            btnSolucion.TabIndex = 13;
            btnSolucion.UseVisualStyleBackColor = false;
            btnSolucion.Click += btnSolucion_Click;
            // 
            // btnReanudar
            // 
            btnReanudar.BackgroundImage = Properties.Resources.Reanudar;
            btnReanudar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReanudar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReanudar.Location = new Point(181, 418);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(65, 44);
            btnReanudar.TabIndex = 12;
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click;
            // 
            // btnReinicar
            // 
            btnReinicar.BackgroundImage = Properties.Resources.reinciar3;
            btnReinicar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReinicar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinicar.Location = new Point(35, 418);
            btnReinicar.Name = "btnReinicar";
            btnReinicar.Size = new Size(65, 44);
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
            btnPausar.Location = new Point(107, 418);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(65, 44);
            btnPausar.TabIndex = 10;
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            lblTiempo.ForeColor = Color.White;
            lblTiempo.Location = new Point(384, 431);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(91, 17);
            lblTiempo.TabIndex = 9;
            lblTiempo.Text = "Tiempo";
            // 
            // lblErrores
            // 
            lblErrores.AutoSize = true;
            lblErrores.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            lblErrores.ForeColor = Color.White;
            lblErrores.Location = new Point(384, 120);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(186, 17);
            lblErrores.TabIndex = 8;
            lblErrores.Text = "Total Errores";
            // 
            // NivelDificil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_03_21_at_20_41_06_62e691ce;
            ClientSize = new Size(663, 476);
            Controls.Add(LblpartidasP);
            Controls.Add(LblpartidasG);
            Controls.Add(btnSolucion);
            Controls.Add(btnReanudar);
            Controls.Add(btnReinicar);
            Controls.Add(btnPausar);
            Controls.Add(lblTiempo);
            Controls.Add(lblErrores);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NivelDificil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NumberMaster (Dificil)";
            Load += NivelDificil_Load;
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