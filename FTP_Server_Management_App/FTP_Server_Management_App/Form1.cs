using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FTP_Server_Management_App
{
    public partial class FTP_Management : Form
    {
        List<string[]> File_Information = new List<string[]>();//FTP서버에서 가져온 File 정보 리스트
        List<string[]> Request_Information = new List<string[]>();//DB에서 가져온 요청 정보 리스트

        public FTP_Management()
        {
            InitializeComponent();
        }

        //로드되면 ftp서버에 연결하고 연결 상태를 갱신, 
        //ftp파일과 .txt파일들 목록을 각각 받아온 뒤에 해당 정보를 DataGridView에 출력한다.

        private void Form_Loading(object sender, EventArgs e)
        {
            File_List.Columns.Add("Colnum", "번호");
            File_List.Columns.Add("ColName", "파일명");

            User_request_List.Columns.Add("Colnum", "번호");
            User_request_List.Columns.Add("ColUser", "유저");
            User_request_List.Columns.Add("ColTitle", "제목");
            User_request_List.Columns.Add("ColAnswered", "답변여부");
            //ftp서버에 연결 시도하고 연결 상태를 갱신한다.
            //연결이 안되면 '연결 상태 : 연결안됨', 연결이 되면 '연결 상태 : 연결됨'.
            //연결되면 서버에 있는 DB에 user_request테이블에서 userid랑 is_answered 컬럼, title 컬럼, content컬럼의 정보를 뽑아온다.
            //그리고 그렇게 뽑아온 정보 중 title과 userid를 각각 제목과 유저 열에 집어넣는다.


        }

        private void File_Upload_Button_Click(object sender, EventArgs e)
        {

        }

        private void File_Delete_Button_Click(object sender, EventArgs e)
        {

        }

        //파일경로 입력란 옆에 ...버튼 누르면 파일 선택창 나오고 선택하면 해당파일의 경로가 textbox에 입력된다.
        private void Find_FilePath_Button_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog1.InitialDirectory = "C:\\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                filePath = openFileDialog1.FileName;
            }
            textBox1.Text = filePath;
        }


        //응답을 보내면, 메시지박스로 응답을 픽스할 것인지 물어본다.
        //픽스를 한다면 해당 응답 내용을 서버의 DB에서
        // 해당 유저 요청에 해당하는 응답 컬럼부분에 작성한 내용을 Update한다.
        private void Send_Response_Contents_Click(object sender, EventArgs e)
        {
            var Response_Contents = string.Empty;




        }

    }
}
