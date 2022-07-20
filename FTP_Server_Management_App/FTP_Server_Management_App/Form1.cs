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
        public FTP_Management()
        {
            InitializeComponent();
        }

        //로드되면 ftp서버에 연결하고 연결 상태를 갱신, 
        //ftp파일과 .txt파일들 목록을 각각 받아온 뒤에 해당 정보를 DataGridView에 출력한다.

        private void Form_Loading(object sender, EventArgs e)
        {

            
        }

        private void File_Upload_Button_Click(object sender, EventArgs e)
        {

        }

        private void File_Delete_Button_Click(object sender, EventArgs e)
        {

        }







    }
}
