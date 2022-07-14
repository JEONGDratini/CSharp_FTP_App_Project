namespace FTP_Client_App
{
    partial class FTP_Client
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
            this.File_Delete_Button = new System.Windows.Forms.Button();
            this.File_list_label = new System.Windows.Forms.Label();
            this.File_List = new System.Windows.Forms.DataGridView();
            this.User_request_list_Label = new System.Windows.Forms.Label();
            this.User_request_List = new System.Windows.Forms.DataGridView();
            this.User_request_Contents_Label = new System.Windows.Forms.Label();
            this.User_request_Contents = new System.Windows.Forms.RichTextBox();
            this.Send_Response_Contents = new System.Windows.Forms.Button();
            this.request_Title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Server_statement = new System.Windows.Forms.Label();
            this.Find_FilePath_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DownLoad_Dir_Path = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Response_Contents = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.File_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_request_List)).BeginInit();
            this.SuspendLayout();
            // 
            // File_Delete_Button
            // 
            this.File_Delete_Button.Location = new System.Drawing.Point(12, 383);
            this.File_Delete_Button.Name = "File_Delete_Button";
            this.File_Delete_Button.Size = new System.Drawing.Size(121, 33);
            this.File_Delete_Button.TabIndex = 8;
            this.File_Delete_Button.Text = "선택파일 다운로드";
            this.File_Delete_Button.UseVisualStyleBackColor = true;
            // 
            // File_list_label
            // 
            this.File_list_label.AutoSize = true;
            this.File_list_label.Location = new System.Drawing.Point(10, 20);
            this.File_list_label.Name = "File_list_label";
            this.File_list_label.Size = new System.Drawing.Size(69, 12);
            this.File_list_label.TabIndex = 7;
            this.File_list_label.Text = "파일 리스트";
            // 
            // File_List
            // 
            this.File_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.File_List.Location = new System.Drawing.Point(12, 35);
            this.File_List.Name = "File_List";
            this.File_List.RowTemplate.Height = 23;
            this.File_List.Size = new System.Drawing.Size(267, 293);
            this.File_List.TabIndex = 6;
            // 
            // User_request_list_Label
            // 
            this.User_request_list_Label.AutoSize = true;
            this.User_request_list_Label.Location = new System.Drawing.Point(308, 20);
            this.User_request_list_Label.Name = "User_request_list_Label";
            this.User_request_list_Label.Size = new System.Drawing.Size(85, 12);
            this.User_request_list_Label.TabIndex = 17;
            this.User_request_list_Label.Text = "내 요청 리스트";
            // 
            // User_request_List
            // 
            this.User_request_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_request_List.Location = new System.Drawing.Point(310, 35);
            this.User_request_List.Name = "User_request_List";
            this.User_request_List.RowTemplate.Height = 23;
            this.User_request_List.Size = new System.Drawing.Size(375, 112);
            this.User_request_List.TabIndex = 16;
            // 
            // User_request_Contents_Label
            // 
            this.User_request_Contents_Label.AutoSize = true;
            this.User_request_Contents_Label.Location = new System.Drawing.Point(308, 214);
            this.User_request_Contents_Label.Name = "User_request_Contents_Label";
            this.User_request_Contents_Label.Size = new System.Drawing.Size(57, 12);
            this.User_request_Contents_Label.TabIndex = 20;
            this.User_request_Contents_Label.Text = "요청 내용";
            // 
            // User_request_Contents
            // 
            this.User_request_Contents.Location = new System.Drawing.Point(310, 229);
            this.User_request_Contents.Name = "User_request_Contents";
            this.User_request_Contents.Size = new System.Drawing.Size(375, 74);
            this.User_request_Contents.TabIndex = 19;
            this.User_request_Contents.Text = "";
            // 
            // Send_Response_Contents
            // 
            this.Send_Response_Contents.Location = new System.Drawing.Point(582, 309);
            this.Send_Response_Contents.Name = "Send_Response_Contents";
            this.Send_Response_Contents.Size = new System.Drawing.Size(103, 29);
            this.Send_Response_Contents.TabIndex = 21;
            this.Send_Response_Contents.Text = "요청 내용 전송";
            this.Send_Response_Contents.UseVisualStyleBackColor = true;
            // 
            // request_Title
            // 
            this.request_Title.Location = new System.Drawing.Point(310, 190);
            this.request_Title.Name = "request_Title";
            this.request_Title.Size = new System.Drawing.Size(229, 21);
            this.request_Title.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "요청 제목";
            // 
            // Server_statement
            // 
            this.Server_statement.AutoSize = true;
            this.Server_statement.Location = new System.Drawing.Point(586, 433);
            this.Server_statement.Name = "Server_statement";
            this.Server_statement.Size = new System.Drawing.Size(105, 12);
            this.Server_statement.TabIndex = 24;
            this.Server_statement.Text = "서버 상태 : 미확인";
            // 
            // Find_FilePath_Button
            // 
            this.Find_FilePath_Button.Location = new System.Drawing.Point(247, 356);
            this.Find_FilePath_Button.Name = "Find_FilePath_Button";
            this.Find_FilePath_Button.Size = new System.Drawing.Size(32, 23);
            this.Find_FilePath_Button.TabIndex = 27;
            this.Find_FilePath_Button.Text = "...";
            this.Find_FilePath_Button.UseVisualStyleBackColor = true;
            this.Find_FilePath_Button.Click += new System.EventHandler(this.Find_FilePath_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "파일 저장할 폴더경로";
            // 
            // DownLoad_Dir_Path
            // 
            this.DownLoad_Dir_Path.Location = new System.Drawing.Point(12, 356);
            this.DownLoad_Dir_Path.Name = "DownLoad_Dir_Path";
            this.DownLoad_Dir_Path.Size = new System.Drawing.Size(229, 21);
            this.DownLoad_Dir_Path.TabIndex = 25;
            // 
            // Response_Contents
            // 
            this.Response_Contents.Location = new System.Drawing.Point(310, 344);
            this.Response_Contents.Name = "Response_Contents";
            this.Response_Contents.Size = new System.Drawing.Size(375, 74);
            this.Response_Contents.TabIndex = 28;
            this.Response_Contents.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "응답 내용";
            // 
            // FTP_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 454);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Response_Contents);
            this.Controls.Add(this.Find_FilePath_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DownLoad_Dir_Path);
            this.Controls.Add(this.Server_statement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.request_Title);
            this.Controls.Add(this.Send_Response_Contents);
            this.Controls.Add(this.User_request_Contents_Label);
            this.Controls.Add(this.User_request_Contents);
            this.Controls.Add(this.User_request_list_Label);
            this.Controls.Add(this.User_request_List);
            this.Controls.Add(this.File_Delete_Button);
            this.Controls.Add(this.File_list_label);
            this.Controls.Add(this.File_List);
            this.Name = "FTP_Client";
            this.Text = "FTP 유저앱";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.File_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_request_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button File_Delete_Button;
        private System.Windows.Forms.Label File_list_label;
        private System.Windows.Forms.DataGridView File_List;
        private System.Windows.Forms.Label User_request_list_Label;
        private System.Windows.Forms.DataGridView User_request_List;
        private System.Windows.Forms.Label User_request_Contents_Label;
        private System.Windows.Forms.RichTextBox User_request_Contents;
        private System.Windows.Forms.Button Send_Response_Contents;
        private System.Windows.Forms.TextBox request_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Server_statement;
        private System.Windows.Forms.Button Find_FilePath_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DownLoad_Dir_Path;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox Response_Contents;
        private System.Windows.Forms.Label label3;
    }
}

