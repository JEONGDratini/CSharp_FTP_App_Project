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
using System.Threading;

namespace TCP_Async_Client_Example
{
    public partial class Form1 : Form
    {
         TcpClient clientSocket = new TcpClient(); // 소켓
        NetworkStream stream = default(NetworkStream); 
        string message = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect("111.111.0.31", 9999); // 접속 IP 및 포트
                stream = clientSocket.GetStream();
            }
            catch (Exception e2)
            {
                MessageBox.Show("서버가 실행중이 아닙니다.", "연결 실패!");
                Application.Exit();
            }

            message = "채팅 서버에 연결 되었습니다.";
            DisplayText(message);

            byte[] buffer = Encoding.Unicode.GetBytes("$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            Thread t_handler = new Thread(GetMessage);
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        private void button1_Click(object sender, EventArgs e) // 메세지 보내기
        {
            textBox2.Focus();
            byte[] buffer = Encoding.Unicode.GetBytes(textBox2.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            textBox2.Text = "";
        }

        private void GetMessage() // 메세지 받기
        {
            while (true)
            {
                stream = clientSocket.GetStream();
                int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[BUFFERSIZE];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                DisplayText(message);
            }
        }

        private void DisplayText(string text) // Server에 메세지 출력
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(new MethodInvoker(delegate
                {
                    textBox1.AppendText(text + Environment.NewLine);
                }));
            }
            else
                textBox1.AppendText(text + Environment.NewLine);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // 엔터키 눌렀을 때
                button1_Click(this, e);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) // 폼 닫을 때 실행
        {
            byte[] buffer = Encoding.Unicode.GetBytes("leaveChat" + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            Application.ExitThread();
            Environment.Exit(0);
        }
    }
}
