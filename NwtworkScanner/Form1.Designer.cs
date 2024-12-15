namespace NwtworkScanner
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
            btnShutDown = new Button();
            btnWakeUp = new Button();
            txtComputerName = new TextBox();
            SuspendLayout();
            // 
            // lbComputers
            // 
            lbComputers.FormattingEnabled = true;
            lbComputers.Location = new Point(61, 128);
            lbComputers.Name = "lbComputers";
            lbComputers.Size = new Size(120, 124);
            lbComputers.TabIndex = 0;
            // 
            // btnShutDown
            // 
            btnShutDown.Location = new Point(210, 203);
            btnShutDown.Name = "btnShutDown";
            btnShutDown.Size = new Size(75, 23);
            btnShutDown.TabIndex = 1;
            btnShutDown.Text = "Kapat";
            btnShutDown.UseVisualStyleBackColor = true;
            btnShutDown.Click += btnShutDown_Click;
            // 
            // btnWakeUp
            // 
            btnWakeUp.Location = new Point(331, 203);
            btnWakeUp.Name = "btnWakeUp";
            btnWakeUp.Size = new Size(75, 23);
            btnWakeUp.TabIndex = 2;
            btnWakeUp.Text = "Aç";
            btnWakeUp.UseVisualStyleBackColor = true;
            btnWakeUp.Click += btnWakeUp_Click;
            // 
            // txtComputerName
            // 
            txtComputerName.Location = new Point(213, 157);
            txtComputerName.Name = "txtComputerName";
            txtComputerName.Size = new Size(193, 23);
            txtComputerName.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtComputerName);
            Controls.Add(btnWakeUp);
            Controls.Add(btnShutDown);
            Controls.Add(lbComputers);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbComputers;
        private Button btnShutDown;
        private Button btnWakeUp;
        private TextBox txtComputerName;
    }
}
