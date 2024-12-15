namespace HelpDeskDekstopFomrs
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
            label1 = new Label();
            btnAc = new Button();
            pcListBox = new ListBox();
            btnKapat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 96);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Bilgisayarlar";
            // 
            // btnAc
            // 
            btnAc.Location = new Point(256, 241);
            btnAc.Name = "btnAc";
            btnAc.Size = new Size(75, 23);
            btnAc.TabIndex = 1;
            btnAc.Text = "Aç";
            btnAc.UseVisualStyleBackColor = true;
            // 
            // pcListBox
            // 
            pcListBox.FormattingEnabled = true;
            pcListBox.Location = new Point(89, 125);
            pcListBox.Name = "pcListBox";
            pcListBox.Size = new Size(120, 154);
            pcListBox.TabIndex = 2;
            // 
            // btnKapat
            // 
            btnKapat.Location = new Point(377, 241);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(75, 23);
            btnKapat.TabIndex = 3;
            btnKapat.Text = "Kapat";
            btnKapat.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKapat);
            Controls.Add(pcListBox);
            Controls.Add(btnAc);
            Controls.Add(label1);
            Name = "Form1";
            Text = "HelpDeskDesktop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAc;
        private ListBox pcListBox;
        private Button btnKapat;
    }
}
