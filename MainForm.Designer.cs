namespace Proyecto
{
    partial class MainForm
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
            LblBienvenidos = new Label();
            BtnIntegrantes = new Button();
            btnReglas = new Button();
            label1 = new Label();
            BtnFacil = new Button();
            BtnMedio = new Button();
            BtnDificil = new Button();
            SuspendLayout();
            // 
            // LblBienvenidos
            // 
            LblBienvenidos.AutoSize = true;
            LblBienvenidos.Font = new Font("Bernard MT Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblBienvenidos.Location = new Point(158, 25);
            LblBienvenidos.Name = "LblBienvenidos";
            LblBienvenidos.Size = new Size(182, 22);
            LblBienvenidos.TabIndex = 0;
            LblBienvenidos.Text = "BIENVENIDOS AL SUDOKU";
            // 
            // BtnIntegrantes
            // 
            BtnIntegrantes.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnIntegrantes.Location = new Point(79, 80);
            BtnIntegrantes.Name = "BtnIntegrantes";
            BtnIntegrantes.Size = new Size(134, 43);
            BtnIntegrantes.TabIndex = 1;
            BtnIntegrantes.Text = "Integrantes";
            BtnIntegrantes.UseVisualStyleBackColor = true;
            BtnIntegrantes.Click += BtnIntegrantes_Click;
            // 
            // btnReglas
            // 
            btnReglas.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReglas.Location = new Point(258, 80);
            btnReglas.Name = "btnReglas";
            btnReglas.Size = new Size(155, 43);
            btnReglas.TabIndex = 2;
            btnReglas.Text = "Reglas del juego";
            btnReglas.UseVisualStyleBackColor = true;
            btnReglas.Click += btnReglas_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(180, 149);
            label1.Name = "label1";
            label1.Size = new Size(137, 24);
            label1.TabIndex = 3;
            label1.Text = "Elige el nivel";
            // 
            // BtnFacil
            // 
            BtnFacil.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnFacil.Location = new Point(53, 193);
            BtnFacil.Name = "BtnFacil";
            BtnFacil.Size = new Size(110, 43);
            BtnFacil.TabIndex = 4;
            BtnFacil.Text = "Facil";
            BtnFacil.UseVisualStyleBackColor = true;
            BtnFacil.Click += BtnFacil_Click;
            // 
            // BtnMedio
            // 
            BtnMedio.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnMedio.Location = new Point(191, 193);
            BtnMedio.Name = "BtnMedio";
            BtnMedio.Size = new Size(117, 43);
            BtnMedio.TabIndex = 5;
            BtnMedio.Text = "Medio";
            BtnMedio.UseVisualStyleBackColor = true;
            // 
            // BtnDificil
            // 
            BtnDificil.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnDificil.Location = new Point(328, 193);
            BtnDificil.Name = "BtnDificil";
            BtnDificil.Size = new Size(120, 43);
            BtnDificil.TabIndex = 6;
            BtnDificil.Text = "Dificil";
            BtnDificil.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 300);
            Controls.Add(BtnDificil);
            Controls.Add(BtnMedio);
            Controls.Add(BtnFacil);
            Controls.Add(label1);
            Controls.Add(btnReglas);
            Controls.Add(BtnIntegrantes);
            Controls.Add(LblBienvenidos);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblBienvenidos;
        private Button BtnIntegrantes;
        private Button btnReglas;
        private Label label1;
        private Button BtnFacil;
        private Button BtnMedio;
        private Button BtnDificil;
    }
}