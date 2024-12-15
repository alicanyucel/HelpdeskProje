namespace WinFormsApp1
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
            lbComputers = new ListBox();
            btnShutdown = new Button();
            btnWakeUp = new Button();
            txtComputerName = new TextBox();
            SuspendLayout();
            // 
            // lbComputers
            // 
            lbComputers.FormattingEnabled = true;
            lbComputers.Location = new Point(43, 49);
            lbComputers.Name = "lbComputers";
            lbComputers.Size = new Size(120, 139);
            lbComputers.TabIndex = 0;
            // 
            // btnShutdown
            // 
            btnShutdown.Location = new Point(338, 150);
            btnShutdown.Name = "btnShutdown";
            btnShutdown.Size = new Size(75, 23);
            btnShutdown.TabIndex = 1;
            btnShutdown.Text = "Kapat";
            btnShutdown.UseVisualStyleBackColor = true;
            btnShutdown.Click += btnShutdown_Click;
            // 
            // btnWakeUp
            // 
            btnWakeUp.Location = new Point(191, 150);
            btnWakeUp.Name = "btnWakeUp";
            btnWakeUp.Size = new Size(75, 23);
            btnWakeUp.TabIndex = 2;
            btnWakeUp.Text = "Aç";
            btnWakeUp.UseVisualStyleBackColor = true;
            btnWakeUp.Click += btnWakeUp_Click;
            // 
            // txtComputerName
            // 
            txtComputerName.Location = new Point(191, 102);
            txtComputerName.Name = "txtComputerName";
            txtComputerName.Size = new Size(222, 23);
            txtComputerName.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtComputerName);
            Controls.Add(btnWakeUp);
            Controls.Add(btnShutdown);
            Controls.Add(lbComputers);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbComputers;
        private Button btnShutdown;
        private Button btnWakeUp;
        private TextBox txtComputerName;
    }
}
