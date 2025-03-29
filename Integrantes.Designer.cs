namespace Proyecto
{
    partial class Integrantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Integrantes));
            LblEstructura = new Label();
            LblNombres = new Label();
            pictureBox1 = new PictureBox();
            rtbIntegrantes = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LblEstructura
            // 
            LblEstructura.AutoSize = true;
            LblEstructura.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblEstructura.Location = new Point(134, 71);
            LblEstructura.Name = "LblEstructura";
            LblEstructura.Size = new Size(279, 32);
            LblEstructura.TabIndex = 4;
            LblEstructura.Text = "Estructura de Datos";
            // 
            // LblNombres
            // 
            LblNombres.AutoSize = true;
            LblNombres.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblNombres.Location = new Point(87, 233);
            LblNombres.Name = "LblNombres";
            LblNombres.Size = new Size(0, 23);
            LblNombres.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(403, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // rtbIntegrantes
            // 
            rtbIntegrantes.Location = new Point(75, 153);
            rtbIntegrantes.Margin = new Padding(3, 4, 3, 4);
            rtbIntegrantes.Name = "rtbIntegrantes";
            rtbIntegrantes.Size = new Size(373, 245);
            rtbIntegrantes.TabIndex = 9;
            rtbIntegrantes.Text = "";
            // 
            // Integrantes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(535, 476);
            Controls.Add(rtbIntegrantes);
            Controls.Add(pictureBox1);
            Controls.Add(LblNombres);
            Controls.Add(LblEstructura);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Integrantes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Integrantes";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblEstructura;
        private Label LblNombres;
        private PictureBox pictureBox1;
        private RichTextBox rtbIntegrantes;
    }
}