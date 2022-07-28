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

namespace TCP_Chat_Client
{
    public partial class Form1 : Form
    {

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

        }

        private void ResponseGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
