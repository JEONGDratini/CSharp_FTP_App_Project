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

namespace TCP_Chat_Client
{
    public partial class Form1 : Form
    {
        private string FolderPath = ".\\Files";
        DirectoryInfo Dirinfo;

        private Thread th;

        private int BtnColumnIndex;//버튼 컬럼 인덱스
        Socket socket;//소켓객체

        DataGridViewButtonColumn Response_Openbtn = new DataGridViewButtonColumn();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnColumnIndex = ResponseGridView.Columns.Add(Response_Openbtn);//데이터 그리드 뷰에 버튼 열을 추가한다.
            Response_Openbtn.HeaderText = "보기";
            Response_Openbtn.Name = "Response_Openbtn";
            Response_Openbtn.Width = 70;

            Send_Question.Enabled = false;
            UpdateResponseGridView();
        }

        private void Connection_Button_Click(object sender, EventArgs e)
        {
            if (Connection_Button.Text.Equals("연결"))
            {
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//소켓객체 선언한다. 주소값은 ipv4인터넷 주소를 사용, 스트림형식으로 통신하면서 tcp프로토콜을 사용한다.

                    var EndPt = new IPEndPoint(IPAddress.Parse(IP_Address_Input.Text), int.Parse(Port.Text));

                    socket.Connect(EndPt);//설정해둔 소켓통신 목적지를 설정하고 연결한다.
                    MessageBox.Show("연결에 성공했습니다.", "안내");
                    Send_Question.Enabled = true;
                }
                catch
                {
                    socket = null;
                    MessageBox.Show("연결에 실패했습니다.", "안내");
                }
            }
        
        }

        private void Send_Question_Click(object sender, EventArgs e)
        {
            string Question_title = Question_Title.Text;
            string Question_Contents = QuestionTextBox.Text;

            byte[] buff_title = Encoding.UTF8.GetBytes(Question_title);
            byte[] buff_Contents = Encoding.UTF8.GetBytes(Question_Contents);




        }

        private void ResponseGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateResponseGridView()
        {
            
            ResponseGridView.Rows.Clear();
            if (Directory.Exists(FolderPath))
            {

                foreach (var file in Dirinfo.GetFiles())
                {
                    string is_answered = file.Name.Substring(0, 1);//파일 이름 첫글자가 t이면 답변된거고 f이면 답변 안된거임.
                    string Question_title = file.Name.Substring(1);
                    if (is_answered.Equals("f"))
                        ResponseGridView.Rows.Add(Question_title, "응답안됨");
                    else if (is_answered.Equals("t"))
                        ResponseGridView.Rows.Add(Question_title, "응답됨");
                }
                //생성된 각 행마다 버튼 추가하기
                foreach (DataGridViewRow row in ResponseGridView.Rows)
                {
                    row.Cells[BtnColumnIndex].Value = "열기";
                }
            }
        }
    }
}
