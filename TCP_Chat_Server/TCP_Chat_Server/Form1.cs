using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace TCP_Chat_Server
{
    public partial class Form1 : Form
    {
        private Thread th;

        //각 문의, 응답파일들을 넣어놓을 폴더의 경로
        private string FolderPath = "C:\\Users\\user\\Desktop\\정민용\\C#\\CSharp_WinApp_Project\\TCP_Chat_Server\\TCP_Chat_Server\\bin\\Debug\\Files";
        DirectoryInfo Dirinfo;

        private int BtnColumnIndex;//버튼 컬럼 인덱스
        Socket socket;//소켓객체

        DataGridViewButtonColumn Response_Openbtn = new DataGridViewButtonColumn();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dirinfo = new DirectoryInfo(FolderPath);

            BtnColumnIndex = QuestionGridView.Columns.Add(Response_Openbtn);//데이터 그리드 뷰에 버튼 열을 추가한다.
            Response_Openbtn.HeaderText = "보기";
            Response_Openbtn.Name = "Response_Openbtn";
            Response_Openbtn.Width = 70;

            Send_Response.Enabled = false;

            UpdateQuestionGridView();
        }

        private void QuestionGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BtnColumnIndex)//클릭된 셀의 인덱스가 버튼 컬럼인덱스와 같으면 실행한다.
            {
                //클릭된 행에서 파일이름 가져오기, 용량에서 폴더인지 아닌지 여부 가져오기
                string FileName = QuestionGridView.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
                bool Is_Answered = QuestionGridView.Rows[e.RowIndex].Cells["check"].Value.ToString().Equals("응답됨");

                if (Is_Answered) { //응답된 문의라면 응답파일열어서 해당 내용을 ResponseContents 텍스트박스에 띄우고 전송버튼 활성화X
                    string QuestionFilePath = FolderPath + "\\t" + FileName;
                    string AnswerFilePath = FolderPath + "\\a" + FileName;
                    ShowQuestionContents.LoadFile(QuestionFilePath, RichTextBoxStreamType.RichText);
                    ResponseContents.LoadFile(AnswerFilePath, RichTextBoxStreamType.RichText);
                }


            }
        }

        private void Open_Server_Button_Click(object sender, EventArgs e)
        {

        }

        private void Send_Response_Click(object sender, EventArgs e)
        {

        }

        private void See_Answered_Question_Changed(object sender, EventArgs e)
        {
            UpdateQuestionGridView();
        }

        private void RefreshGridView_Button_Click(object sender, EventArgs e)
        {
            UpdateQuestionGridView();
        }

        private void UpdateQuestionGridView() {
            if (See_Answered_Question.Checked)
            {//응답된 것까지 본다고 하면
                QuestionGridView.Rows.Clear();
                if (Directory.Exists(FolderPath))
                {
                    
                    foreach (var file in Dirinfo.GetFiles())
                    {
                        string is_answered = file.Name.Substring(0, 1);//파일 이름 첫글자가 t이면 답변된거고 f이면 답변 안된거임.
                        string Question_title = file.Name.Substring(1);
                        if (is_answered.Equals("f"))
                            QuestionGridView.Rows.Add(Question_title, "응답안됨");
                        else if (is_answered.Equals("t"))
                            QuestionGridView.Rows.Add(Question_title, "응답됨");
                    }
                    //생성된 각 행마다 버튼 추가하기
                    foreach (DataGridViewRow row in QuestionGridView.Rows)
                    {
                        row.Cells[BtnColumnIndex].Value = "열기";
                    }
                }
            }
            else
            {//응답 안된 것반 볼 때.
                QuestionGridView.Rows.Clear();
                if (Directory.Exists(FolderPath))
                {
                    DirectoryInfo Dirinfo = new DirectoryInfo(FolderPath);
                    foreach (var file in Dirinfo.GetFiles())
                    {
                        string is_answered = file.Name.Substring(0, 1);//파일 이름 첫글자가 t이면 답변된거고 f이면 답변 안된거임.
                        string Question_title = file.Name.Substring(1);
                        if (is_answered.Equals("f"))
                            QuestionGridView.Rows.Add(Question_title, "응답안됨");

                    }
                    //생성된 각 행마다 버튼 추가하기
                    foreach (DataGridViewRow row in QuestionGridView.Rows)
                    {
                        row.Cells[BtnColumnIndex].Value = "열기";
                    }
                }
            }
        }


    }
}
