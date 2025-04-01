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
            btnSolucion = new Button();
            btnReanudar = new Button();
            btnReinicar = new Button();
            btnPausar = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            LblpartidasP = new Label();
            LblpartidasG = new Label();
            lblTiempo = new Label();
            lblErrores = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSolucion
            // 
            btnSolucion.BackColor = Color.White;
            btnSolucion.BackgroundImage = Properties.Resources.solucioj;
            btnSolucion.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolucion.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolucion.Location = new Point(293, 560);
            btnSolucion.Margin = new Padding(3, 4, 3, 4);
            btnSolucion.Name = "btnSolucion";
            btnSolucion.Size = new Size(74, 59);
            btnSolucion.TabIndex = 13;
            btnSolucion.UseVisualStyleBackColor = false;
            btnSolucion.Click += btnSolucion_Click;
            // 
            // btnReanudar
            // 
            btnReanudar.BackgroundImage = Properties.Resources.Reanudar;
            btnReanudar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReanudar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReanudar.Location = new Point(207, 557);
            btnReanudar.Margin = new Padding(3, 4, 3, 4);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(74, 59);
            btnReanudar.TabIndex = 12;
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click;
            // 
            // btnReinicar
            // 
            btnReinicar.BackgroundImage = Properties.Resources.reinciar3;
            btnReinicar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReinicar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinicar.Location = new Point(40, 557);
            btnReinicar.Margin = new Padding(3, 4, 3, 4);
            btnReinicar.Name = "btnReinicar";
            btnReinicar.Size = new Size(74, 59);
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
            btnPausar.Location = new Point(122, 557);
            btnPausar.Margin = new Padding(3, 4, 3, 4);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(74, 59);
            btnPausar.TabIndex = 10;
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.the_universe_brain_GIF_by_Percolate_Galactic;
            pictureBox1.Location = new Point(556, 146);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(186, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // LblpartidasP
            // 
            LblpartidasP.AutoSize = true;
            LblpartidasP.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            LblpartidasP.ForeColor = Color.White;
            LblpartidasP.Location = new Point(443, 260);
            LblpartidasP.Name = "LblpartidasP";
            LblpartidasP.Size = new Size(294, 22);
            LblpartidasP.TabIndex = 20;
            LblpartidasP.Text = "Partidas Perdidas";
            // 
            // LblpartidasG
            // 
            LblpartidasG.AutoSize = true;
            LblpartidasG.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            LblpartidasG.ForeColor = Color.White;
            LblpartidasG.Location = new Point(443, 339);
            LblpartidasG.Name = "LblpartidasG";
            LblpartidasG.Size = new Size(285, 22);
            LblpartidasG.TabIndex = 19;
            LblpartidasG.Text = "Partidas Ganadas";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            lblTiempo.ForeColor = Color.White;
            lblTiempo.Location = new Point(443, 146);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(114, 22);
            lblTiempo.TabIndex = 18;
            lblTiempo.Text = "Tiempo";
            // 
            // lblErrores
            // 
            lblErrores.AutoSize = true;
            lblErrores.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            lblErrores.ForeColor = Color.White;
            lblErrores.Location = new Point(443, 199);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(236, 22);
            lblErrores.TabIndex = 17;
            lblErrores.Text = "Total Errores";
            // 
            // NivelDificil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_03_21_at_20_41_06_62e691ce;
            ClientSize = new Size(758, 635);
            Controls.Add(LblpartidasP);
            Controls.Add(LblpartidasG);
            Controls.Add(lblTiempo);
            Controls.Add(lblErrores);
            Controls.Add(pictureBox1);
            Controls.Add(btnSolucion);
            Controls.Add(btnReanudar);
            Controls.Add(btnReinicar);
            Controls.Add(btnPausar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NivelDificil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NumberMaster (Dificil)";
            Load += NivelDificil_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSolucion;
        private Button btnReanudar;
        private Button btnReinicar;
        private Button btnPausar;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Label LblpartidasP;
        private Label LblpartidasG;
        private Label lblTiempo;
        private Label lblErrores;
    }
}