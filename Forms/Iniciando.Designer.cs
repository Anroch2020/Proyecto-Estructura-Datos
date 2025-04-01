namespace Proyecto
{
    partial class Iniciando
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Iniciando));
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            BtnPlay = new Button();
            progressBar1 = new ProgressBar();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Video_Game_Head_GIF;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(475, 541);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // BtnPlay
            // 
            BtnPlay.BackColor = Color.Fuchsia;
            BtnPlay.BackgroundImage = Properties.Resources._6ac8b220_f073_4f10_8772_d9d355af11ed;
            BtnPlay.BackgroundImageLayout = ImageLayout.Stretch;
            BtnPlay.Location = new Point(156, 327);
            BtnPlay.Margin = new Padding(3, 4, 3, 4);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(170, 90);
            BtnPlay.TabIndex = 7;
            BtnPlay.UseVisualStyleBackColor = false;
            BtnPlay.Click += BtnPlay_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(77, 436);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(322, 31);
            progressBar1.TabIndex = 8;
            progressBar1.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Fuchsia;
            pictureBox2.Image = Properties.Resources.Letras;
            pictureBox2.Location = new Point(12, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(451, 86);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // Iniciando
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(475, 541);
            Controls.Add(pictureBox2);
            Controls.Add(progressBar1);
            Controls.Add(BtnPlay);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Iniciando";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciando";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Button BtnPlay;
        private ProgressBar progressBar1;
        private PictureBox pictureBox2;
    }
}