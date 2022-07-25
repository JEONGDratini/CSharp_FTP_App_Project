﻿using System;
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
    public partial class Form2 : Form
    {

        public delegate void DataPassEventHandler(string data);//델리게이트 만들고

        public event DataPassEventHandler DataPassEvent;//이벤트 객체를 만든다.

        private string CurrentPath;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string CurrentPath)
        {
            InitializeComponent();
            this.CurrentPath = CurrentPath;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Current_Path.Text = string.Format("위치 : " + this.CurrentPath);
        }

        private void NewFolder_Button_Click(object sender, EventArgs e)
        {
            DataPassEvent(NewFolderName.Text);//이벤트 객체로 이벤트를 발생시킨다.
            this.Close();
        }

    }
}
