using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace FTP_Client_Demo
{
//===================================FTP 서버에 접속하는 작업을 처리하는 클래스==============================
    class FTP_Access
    {
        //델리게이트
        public delegate void ExceptionEventHandler(string locationID, Exception ex);

        public event ExceptionEventHandler ExceptionEvent;
        public Exception LastException = null;

        public bool Is_Connected {get; set;}
        private string IP;
        private string port;
        private string user_ID;
        private string user_PW;

        public FTP_Access() { }

        //ftp 서버에 연결하는 메소드
        public bool Connect_FTP_Server(string ip, string port, string id, string password)
        {
            this.Is_Connected = false;

            this.IP = ip;
            this.port = port;
            this.user_ID = id;
            this.user_PW = password;

            string URL_Addr = "FTP://{this.IP}:{this.port}/";
            try
            {
                //FTP 클라 생성
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL_Addr);
                request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);

                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.ListDirectory;//폴더내용 받아오기

                request.UsePassive = false;
                using (request.GetResponse())
                {
                }
                this.Is_Connected = true;
            }
            catch (Exception ex) {
                this.LastException = ex;



            }
            return true;
        }


    }
}
