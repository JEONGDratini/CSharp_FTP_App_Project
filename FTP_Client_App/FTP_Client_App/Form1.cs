using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_Client_App
{
    public partial class FTP_Client : Form
    {
        public FTP_Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            File_List.Columns.Add("Colnum", "번호");
            File_List.Columns.Add("ColName", "파일명");

            User_request_List.Columns.Add("Colnum", "번호");
            User_request_List.Columns.Add("ColTitle", "제목");
            User_request_List.Columns.Add("ColAnswered", "답변여부");
        }

        private void Find_FilePath_Button_Click(object sender, EventArgs e)
        {
            var folderPath = string.Empty;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }
            DownLoad_Dir_Path.Text = folderPath;
        }
    }
}
