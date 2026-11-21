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
            btnShare = new Button();
            SuspendLayout();
            // 
            // lblWordle
            // 
            lblWordle.AutoSize = true;
            lblWordle.Location = new Point(228, 70);
            lblWordle.Name = "lblWordle";
            lblWordle.Size = new Size(96, 15);
            lblWordle.TabIndex = 0;
            lblWordle.Text = "Big Wordle Label";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(12, 11);
            btnRestart.Margin = new Padding(3, 2, 3, 2);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(100, 22);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "Restart Game";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnShare
            // 
            btnShare.Location = new Point(563, 12);
            btnShare.Name = "btnShare";
            btnShare.Size = new Size(75, 23);
            btnShare.TabIndex = 2;
            btnShare.Text = "Share";
            btnShare.UseVisualStyleBackColor = true;
            btnShare.Click += btnShare_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(650, 691);
            Controls.Add(btnShare);
            Controls.Add(btnRestart);
            Controls.Add(lblWordle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWordle;
        private Button btnRestart;
        private Button btnShare;
    }
}
