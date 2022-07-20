using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_Client_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Find_FilePath_Button_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            Upload_FileDialog.InitialDirectory = "C:\\";
            if (Upload_FileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = Upload_FileDialog.FileName;
            }
            textBox1.Text = filePath;
        }

        private void Connection_Button_Click(object sender, EventArgs e)
        {

        }

        private void Get_Dir_Path_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
