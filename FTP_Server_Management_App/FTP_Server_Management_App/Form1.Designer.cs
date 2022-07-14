namespace FTP_Server_Management_App
{
    partial class FTP_Management
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.File_List = new System.Windows.Forms.DataGridView();
            this.File_list_label = new System.Windows.Forms.Label();
            this.Server_statement = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.File_Delete_Button = new System.Windows.Forms.Button();
            this.File_Upload_Button = new System.Windows.Forms.Button();
            this.User_request_List = new System.Windows.Forms.DataGridView();
            this.User_request_list_Label = new System.Windows.Forms.Label();
            this.User_request_Contents = new System.Windows.Forms.RichTextBox();
            this.User_request_Contents_Label = new System.Windows.Forms.Label();
            this.Find_FilePath_Button = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Admin_response_Contents = new System.Windows.Forms.Label();
            this.Send_Response_Contents = new System.Windows.Forms.Button();
            this.see_answered_request = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.File_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_request_List)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 391);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 21);
            this.textBox1.TabIndex = 0;
            // 
            // File_List
            // 
            this.File_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.File_List.Location = new System.Drawing.Point(12, 43);
            this.File_List.Name = "File_List";
            this.File_List.RowTemplate.Height = 23;
            this.File_List.Size = new System.Drawing.Size(267, 293);
            this.File_List.TabIndex = 1;
            // 
            // File_list_label
            // 
            this.File_list_label.AutoSize = true;
            this.File_list_label.Location = new System.Drawing.Point(10, 28);
            this.File_list_label.Name = "File_list_label";
            this.File_list_label.Size = new System.Drawing.Size(69, 12);
            this.File_list_label.TabIndex = 2;
            this.File_list_label.Text = "파일 리스트";
            // 
            // Server_statement
            // 
            this.Server_statement.AutoSize = true;
            this.Server_statement.Location = new System.Drawing.Point(634, 439);
            this.Server_statement.Name = "Server_statement";
            this.Server_statement.Size = new System.Drawing.Size(105, 12);
            this.Server_statement.TabIndex = 3;
            this.Server_statement.Text = "서버 상태 : 미확인";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "업로드할 파일경로";
            // 
            // File_Delete_Button
            // 
            this.File_Delete_Button.Location = new System.Drawing.Point(188, 342);
            this.File_Delete_Button.Name = "File_Delete_Button";
            this.File_Delete_Button.Size = new System.Drawing.Size(91, 29);
            this.File_Delete_Button.TabIndex = 5;
            this.File_Delete_Button.Text = "선택파일 삭제";
            this.File_Delete_Button.UseVisualStyleBackColor = true;
            this.File_Delete_Button.Click += new System.EventHandler(this.File_Delete_Button_Click);
            // 
            // File_Upload_Button
            // 
            this.File_Upload_Button.Location = new System.Drawing.Point(12, 418);
            this.File_Upload_Button.Name = "File_Upload_Button";
            this.File_Upload_Button.Size = new System.Drawing.Size(93, 23);
            this.File_Upload_Button.TabIndex = 6;
            this.File_Upload_Button.Text = "파일 업로드";
            this.File_Upload_Button.UseVisualStyleBackColor = true;
            this.File_Upload_Button.Click += new System.EventHandler(this.File_Upload_Button_Click);
            // 
            // User_request_List
            // 
            this.User_request_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_request_List.Location = new System.Drawing.Point(310, 43);
            this.User_request_List.Name = "User_request_List";
            this.User_request_List.RowTemplate.Height = 23;
            this.User_request_List.Size = new System.Drawing.Size(429, 112);
            this.User_request_List.TabIndex = 7;
            // 
            // User_request_list_Label
            // 
            this.User_request_list_Label.AutoSize = true;
            this.User_request_list_Label.Location = new System.Drawing.Point(308, 27);
            this.User_request_list_Label.Name = "User_request_list_Label";
            this.User_request_list_Label.Size = new System.Drawing.Size(109, 12);
            this.User_request_list_Label.TabIndex = 8;
            this.User_request_list_Label.Text = "사용자 요청 리스트";
            // 
            // User_request_Contents
            // 
            this.User_request_Contents.Location = new System.Drawing.Point(310, 181);
            this.User_request_Contents.Name = "User_request_Contents";
            this.User_request_Contents.Size = new System.Drawing.Size(429, 74);
            this.User_request_Contents.TabIndex = 9;
            this.User_request_Contents.Text = "";
            // 
            // User_request_Contents_Label
            // 
            this.User_request_Contents_Label.AutoSize = true;
            this.User_request_Contents_Label.Location = new System.Drawing.Point(308, 166);
            this.User_request_Contents_Label.Name = "User_request_Contents_Label";
            this.User_request_Contents_Label.Size = new System.Drawing.Size(97, 12);
            this.User_request_Contents_Label.TabIndex = 10;
            this.User_request_Contents_Label.Text = "사용자 요청 내용";
            // 
            // Find_FilePath_Button
            // 
            this.Find_FilePath_Button.Location = new System.Drawing.Point(247, 391);
            this.Find_FilePath_Button.Name = "Find_FilePath_Button";
            this.Find_FilePath_Button.Size = new System.Drawing.Size(32, 23);
            this.Find_FilePath_Button.TabIndex = 11;
            this.Find_FilePath_Button.Text = "...";
            this.Find_FilePath_Button.UseVisualStyleBackColor = true;
            this.Find_FilePath_Button.Click += new System.EventHandler(this.Find_FilePath_Button_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(310, 297);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 74);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // Admin_response_Contents
            // 
            this.Admin_response_Contents.AutoSize = true;
            this.Admin_response_Contents.Location = new System.Drawing.Point(308, 282);
            this.Admin_response_Contents.Name = "Admin_response_Contents";
            this.Admin_response_Contents.Size = new System.Drawing.Size(137, 12);
            this.Admin_response_Contents.TabIndex = 13;
            this.Admin_response_Contents.Text = "관리자 응답 내용 작성란";
            // 
            // Send_Response_Contents
            // 
            this.Send_Response_Contents.Location = new System.Drawing.Point(636, 377);
            this.Send_Response_Contents.Name = "Send_Response_Contents";
            this.Send_Response_Contents.Size = new System.Drawing.Size(103, 29);
            this.Send_Response_Contents.TabIndex = 14;
            this.Send_Response_Contents.Text = "응답 내용 전송";
            this.Send_Response_Contents.UseVisualStyleBackColor = true;
            this.Send_Response_Contents.Click += new System.EventHandler(this.Send_Response_Contents_Click);
            // 
            // see_answered_request
            // 
            this.see_answered_request.AutoSize = true;
            this.see_answered_request.Location = new System.Drawing.Point(613, 26);
            this.see_answered_request.Name = "see_answered_request";
            this.see_answered_request.Size = new System.Drawing.Size(128, 16);
            this.see_answered_request.TabIndex = 15;
            this.see_answered_request.Text = "답변된 요청도 보기";
            this.see_answered_request.UseVisualStyleBackColor = true;
            // 
            // FTP_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 459);
            this.Controls.Add(this.see_answered_request);
            this.Controls.Add(this.Send_Response_Contents);
            this.Controls.Add(this.Admin_response_Contents);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Find_FilePath_Button);
            this.Controls.Add(this.User_request_Contents_Label);
            this.Controls.Add(this.User_request_Contents);
            this.Controls.Add(this.User_request_list_Label);
            this.Controls.Add(this.User_request_List);
            this.Controls.Add(this.File_Upload_Button);
            this.Controls.Add(this.File_Delete_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Server_statement);
            this.Controls.Add(this.File_list_label);
            this.Controls.Add(this.File_List);
            this.Controls.Add(this.textBox1);
            this.Name = "FTP_Management";
            this.Text = "FTP서버 관리앱";
            this.Load += new System.EventHandler(this.Form_Loading);
            ((System.ComponentModel.ISupportInitialize)(this.File_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_request_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView File_List;
        private System.Windows.Forms.Label File_list_label;
        private System.Windows.Forms.Label Server_statement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button File_Delete_Button;
        private System.Windows.Forms.Button File_Upload_Button;
        private System.Windows.Forms.DataGridView User_request_List;
        private System.Windows.Forms.Label User_request_list_Label;
        private System.Windows.Forms.RichTextBox User_request_Contents;
        private System.Windows.Forms.Label User_request_Contents_Label;
        private System.Windows.Forms.Button Find_FilePath_Button;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label Admin_response_Contents;
        private System.Windows.Forms.Button Send_Response_Contents;
        private System.Windows.Forms.CheckBox see_answered_request;
    }
}

