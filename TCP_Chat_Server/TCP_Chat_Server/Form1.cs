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
        //tcp통신에 필요한 변수, 객체 선언
        public string bufferedList;
        public List<string> users = new List<string>();
        TcpListener server = null;
        TcpClient client = null;
        int client_Counter = 0;

        //각 문의, 응답파일들을 넣어놓을 폴더의 경로
        private string FolderPath = ".\\Files";
        DirectoryInfo Dirinfo;


        
        private int BtnColumnIndex;//버튼 컬럼 인덱스
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
            ResponseContents.ReadOnly = true;

            UpdateQuestionGridView();
        }

        private void QuestionGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BtnColumnIndex)//클릭된 셀의 인덱스가 버튼 컬럼인덱스와 같으면 실행한다.
            {
                //클릭된 행에서 파일이름 가져오기, 용량에서 폴더인지 아닌지 여부 가져오기
                string FileName = QuestionGridView.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
                bool Is_Answered = QuestionGridView.Rows[e.RowIndex].Cells["check"].Value.ToString().Equals("응답됨");
                QuestionTitle.Text = FileName;
                

                if (Is_Answered)
                { //응답된 문의라면 응답파일열어서 해당 내용을 ResponseContents 텍스트박스에 띄우고 전송버튼 활성화X
                    string QuestionFilePath = FolderPath + "\\t" + FileName;
                    string AnswerFilePath = FolderPath + "\\a" + FileName;
                    FileStream QuestionfileStream = new FileStream(QuestionFilePath, FileMode.Open, FileAccess.Read);
                    FileStream AnswerfileStream = new FileStream(AnswerFilePath, FileMode.Open, FileAccess.Read);

                    StreamReader QuestionSReader = new StreamReader(QuestionfileStream, System.Text.Encoding.UTF8);
                    StreamReader AnswerSReader = new StreamReader(AnswerfileStream, System.Text.Encoding.UTF8);

                    ShowQuestionContents.Text = QuestionSReader.ReadToEnd();
                    ResponseContents.Text = AnswerSReader.ReadToEnd();

                    QuestionSReader.Close();
                    QuestionfileStream.Close();
                    AnswerSReader.Close();
                    AnswerfileStream.Close();

                }
                else {
                    string QuestionFilePath = FolderPath + "\\f" + FileName;
                    FileStream QuestionfileStream = new FileStream(QuestionFilePath, FileMode.Open, FileAccess.Read);

                    StreamReader QuestionSReader = new StreamReader(QuestionfileStream, System.Text.Encoding.UTF8);

                    ShowQuestionContents.Text = QuestionSReader.ReadToEnd();
                    ResponseContents.ReadOnly = false;
                    ResponseContents.Text = "";
                    Send_Response.Enabled = true;

                    QuestionSReader.Close();
                    QuestionfileStream.Close();
                }

            }
        }

        private void Open_Server_Button_Click(object sender, EventArgs e)
        {

        }

        //해당 응답내용을 파일로 저장한 뒤에 전송한다. 하지만 보내야할 사용자가 현재 접속 중이 아니라면, 일단 답변파일만 생성해놓고 다음에 사용자가 접속할 때 새로 받을 응답이 있는지 check한 뒤에 새로 받을 파일이 있으면 해당파일을 다운로드받는다.
        private void Send_Response_Click(object sender, EventArgs e)
        {
            string msgBx_Content;
            if (ResponseContents.Text.Length < 10)
                msgBx_Content = "응답내용이 적습니다. 이대로 전송하시겠습니까?";
            else
                msgBx_Content = "이대로 전송하시겠습니까?";

            DialogResult dr = MessageBox.Show(msgBx_Content, "전송 확인", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //파일 생성, 삭제
                string QuestionFilePath = FolderPath + "\\t" + QuestionTitle.Text;
                string AnswerFilePath = FolderPath + "\\a" + QuestionTitle.Text;
                FileStream QuestionfileStream = new FileStream(QuestionFilePath, FileMode.Create, FileAccess.Write);//새 질문파일 작성용
                StreamWriter QuestionSWriter = new StreamWriter(QuestionfileStream, System.Text.Encoding.UTF8);
                FileStream AnswerfileStream = new FileStream(AnswerFilePath, FileMode.Create, FileAccess.Write);//응답파일 작성용
                StreamWriter AnswerSWriter = new StreamWriter(AnswerfileStream, System.Text.Encoding.UTF8);

                QuestionSWriter.WriteLine(ShowQuestionContents.Text);
                QuestionSWriter.Flush();
                QuestionSWriter.Close();
                QuestionfileStream.Close();

                File.Delete(string.Format(FolderPath + "\\f" + QuestionTitle.Text));

                AnswerSWriter.WriteLine(ResponseContents.Text);
                AnswerSWriter.Flush();
                AnswerSWriter.Close();
                AnswerfileStream.Close();

                UpdateQuestionGridView();//데이터그리드뷰 갱신하기

                //tcp통신



            }
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
