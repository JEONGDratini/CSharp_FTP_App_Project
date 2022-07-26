namespace FTP_Admin
{
    partial class Form2
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
            this.NewFolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NewFolder_Button = new System.Windows.Forms.Button();
            this.Current_Path = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewFolderName
            // 
            this.NewFolderName.Location = new System.Drawing.Point(12, 32);
            this.NewFolderName.Name = "NewFolderName";
            this.NewFolderName.Size = new System.Drawing.Size(160, 21);
            this.NewFolderName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "새폴더 이름을 입력하세요.";
            // 
            // NewFolder_Button
            // 
            this.NewFolder_Button.Location = new System.Drawing.Point(178, 32);
            this.NewFolder_Button.Name = "NewFolder_Button";
            this.NewFolder_Button.Size = new System.Drawing.Size(75, 23);
            this.NewFolder_Button.TabIndex = 2;
            this.NewFolder_Button.Text = "폴더생성";
            this.NewFolder_Button.UseVisualStyleBackColor = true;
            this.NewFolder_Button.Click += new System.EventHandler(this.NewFolder_Button_Click);
            // 
            // Current_Path
            // 
            this.Current_Path.AutoSize = true;
            this.Current_Path.Location = new System.Drawing.Point(12, 56);
            this.Current_Path.Name = "Current_Path";
            this.Current_Path.Size = new System.Drawing.Size(41, 12);
            this.Current_Path.TabIndex = 3;
            this.Current_Path.Text = "위치 : ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 79);
            this.Controls.Add(this.Current_Path);
            this.Controls.Add(this.NewFolder_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewFolderName);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewFolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NewFolder_Button;
        private System.Windows.Forms.Label Current_Path;
    }
}