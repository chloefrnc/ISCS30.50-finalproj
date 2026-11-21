namespace Francisco_Funelas_FinalProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWordle = new Label();
            btnRestart = new Button();
            SuspendLayout();
            // 
            // lblWordle
            // 
            lblWordle.AutoSize = true;
            lblWordle.Location = new Point(261, 94);
            lblWordle.Name = "lblWordle";
            lblWordle.Size = new Size(123, 20);
            lblWordle.TabIndex = 0;
            lblWordle.Text = "Big Wordle Label";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(540, 12);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(114, 29);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "Restart Game";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 723);
            Controls.Add(btnRestart);
            Controls.Add(lblWordle);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWordle;
        private Button btnRestart;
    }
}
