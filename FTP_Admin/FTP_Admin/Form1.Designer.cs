namespace FTP_FTP_Admin
{
    partial class Form1
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
            this.IP_Address_Input = new System.Windows.Forms.TextBox();
            this.IP_Addr = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Account_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Connection_Button = new System.Windows.Forms.Button();
            this.File_InFo_GridView = new System.Windows.Forms.DataGridView();
            this.File_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Download_Dir_Path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Get_Dir_Path = new System.Windows.Forms.Button();
            this.Server_statement = new System.Windows.Forms.Label();
            this.FTP_Client_folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.Upload_FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Find_FilePath_Button = new System.Windows.Forms.Button();
            this.File_Upload_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Upload_FilePath = new System.Windows.Forms.TextBox();
            this.Remember_Addr = new System.Windows.Forms.CheckBox();
            this.Remember_ID_PW = new System.Windows.Forms.CheckBox();
            this.Working_State = new System.Windows.Forms.Label();
            this.Current_Path = new System.Windows.Forms.Label();
            this.Back_Dir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.NewFolder_Button = new System.Windows.Forms.Button();
            this.LogFilesGridView = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.Log_Content_Box = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OpenLogFileButton = new System.Windows.Forms.Button();
            this.ReFresh_Log = new System.Windows.Forms.Button();
            this.LogFile_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log_Name_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.File_InFo_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogFilesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // IP_Address_Input
            // 
            this.IP_Address_Input.Location = new System.Drawing.Point(12, 31);
            this.IP_Address_Input.Name = "IP_Address_Input";
            this.IP_Address_Input.Size = new System.Drawing.Size(115, 21);
            this.IP_Address_Input.TabIndex = 0;
            // 
            // IP_Addr
            // 
            this.IP_Addr.AutoSize = true;
            this.IP_Addr.Location = new System.Drawing.Point(12, 16);
            this.IP_Addr.Name = "IP_Addr";
            this.IP_Addr.Size = new System.Drawing.Size(84, 12);
            this.IP_Addr.TabIndex = 1;
            this.IP_Addr.Text = "접속할 IP 주소";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(133, 31);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(53, 21);
            this.Port.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "포트";
            // 
            // Account_ID
            // 
            this.Account_ID.Location = new System.Drawing.Point(16, 94);
            this.Account_ID.Name = "Account_ID";
            this.Account_ID.Size = new System.Drawing.Size(82, 21);
            this.Account_ID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "비밀번호";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(104, 94);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(82, 21);
            this.Password.TabIndex = 6;
            // 
            // Connection_Button
            // 
            this.Connection_Button.Location = new System.Drawing.Point(16, 186);
            this.Connection_Button.Name = "Connection_Button";
            this.Connection_Button.Size = new System.Drawing.Size(79, 28);
            this.Connection_Button.TabIndex = 8;
            this.Connection_Button.Text = "연결";
            this.Connection_Button.UseVisualStyleBackColor = true;
            this.Connection_Button.Click += new System.EventHandler(this.Connection_Button_Click);
            // 
            // File_InFo_GridView
            // 
            this.File_InFo_GridView.AllowUserToAddRows = false;
            this.File_InFo_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.File_InFo_GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File_name,
            this.Capacity});
            this.File_InFo_GridView.Location = new System.Drawing.Point(269, 31);
            this.File_InFo_GridView.Name = "File_InFo_GridView";
            this.File_InFo_GridView.RowTemplate.Height = 23;
            this.File_InFo_GridView.Size = new System.Drawing.Size(633, 204);
            this.File_InFo_GridView.TabIndex = 9;
            this.File_InFo_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.File_InFo_GridView_CellClick);
            // 
            // File_name
            // 
            this.File_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.File_name.HeaderText = "파일, 폴더이름";
            this.File_name.Name = "File_name";
            // 
            // Capacity
            // 
            this.Capacity.HeaderText = "용량";
            this.Capacity.Name = "Capacity";
            this.Capacity.Width = 80;
            // 
            // Download_Dir_Path
            // 
            this.Download_Dir_Path.Location = new System.Drawing.Point(16, 159);
            this.Download_Dir_Path.Name = "Download_Dir_Path";
            this.Download_Dir_Path.Size = new System.Drawing.Size(170, 21);
            this.Download_Dir_Path.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "다운로드 위치";
            // 
            // Get_Dir_Path
            // 
            this.Get_Dir_Path.Location = new System.Drawing.Point(192, 159);
            this.Get_Dir_Path.Name = "Get_Dir_Path";
            this.Get_Dir_Path.Size = new System.Drawing.Size(27, 22);
            this.Get_Dir_Path.TabIndex = 12;
            this.Get_Dir_Path.Text = "....";
            this.Get_Dir_Path.UseVisualStyleBackColor = true;
            this.Get_Dir_Path.Click += new System.EventHandler(this.Get_Dir_Path_Click);
            // 
            // Server_statement
            // 
            this.Server_statement.AutoSize = true;
            this.Server_statement.Location = new System.Drawing.Point(102, 194);
            this.Server_statement.Name = "Server_statement";
            this.Server_statement.Size = new System.Drawing.Size(117, 12);
            this.Server_statement.TabIndex = 13;
            this.Server_statement.Text = "연결 상태 : 연결안됨";
            // 
            // Upload_FileDialog
            // 
            this.Upload_FileDialog.FileName = "openFileDialog1";
            // 
            // Find_FilePath_Button
            // 
            this.Find_FilePath_Button.Location = new System.Drawing.Point(870, 282);
            this.Find_FilePath_Button.Name = "Find_FilePath_Button";
            this.Find_FilePath_Button.Size = new System.Drawing.Size(32, 23);
            this.Find_FilePath_Button.TabIndex = 17;
            this.Find_FilePath_Button.Text = "...";
            this.Find_FilePath_Button.UseVisualStyleBackColor = true;
            this.Find_FilePath_Button.Click += new System.EventHandler(this.Find_FilePath_Button_Click);
            // 
            // File_Upload_Button
            // 
            this.File_Upload_Button.Location = new System.Drawing.Point(269, 311);
            this.File_Upload_Button.Name = "File_Upload_Button";
            this.File_Upload_Button.Size = new System.Drawing.Size(142, 23);
            this.File_Upload_Button.TabIndex = 16;
            this.File_Upload_Button.Text = "현재경로에 파일 업로드";
            this.File_Upload_Button.UseVisualStyleBackColor = true;
            this.File_Upload_Button.Click += new System.EventHandler(this.File_Upload_Button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "내 컴퓨터의 업로드할 파일경로(클라우드의 현재경로로 파일 추가됨)";
            // 
            // Upload_FilePath
            // 
            this.Upload_FilePath.Location = new System.Drawing.Point(269, 284);
            this.Upload_FilePath.Name = "Upload_FilePath";
            this.Upload_FilePath.Size = new System.Drawing.Size(595, 21);
            this.Upload_FilePath.TabIndex = 14;
            // 
            // Remember_Addr
            // 
            this.Remember_Addr.AutoSize = true;
            this.Remember_Addr.Location = new System.Drawing.Point(16, 58);
            this.Remember_Addr.Name = "Remember_Addr";
            this.Remember_Addr.Size = new System.Drawing.Size(116, 16);
            this.Remember_Addr.TabIndex = 18;
            this.Remember_Addr.Text = "이 주소 기억하기";
            this.Remember_Addr.UseVisualStyleBackColor = true;
            // 
            // Remember_ID_PW
            // 
            this.Remember_ID_PW.AutoSize = true;
            this.Remember_ID_PW.Location = new System.Drawing.Point(16, 121);
            this.Remember_ID_PW.Name = "Remember_ID_PW";
            this.Remember_ID_PW.Size = new System.Drawing.Size(113, 16);
            this.Remember_ID_PW.TabIndex = 19;
            this.Remember_ID_PW.Text = "ID, PW 기억하기";
            this.Remember_ID_PW.UseVisualStyleBackColor = true;
            // 
            // Working_State
            // 
            this.Working_State.AutoSize = true;
            this.Working_State.Location = new System.Drawing.Point(417, 316);
            this.Working_State.Name = "Working_State";
            this.Working_State.Size = new System.Drawing.Size(117, 12);
            this.Working_State.TabIndex = 21;
            this.Working_State.Text = "작업 상태 : 작업안함";
            // 
            // Current_Path
            // 
            this.Current_Path.AutoSize = true;
            this.Current_Path.Location = new System.Drawing.Point(334, 16);
            this.Current_Path.Name = "Current_Path";
            this.Current_Path.Size = new System.Drawing.Size(77, 12);
            this.Current_Path.TabIndex = 22;
            this.Current_Path.Text = "확인되지않음";
            // 
            // Back_Dir
            // 
            this.Back_Dir.Location = new System.Drawing.Point(796, 241);
            this.Back_Dir.Name = "Back_Dir";
            this.Back_Dir.Size = new System.Drawing.Size(106, 23);
            this.Back_Dir.TabIndex = 23;
            this.Back_Dir.Text = "이전 폴더로 가기";
            this.Back_Dir.UseVisualStyleBackColor = true;
            this.Back_Dir.Click += new System.EventHandler(this.Back_Dir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "현재경로 :";
            // 
            // NewFolder_Button
            // 
            this.NewFolder_Button.Location = new System.Drawing.Point(729, 241);
            this.NewFolder_Button.Name = "NewFolder_Button";
            this.NewFolder_Button.Size = new System.Drawing.Size(61, 23);
            this.NewFolder_Button.TabIndex = 25;
            this.NewFolder_Button.Text = "새폴더";
            this.NewFolder_Button.UseVisualStyleBackColor = true;
            this.NewFolder_Button.Click += new System.EventHandler(this.NewFolder_Button_Click);
            // 
            // LogFilesGridView
            // 
            this.LogFilesGridView.AllowUserToAddRows = false;
            this.LogFilesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogFilesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogFile_Name});
            this.LogFilesGridView.Location = new System.Drawing.Point(12, 377);
            this.LogFilesGridView.Name = "LogFilesGridView";
            this.LogFilesGridView.RowHeadersVisible = false;
            this.LogFilesGridView.RowTemplate.Height = 23;
            this.LogFilesGridView.Size = new System.Drawing.Size(257, 183);
            this.LogFilesGridView.TabIndex = 26;
            this.LogFilesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogFilesGridView_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "서버 로그조회";
            // 
            // Log_Content_Box
            // 
            this.Log_Content_Box.Location = new System.Drawing.Point(275, 377);
            this.Log_Content_Box.Name = "Log_Content_Box";
            this.Log_Content_Box.Size = new System.Drawing.Size(556, 183);
            this.Log_Content_Box.TabIndex = 28;
            this.Log_Content_Box.Text = "";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(12, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(888, 2);
            this.label8.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "현재 조회 중인 로그 : ";
            // 
            // OpenLogFileButton
            // 
            this.OpenLogFileButton.Location = new System.Drawing.Point(841, 507);
            this.OpenLogFileButton.Name = "OpenLogFileButton";
            this.OpenLogFileButton.Size = new System.Drawing.Size(61, 23);
            this.OpenLogFileButton.TabIndex = 31;
            this.OpenLogFileButton.Text = "파일열기";
            this.OpenLogFileButton.UseVisualStyleBackColor = true;
            this.OpenLogFileButton.Click += new System.EventHandler(this.OpenLogFileButton_Click);
            // 
            // ReFresh_Log
            // 
            this.ReFresh_Log.Location = new System.Drawing.Point(841, 536);
            this.ReFresh_Log.Name = "ReFresh_Log";
            this.ReFresh_Log.Size = new System.Drawing.Size(61, 23);
            this.ReFresh_Log.TabIndex = 32;
            this.ReFresh_Log.Text = "새로고침";
            this.ReFresh_Log.UseVisualStyleBackColor = true;
            this.ReFresh_Log.Click += new System.EventHandler(this.ReFresh_Log_Click);
            // 
            // LogFile_Name
            // 
            this.LogFile_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LogFile_Name.HeaderText = "사용자ip";
            this.LogFile_Name.Name = "LogFile_Name";
            // 
            // Log_Name_Label
            // 
            this.Log_Name_Label.AutoSize = true;
            this.Log_Name_Label.Location = new System.Drawing.Point(392, 362);
            this.Log_Name_Label.Name = "Log_Name_Label";
            this.Log_Name_Label.Size = new System.Drawing.Size(53, 12);
            this.Log_Name_Label.TabIndex = 33;
            this.Log_Name_Label.Text = "조회안함";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 572);
            this.Controls.Add(this.Log_Name_Label);
            this.Controls.Add(this.ReFresh_Log);
            this.Controls.Add(this.OpenLogFileButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Log_Content_Box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LogFilesGridView);
            this.Controls.Add(this.NewFolder_Button);
            this.Controls.Add(this.Back_Dir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Current_Path);
            this.Controls.Add(this.Working_State);
            this.Controls.Add(this.Remember_ID_PW);
            this.Controls.Add(this.Remember_Addr);
            this.Controls.Add(this.Find_FilePath_Button);
            this.Controls.Add(this.File_Upload_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Upload_FilePath);
            this.Controls.Add(this.Server_statement);
            this.Controls.Add(this.Get_Dir_Path);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Download_Dir_Path);
            this.Controls.Add(this.File_InFo_GridView);
            this.Controls.Add(this.Connection_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Account_ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IP_Addr);
            this.Controls.Add(this.IP_Address_Input);
            this.Name = "Form1";
            this.Text = "FTP 관리자 접속기";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.File_InFo_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogFilesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP_Address_Input;
        private System.Windows.Forms.Label IP_Addr;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Account_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button Connection_Button;
        private System.Windows.Forms.DataGridView File_InFo_GridView;
        private System.Windows.Forms.TextBox Download_Dir_Path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Get_Dir_Path;
        private System.Windows.Forms.Label Server_statement;
        private System.Windows.Forms.FolderBrowserDialog FTP_Client_folderBrowser;
        private System.Windows.Forms.OpenFileDialog Upload_FileDialog;
        private System.Windows.Forms.Button Find_FilePath_Button;
        private System.Windows.Forms.Button File_Upload_Button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Upload_FilePath;
        private System.Windows.Forms.CheckBox Remember_Addr;
        private System.Windows.Forms.CheckBox Remember_ID_PW;
        private System.Windows.Forms.Label Working_State;
        private System.Windows.Forms.Label Current_Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
        private System.Windows.Forms.Button Back_Dir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button NewFolder_Button;
        private System.Windows.Forms.DataGridView LogFilesGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox Log_Content_Box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button OpenLogFileButton;
        private System.Windows.Forms.Button ReFresh_Log;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogFile_Name;
        private System.Windows.Forms.Label Log_Name_Label;
    }
}

