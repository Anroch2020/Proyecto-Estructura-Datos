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
            LblSudoku.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSudoku.Location = new Point(157, 28);
            LblSudoku.Name = "LblSudoku";
            LblSudoku.Size = new Size(249, 32);
            LblSudoku.TabIndex = 5;
            LblSudoku.Text = "Reglas de Sudoku";
            // 
            // rtbReglas
            // 
            rtbReglas.Location = new Point(29, 81);
            rtbReglas.Margin = new Padding(3, 4, 3, 4);
            rtbReglas.Name = "rtbReglas";
            rtbReglas.Size = new Size(485, 317);
            rtbReglas.TabIndex = 7;
            rtbReglas.Text = "";
            // 
            // ReglasDelJuego
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(538, 496);
            Controls.Add(rtbReglas);
            Controls.Add(LblSudoku);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReglasDelJuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reglas Del Juego";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblSudoku;
// private Button LblReglas;
        private RichTextBox rtbReglas;
    }
}