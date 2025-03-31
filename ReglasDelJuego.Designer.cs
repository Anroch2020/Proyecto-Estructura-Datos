namespace Proyecto
{
    partial class ReglasDelJuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReglasDelJuego));
            LblSudoku = new Label();
            rtbReglas = new RichTextBox();
            SuspendLayout();
            // 
            // LblSudoku
            // 
            LblSudoku.AutoSize = true;
            LblSudoku.Font = new Font("Baskerville Old Face", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblSudoku.Location = new Point(126, 28);
            LblSudoku.Name = "LblSudoku";
            LblSudoku.Size = new Size(293, 31);
            LblSudoku.TabIndex = 5;
            LblSudoku.Text = "Reglas Number Masters";
            // 
            // rtbReglas
            // 
            rtbReglas.Location = new Point(57, 79);
            rtbReglas.Name = "rtbReglas";
            rtbReglas.Size = new Size(437, 281);
            rtbReglas.TabIndex = 7;
            rtbReglas.Text = "";
            // 
            // ReglasDelJuego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            BackgroundImage = Properties.Resources.Reglas;
            ClientSize = new Size(557, 423);
            Controls.Add(rtbReglas);
            Controls.Add(LblSudoku);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReglasDelJuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reglas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblSudoku;
// private Button LblReglas;
        private RichTextBox rtbReglas;
    }
}