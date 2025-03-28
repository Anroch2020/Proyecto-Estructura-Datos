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
            LblpartidasP.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblpartidasP.ForeColor = Color.White;
            LblpartidasP.Location = new Point(278, 433);
            LblpartidasP.Name = "LblpartidasP";
            LblpartidasP.Size = new Size(115, 17);
            LblpartidasP.TabIndex = 15;
            LblpartidasP.Text = "Partidas Perdidas";
            // 
            // LblpartidasG
            // 
            LblpartidasG.AutoSize = true;
            LblpartidasG.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblpartidasG.ForeColor = Color.White;
            LblpartidasG.Location = new Point(7, 433);
            LblpartidasG.Name = "LblpartidasG";
            LblpartidasG.Size = new Size(114, 17);
            LblpartidasG.TabIndex = 14;
            LblpartidasG.Text = "Partidas Ganadas";
            // 
            // btnSolucion
            // 
            btnSolucion.BackColor = Color.Gold;
            btnSolucion.BackgroundImage = Properties.Resources.solucioj;
            btnSolucion.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolucion.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolucion.Location = new Point(364, 453);
            btnSolucion.Name = "btnSolucion";
            btnSolucion.Size = new Size(44, 31);
            btnSolucion.TabIndex = 13;
            btnSolucion.UseVisualStyleBackColor = false;
            btnSolucion.Click += btnSolucion_Click;
            // 
            // btnReanudar
            // 
            btnReanudar.BackgroundImage = Properties.Resources.Reanudar;
            btnReanudar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReanudar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReanudar.Location = new Point(186, 385);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(41, 32);
            btnReanudar.TabIndex = 12;
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click;
            // 
            // btnReinicar
            // 
            btnReinicar.BackgroundImage = (Image)resources.GetObject("btnReinicar.BackgroundImage");
            btnReinicar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReinicar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinicar.Location = new Point(10, 455);
            btnReinicar.Name = "btnReinicar";
            btnReinicar.Size = new Size(38, 28);
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
            btnPausar.Location = new Point(186, 423);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(41, 30);
            btnPausar.TabIndex = 10;
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTiempo.ForeColor = Color.White;
            lblTiempo.Location = new Point(7, 399);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(49, 15);
            lblTiempo.TabIndex = 9;
            lblTiempo.Text = "Tiempo";
            // 
            // lblErrores
            // 
            lblErrores.AutoSize = true;
            lblErrores.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrores.ForeColor = Color.White;
            lblErrores.Location = new Point(278, 399);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(77, 15);
            lblErrores.TabIndex = 8;
            lblErrores.Text = "Total Errores";
            // 
            // NivelDificil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_03_21_at_20_41_06_62e691ce;
            ClientSize = new Size(424, 488);
            Controls.Add(LblpartidasP);
            Controls.Add(LblpartidasG);
            Controls.Add(btnSolucion);
            Controls.Add(btnReanudar);
            Controls.Add(btnReinicar);
            Controls.Add(btnPausar);
            Controls.Add(lblTiempo);
            Controls.Add(lblErrores);
            Name = "NivelDificil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NivelDificil";
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