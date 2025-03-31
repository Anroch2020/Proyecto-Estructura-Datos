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
            progressBar1 = new ProgressBar();
            BtnPlay = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(62, 343);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(282, 23);
            progressBar1.TabIndex = 5;
            progressBar1.Visible = false;
            // 
            // BtnPlay
            // 
            BtnPlay.BackColor = Color.Fuchsia;
            BtnPlay.BackgroundImage = Properties.Resources._6ac8b220_f073_4f10_8772_d9d355af11ed;
            BtnPlay.BackgroundImageLayout = ImageLayout.Stretch;
            BtnPlay.Location = new Point(103, 229);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(211, 95);
            BtnPlay.TabIndex = 4;
            BtnPlay.UseVisualStyleBackColor = false;
            BtnPlay.Click += BtnPlay_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Iniciando
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.NM2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(416, 406);
            Controls.Add(progressBar1);
            Controls.Add(BtnPlay);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Iniciando";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciando";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Button BtnPlay;
        private System.Windows.Forms.Timer timer1;
    }
}