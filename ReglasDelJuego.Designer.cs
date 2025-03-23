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
            LblSudoku = new Label();
            rtbReglas = new RichTextBox();
            SuspendLayout();
            // 
            // LblSudoku
            // 
            LblSudoku.AutoSize = true;
            LblSudoku.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSudoku.Location = new Point(137, 21);
            LblSudoku.Name = "LblSudoku";
            LblSudoku.Size = new Size(192, 24);
            LblSudoku.TabIndex = 5;
            LblSudoku.Text = "Reglas de Sudoku";
            // 
            // rtbReglas
            // 
            rtbReglas.Location = new Point(25, 61);
            rtbReglas.Name = "rtbReglas";
            rtbReglas.Size = new Size(425, 239);
            rtbReglas.TabIndex = 7;
            rtbReglas.Text = "";
            // 
            // ReglasDelJuego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(471, 372);
            Controls.Add(rtbReglas);
            Controls.Add(LblSudoku);
            Name = "ReglasDelJuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReglasDelJuego";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblSudoku;
        private Button LblReglas;
        private RichTextBox rtbReglas;
    }
}