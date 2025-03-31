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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNivelFacil));
            timer1 = new System.Windows.Forms.Timer(components);
            lblErrores = new Label();
            lblTiempo = new Label();
            btnPausar = new Button();
            btnReinicar = new Button();
            btnReanudar = new Button();
            btnSolucion = new Button();
            LblpartidasG = new Label();
            LblpartidasP = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += Timer1_Tick;
            // 
            // lblErrores
            // 
            lblErrores.AutoSize = true;
            lblErrores.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            lblErrores.Location = new Point(391, 123);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(186, 17);
            lblErrores.TabIndex = 0;
            lblErrores.Text = "Total Errores";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            lblTiempo.Location = new Point(393, 432);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(91, 17);
            lblTiempo.TabIndex = 1;
            lblTiempo.Text = "Tiempo";
            // 
            // btnPausar
            // 
            btnPausar.BackgroundImage = Properties.Resources.Pausar2;
            btnPausar.BackgroundImageLayout = ImageLayout.Stretch;
            btnPausar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPausar.ForeColor = Color.Black;
            btnPausar.Location = new Point(107, 419);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(65, 44);
            btnPausar.TabIndex = 2;
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click_1;
            // 
            // btnReinicar
            // 
            btnReinicar.BackgroundImage = Properties.Resources.reinciar3;
            btnReinicar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReinicar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReinicar.Location = new Point(30, 419);
            btnReinicar.Name = "btnReinicar";
            btnReinicar.Size = new Size(65, 44);
            btnReinicar.TabIndex = 3;
            btnReinicar.UseVisualStyleBackColor = true;
            btnReinicar.Click += btnReinicar_Click;
            // 
            // btnReanudar
            // 
            btnReanudar.BackgroundImage = Properties.Resources.Reanudar;
            btnReanudar.BackgroundImageLayout = ImageLayout.Stretch;
            btnReanudar.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReanudar.Location = new Point(187, 419);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(65, 44);
            btnReanudar.TabIndex = 4;
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click_1;
            // 
            // btnSolucion
            // 
            btnSolucion.BackColor = Color.Yellow;
            btnSolucion.BackgroundImage = Properties.Resources.solucioj;
            btnSolucion.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolucion.Font = new Font("Perpetua Titling MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolucion.Location = new Point(269, 419);
            btnSolucion.Name = "btnSolucion";
            btnSolucion.Size = new Size(65, 44);
            btnSolucion.TabIndex = 5;
            btnSolucion.UseVisualStyleBackColor = false;
            btnSolucion.Click += btnSolucion_Click_1;
            // 
            // LblpartidasG
            // 
            LblpartidasG.AutoSize = true;
            LblpartidasG.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            LblpartidasG.Location = new Point(391, 183);
            LblpartidasG.Name = "LblpartidasG";
            LblpartidasG.Size = new Size(227, 17);
            LblpartidasG.TabIndex = 6;
            LblpartidasG.Text = "Partidas Ganadas";
            // 
            // LblpartidasP
            // 
            LblpartidasP.AutoSize = true;
            LblpartidasP.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold);
            LblpartidasP.Location = new Point(394, 242);
            LblpartidasP.Name = "LblpartidasP";
            LblpartidasP.Size = new Size(235, 17);
            LblpartidasP.TabIndex = 7;
            LblpartidasP.Text = "Partidas Perdidas";
            LblpartidasP.Click += LblpartidasP_Click;
            // 
            // button1
            // 
            button1.Location = new Point(801, 97);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormNivelFacil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            BackgroundImage = Properties.Resources.WhatsApp_Image_2025_03_21_at_20_40_13_0620133f;
            ClientSize = new Size(663, 476);
            Controls.Add(button1);
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
            Name = "FormNivelFacil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NumberMaster (Facil)";
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
        private Button button1;
    }
}