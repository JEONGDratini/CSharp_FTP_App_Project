namespace TCP_Chat_Client
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
            this.QuestionTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Send_Question = new System.Windows.Forms.Button();
            this.ResponseGridView = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.IP_Addr = new System.Windows.Forms.Label();
            this.IP_Address_Input = new System.Windows.Forms.TextBox();
            this.Server_statement = new System.Windows.Forms.Label();
            this.Connection_Button = new System.Windows.Forms.Button();
            this.Question_Title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Refresh_Mode_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Question_Mode_State = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ResponseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionTextBox
            // 
            this.QuestionTextBox.Location = new System.Drawing.Point(267, 74);
            this.QuestionTextBox.Name = "QuestionTextBox";
            this.QuestionTextBox.Size = new System.Drawing.Size(240, 96);
            this.QuestionTextBox.TabIndex = 0;
            this.QuestionTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "문의내용";
            // 
            // Send_Question
            // 
            this.Send_Question.Location = new System.Drawing.Point(432, 176);
            this.Send_Question.Name = "Send_Question";
            this.Send_Question.Size = new System.Drawing.Size(75, 23);
            this.Send_Question.TabIndex = 2;
            this.Send_Question.Text = "전송하기";
            this.Send_Question.UseVisualStyleBackColor = true;
            this.Send_Question.Click += new System.EventHandler(this.Send_Question_Click);
            // 
            // ResponseGridView
            // 
            this.ResponseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResponseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.check});
            this.ResponseGridView.Location = new System.Drawing.Point(12, 201);
            this.ResponseGridView.Name = "ResponseGridView";
            this.ResponseGridView.RowTemplate.Height = 23;
            this.ResponseGridView.Size = new System.Drawing.Size(334, 114);
            this.ResponseGridView.TabIndex = 3;
            this.ResponseGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResponseGridView_CellClick);
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.HeaderText = "파일이름";
            this.FileName.Name = "FileName";
            // 
            // check
            // 
            this.check.HeaderText = "읽음";
            this.check.Name = "check";
            this.check.Width = 60;
            // 
            // AnswerTextBox
            // 
            this.AnswerTextBox.Location = new System.Drawing.Point(354, 219);
            this.AnswerTextBox.Name = "AnswerTextBox";
            this.AnswerTextBox.ReadOnly = true;
            this.AnswerTextBox.Size = new System.Drawing.Size(153, 96);
            this.AnswerTextBox.TabIndex = 4;
            this.AnswerTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "응답내용";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "받은 응답 목록";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "포트";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(135, 52);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(53, 21);
            this.Port.TabIndex = 9;
            // 
            // IP_Addr
            // 
            this.IP_Addr.AutoSize = true;
            this.IP_Addr.Location = new System.Drawing.Point(14, 37);
            this.IP_Addr.Name = "IP_Addr";
            this.IP_Addr.Size = new System.Drawing.Size(84, 12);
            this.IP_Addr.TabIndex = 8;
            this.IP_Addr.Text = "접속할 IP 주소";
            // 
            // IP_Address_Input
            // 
            this.IP_Address_Input.Location = new System.Drawing.Point(14, 52);
            this.IP_Address_Input.Name = "IP_Address_Input";
            this.IP_Address_Input.Size = new System.Drawing.Size(115, 21);
            this.IP_Address_Input.TabIndex = 7;
            // 
            // Server_statement
            // 
            this.Server_statement.AutoSize = true;
            this.Server_statement.Location = new System.Drawing.Point(100, 87);
            this.Server_statement.Name = "Server_statement";
            this.Server_statement.Size = new System.Drawing.Size(117, 12);
            this.Server_statement.TabIndex = 15;
            this.Server_statement.Text = "연결 상태 : 연결안됨";
            // 
            // Connection_Button
            // 
            this.Connection_Button.Location = new System.Drawing.Point(14, 79);
            this.Connection_Button.Name = "Connection_Button";
            this.Connection_Button.Size = new System.Drawing.Size(79, 28);
            this.Connection_Button.TabIndex = 14;
            this.Connection_Button.Text = "연결";
            this.Connection_Button.UseVisualStyleBackColor = true;
            this.Connection_Button.Click += new System.EventHandler(this.Connection_Button_Click);
            // 
            // Question_Title
            // 
            this.Question_Title.Location = new System.Drawing.Point(267, 34);
            this.Question_Title.Name = "Question_Title";
            this.Question_Title.Size = new System.Drawing.Size(240, 21);
            this.Question_Title.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "문의제목";
            // 
            // Refresh_Mode_Button
            // 
            this.Refresh_Mode_Button.Location = new System.Drawing.Point(351, 176);
            this.Refresh_Mode_Button.Name = "Refresh_Mode_Button";
            this.Refresh_Mode_Button.Size = new System.Drawing.Size(75, 23);
            this.Refresh_Mode_Button.TabIndex = 18;
            this.Refresh_Mode_Button.Text = "모드변경";
            this.Refresh_Mode_Button.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "모드상태 : ";
            // 
            // Question_Mode_State
            // 
            this.Question_Mode_State.AutoSize = true;
            this.Question_Mode_State.Location = new System.Drawing.Point(442, 19);
            this.Question_Mode_State.Name = "Question_Mode_State";
            this.Question_Mode_State.Size = new System.Drawing.Size(29, 12);
            this.Question_Mode_State.TabIndex = 20;
            this.Question_Mode_State.Text = "쓰기";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 327);
            this.Controls.Add(this.Question_Mode_State);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Refresh_Mode_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Question_Title);
            this.Controls.Add(this.Server_statement);
            this.Controls.Add(this.Connection_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IP_Addr);
            this.Controls.Add(this.IP_Address_Input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AnswerTextBox);
            this.Controls.Add(this.ResponseGridView);
            this.Controls.Add(this.Send_Question);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuestionTextBox);
            this.Name = "Form1";
            this.Text = "질의 클라이언트";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResponseGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox QuestionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Send_Question;
        private System.Windows.Forms.DataGridView ResponseGridView;
        private System.Windows.Forms.RichTextBox AnswerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn check;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label IP_Addr;
        private System.Windows.Forms.TextBox IP_Address_Input;
        private System.Windows.Forms.Label Server_statement;
        private System.Windows.Forms.Button Connection_Button;
        private System.Windows.Forms.TextBox Question_Title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Refresh_Mode_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Question_Mode_State;
    }
}

