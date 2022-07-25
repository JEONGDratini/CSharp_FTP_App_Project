using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Progress_Bar_Test
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private int timerCount = 0;
        private Thread th_Load;

        public Form1()
        {
            InitializeComponent();

            // 테스트용으로 타이머 이용
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 디폴트값 사용 (Maximum=100, Minimum=0, Step=10)
            progressBar1.Style = ProgressBarStyle.Blocks;

            // 최대,최소,간격을 임의로 조정
            progressBar2.Style = ProgressBarStyle.Continuous;
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 90;
            progressBar2.Step = 5;
            progressBar2.Value = 0;

            // Marquee 스타일
            progressBar3.Style = ProgressBarStyle.Marquee;
            progressBar3.Enabled = true;

            // 테스트를 위해 타이머 시작
            timer.Start();


        }

        void timer_Tick(object sender, EventArgs e)
        {
            // 한 스텝 이동
            progressBar1.PerformStep();
            progressBar2.PerformStep();

            // 타이머 중지 조건
            if (++timerCount == 20)
            {
                timer.Stop();
                progressBar3.Enabled = false;
            }
        }



        


    }
}
