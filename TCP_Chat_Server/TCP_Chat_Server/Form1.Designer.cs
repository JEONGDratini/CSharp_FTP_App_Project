namespace TCP_Chat_Server
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
            this.QuestionGridView = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Open_Server_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.See_Answered_Question = new System.Windows.Forms.CheckBox();
            this.RefreshGridView_Button = new System.Windows.Forms.Button();
            this.ResponseContents = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Send_Response = new System.Windows.Forms.Button();
            this.ShowQuestionContents = new System.Windows.Forms.RichTextBox();
            this.SeeQuestionContent = new System.Windows.Forms.Label();
            this.QuestionTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionGridView
            // 
            this.QuestionGridView.AllowUserToAddRows = false;
            this.QuestionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuestionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.check});
            this.QuestionGridView.Location = new System.Drawing.Point(131, 42);
            this.QuestionGridView.Name = "QuestionGridView";
            this.QuestionGridView.RowTemplate.Height = 23;
            this.QuestionGridView.Size = new System.Drawing.Size(494, 150);
            this.QuestionGridView.TabIndex = 0;
            this.QuestionGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.QuestionGridView_CellClick);
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.HeaderText = "파일이름";
            this.FileName.Name = "FileName";
            // 
            // check
            // 
            this.check.HeaderText = "응답여부";
            this.check.Name = "check";
            this.check.Width = 80;
            // 
            // Open_Server_Button
            // 
            this.Open_Server_Button.Location = new System.Drawing.Point(25, 42);
            this.Open_Server_Button.Name = "Open_Server_Button";
            this.Open_Server_Button.Size = new System.Drawing.Size(78, 30);
            this.Open_Server_Button.TabIndex = 1;
            this.Open_Server_Button.Text = "서버열기";
            this.Open_Server_Button.UseVisualStyleBackColor = true;
            this.Open_Server_Button.Click += new System.EventHandler(this.Open_Server_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "들어온 질의 목록";
            // 
            // See_Answered_Question
            // 
            this.See_Answered_Question.AutoSize = true;
            this.See_Answered_Question.Location = new System.Drawing.Point(432, 25);
            this.See_Answered_Question.Name = "See_Answered_Question";
            this.See_Answered_Question.Size = new System.Drawing.Size(120, 16);
            this.See_Answered_Question.TabIndex = 3;
            this.See_Answered_Question.Text = "응답 한 것도 보기";
            this.See_Answered_Question.UseVisualStyleBackColor = true;
            this.See_Answered_Question.CheckedChanged += new System.EventHandler(this.See_Answered_Question_Changed);
            // 
            // RefreshGridView_Button
            // 
            this.RefreshGridView_Button.Location = new System.Drawing.Point(558, 19);
            this.RefreshGridView_Button.Name = "RefreshGridView_Button";
            this.RefreshGridView_Button.Size = new System.Drawing.Size(67, 22);
            this.RefreshGridView_Button.TabIndex = 4;
            this.RefreshGridView_Button.Text = "새로고침";
            this.RefreshGridView_Button.UseVisualStyleBackColor = true;
            this.RefreshGridView_Button.Click += new System.EventHandler(this.RefreshGridView_Button_Click);
            // 
            // ResponseContents
            // 
            this.ResponseContents.Location = new System.Drawing.Point(329, 231);
            this.ResponseContents.Name = "ResponseContents";
            this.ResponseContents.Size = new System.Drawing.Size(223, 96);
            this.ResponseContents.TabIndex = 5;
            this.ResponseContents.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "응답내용(이미 응답된 문의라면 응답내용 출력)";
            // 
            // Send_Response
            // 
            this.Send_Response.Location = new System.Drawing.Point(558, 304);
            this.Send_Response.Name = "Send_Response";
            this.Send_Response.Size = new System.Drawing.Size(75, 23);
            this.Send_Response.TabIndex = 7;
            this.Send_Response.Text = "전송";
            this.Send_Response.UseVisualStyleBackColor = true;
            this.Send_Response.Click += new System.EventHandler(this.Send_Response_Click);
            // 
            // ShowQuestionContents
            // 
            this.ShowQuestionContents.Location = new System.Drawing.Point(63, 231);
            this.ShowQuestionContents.Name = "ShowQuestionContents";
            this.ShowQuestionContents.ReadOnly = true;
            this.ShowQuestionContents.Size = new System.Drawing.Size(223, 96);
            this.ShowQuestionContents.TabIndex = 8;
            this.ShowQuestionContents.Text = "";
            // 
            // SeeQuestionContent
            // 
            this.SeeQuestionContent.AutoSize = true;
            this.SeeQuestionContent.Location = new System.Drawing.Point(61, 216);
            this.SeeQuestionContent.Name = "SeeQuestionContent";
            this.SeeQuestionContent.Size = new System.Drawing.Size(121, 12);
            this.SeeQuestionContent.TabIndex = 9;
            this.SeeQuestionContent.Text = "문의내용보기. 제목 : ";
            // 
            // QuestionTitle
            // 
            this.QuestionTitle.AutoSize = true;
            this.QuestionTitle.Location = new System.Drawing.Point(179, 216);
            this.QuestionTitle.Name = "QuestionTitle";
            this.QuestionTitle.Size = new System.Drawing.Size(59, 12);
            this.QuestionTitle.TabIndex = 10;
            this.QuestionTitle.Text = "FileName";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 339);
            this.Controls.Add(this.QuestionTitle);
            this.Controls.Add(this.SeeQuestionContent);
            this.Controls.Add(this.ShowQuestionContents);
            this.Controls.Add(this.Send_Response);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ResponseContents);
            this.Controls.Add(this.RefreshGridView_Button);
            this.Controls.Add(this.See_Answered_Question);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Open_Server_Button);
            this.Controls.Add(this.QuestionGridView);
            this.Name = "Form1";
            this.Text = "응답 서버";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView QuestionGridView;
        private System.Windows.Forms.Button Open_Server_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox See_Answered_Question;
        private System.Windows.Forms.Button RefreshGridView_Button;
        private System.Windows.Forms.RichTextBox ResponseContents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Send_Response;
        private System.Windows.Forms.RichTextBox ShowQuestionContents;
        private System.Windows.Forms.Label SeeQuestionContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn check;
        private System.Windows.Forms.Label QuestionTitle;
    }
}

