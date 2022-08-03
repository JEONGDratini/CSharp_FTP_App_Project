using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using System.Threading;



namespace FTP_Client_Demo
{
//===================================FTP 서버에 접속하는 작업을 처리하는 클래스==============================
    class FTP_Access
    {
        //작업수행할 스레드
        Thread WorkingThread = null;

        

        //이벤트 받아올 델리게이트
        public delegate void ExceptionEventHandler(string locationID, Exception ex);

        //에러처리는 해야져..ㅎ
        public event ExceptionEventHandler ExceptionEvent;
        public Exception LastException = null;

        public bool Is_Connected {get; set;}
        //서버 접속에 필요한 정보들 저장하는 변수들.
        private string IP;
        private string port;
        private string user_ID;
        private string user_PW;
        private string localFullDownLoadPath;

        //서버에 로그를 남길 때 필요한 클라이언트 정보들을 저장하는 변수들.
        private string externalip;
        //다운로드, 업로드 현황 표기를 위한 변수들.
        private int FullSize;
        private int WorkedSize;

        public FTP_Access() { }

        //ftp 서버에 연결하는 메소드
        public async Task<bool> Connect_FTP_Server(string ip, string port, string id, string password, string localDownloadPath)
        {
            this.Is_Connected = false;

            this.IP = ip;
            this.port = port;
            this.user_ID = id;
            this.user_PW = password;
            this.localFullDownLoadPath = localDownloadPath;

            string URL_Addr = string.Format("FTP://{0}:{1}/", this.IP, this.port);
            try
            {
                //FTP 클라 생성
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL_Addr);
                request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);

                request.KeepAlive = false;
                //폴더내용 받아오기로 메소드 설정.
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                request.UsePassive = false;

                //응답을 받아온다.
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                //받은 응답에서 스트림을 가져와 읽는다.
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string[] data = reader.ReadToEnd().Split('\n');


                this.Is_Connected = true;

                bool log_success = await Logging(1, "");


            }
            catch (Exception ex) {
                this.LastException = ex;
                //멤버 특정 정보 가져오기

                System.Reflection.MemberInfo info = System.Reflection.MethodInfo.GetCurrentMethod();
                string info_id = string.Format("{0}.{1}", info.ReflectedType.Name, info.Name);

                if (this.ExceptionEvent != null)
                {
                    this.ExceptionEvent(id, ex);
                }
                return false;
            }
            return true;
        }

        //지정한 경로에 해당하는 파일정보 리스트들을 불러오는 함수
        public List<string[]> get_File_List(string PATH) {
            string URL = string.Format("FTP://{0}:{1}{2}", this.IP, this.port, PATH);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
            request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            //응답을 받아온다.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //받은 응답에서 스트림을 가져와 읽는다.
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string[] raw_fileInfo = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<string[]> file_list = new List<string[]>();//반환할 파일정보 리스트.

            foreach (string file in raw_fileInfo)
            {
                //fileDetailes = {날짜, 용량(폴더라면 <DIR>), 파일이름}
                string date = file.Substring(0, 17);
                string Capacity = file.Substring(17, 21).Trim();
                string name = file.Substring(39);

                if (name.Contains("LOG_FOLDER"))//로그폴더면 이름을 반환하지 않는다.
                    continue;

                string[] fileDetailes = { date, Capacity, name };
                file_list.Add(fileDetailes);
            }

            return file_list;
        }

        //파일 다운로드를 수행하는 함수
        public async Task<bool> File_DownLoad(string serverCurrentPath, string FileName, bool Is_Logging) {
            try {
                string URL = string.Format("FTP://{0}:{1}{2}{3}", this.IP, this.port, serverCurrentPath, FileName);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
                request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);//인증정보
                request.KeepAlive = false;//연결 살려둘거에요?
                request.UseBinary = true;//이진형식을 Data주고받을거에요?
                request.UsePassive = false;//클라가 Data포트 연결 시작해야하나요?

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();//응답 받아옴.

                string FullDownLoadFile = this.localFullDownLoadPath + "/" + FileName;//로컬에 파일 어디에 저장할지
                FileStream outputStream = new FileStream(FullDownLoadFile, FileMode.Create, FileAccess.Write);//파일 작성에 쓸 스트림.
                Stream ftpStream = response.GetResponseStream();//가져온 응답을 다룰 스트림.

                int bufferSize = 2048;//버퍼사이즈 설정.
                int readCount;//얼마나 많은 버퍼를 읽을지를 지정해주는 변수.
                byte[] buffer = new byte[bufferSize];

                //처음 1번 읽어온 뒤에 ftpStream에서 파일을 읽는데 몇개버퍼나 더 읽어와야하는지 구한다.
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                FullSize = (int)outputStream.Length / bufferSize;
                WorkedSize = 1;//ref로 받아온 현재 보낸 버퍼 갯수에 값집어넣기

                while (readCount > 0) { //readCount가 0이 될때까지 반복한다.
                    outputStream.Write(buffer, 0, readCount);//파일작성 스트림으로 지정한 경로에 readCount순서대로 내용을 작성한다.
                    readCount = ftpStream.Read(buffer, 0, bufferSize);//1번 더 읽어오고 readCount를 갱신.
                    WorkedSize++;//현재 보낸 버퍼 갯수 업데이트
                }

                //파일 쓰는거 다 끝나면 스트림 다 닫는다.
                ftpStream.Close();
                outputStream.Close();

                if (buffer != null) {//버퍼에 찌꺼기가 껴있으면
                    Array.Clear(buffer, 0, buffer.Length);//청소한다.
                    buffer = null;
                }

                //가져온 사이즈 변수들도 초기화 해준다.
                FullSize = 0;
                WorkedSize = 0;

                if (!Is_Logging)
                    await Logging(2, URL);

                return true;
            }
            catch (Exception ex)//에러처리
            {
                this.LastException = ex;

                System.Reflection.MemberInfo info = System.Reflection.MethodInfo.GetCurrentMethod();
                string id = string.Format("{0}.{1}", info.ReflectedType.Name, info.Name);

                if(this.ExceptionEvent != null)
                {
                    this.ExceptionEvent(id, ex);
                }
                return false;
            }
        }

        //파일 업로드를 수행하는 함수
        public async Task<bool> File_UpLoad(string localUpLoadPath, string serverCurrentPath, bool Is_Logging) {
            try
            {
                string Local_File_Name = Path.GetFileName(localUpLoadPath);
                string FTP_URL = string.Format("FTP://{0}:{1}{2}{3}", this.IP, this.port, serverCurrentPath, Local_File_Name);
                FtpWebRequest request;

                request = (FtpWebRequest)WebRequest.Create(FTP_URL);
 
                request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);//인증정보
                request.Method = WebRequestMethods.Ftp.UploadFile;//업로드 지정.

                FileStream sourceFileStream = new FileStream(localUpLoadPath, FileMode.Open, FileAccess.Read);
                Stream TargetWriteStream = request.GetRequestStream();

                int bufflength = 2048;//2048 바이트씩 읽어서 보낸다.
                byte[] buff = new byte[bufflength];//버퍼배열선언.


                FullSize = (int)sourceFileStream.Length / bufflength;
                WorkedSize = 0;
                int cnt = 0;
                while (true)
                {
                    int byteCount = sourceFileStream.Read(buff, 0, buff.Length);

                    if (byteCount == 0 || cnt > 150000)
                        break;
                    TargetWriteStream.Write(buff, 0, byteCount);
                    WorkedSize++;
                }
                TargetWriteStream.Close();
                sourceFileStream.Close();


                if (buff != null)
                {//버퍼에 찌꺼기가 껴있으면
                    Array.Clear(buff, 0, buff.Length);//청소한다.
                    buff = null;
                }

                if (!Is_Logging)
                    await Logging(3, FTP_URL);
            }
            catch (Exception ex)
            {
                this.LastException = ex;

                System.Reflection.MemberInfo info = System.Reflection.MethodInfo.GetCurrentMethod();
                string id = string.Format("{0}.{1}", info.ReflectedType.Name, info.Name);

                if (this.ExceptionEvent != null)
                {
                    this.ExceptionEvent(id, ex);
                }
                return false;
            }
            return true;
        }


        public bool Delete(string serverCurrentPath, string FileName, bool is_Dir)
        {
            try
            {
                string URL = string.Format("FTP://{0}:{1}{2}{3}", this.IP, this.port, serverCurrentPath, FileName);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
                request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);//인증정보
                //지울대상이 폴더면 폴더삭제 메소드로 설정하고 Delete함수를 재귀호출해서 안에있는 것들을 싸그리 지운다.
                if (is_Dir)
                {
                    URL = URL + "/";
                    request.Method = WebRequestMethods.Ftp.RemoveDirectory;

                    int substrlen = 19 + this.port.Length;
                    List<string[]> File_List = get_File_List(URL.Substring(substrlen));
                    if (File_List.Count > 0)
                    {
                        foreach (string[] File_InFo in File_List)
                        {
                            if (File_InFo[1].Equals("<DIR>"))
                                Delete(URL.Substring(substrlen), File_InFo[2], true);

                            else
                                Delete(URL.Substring(substrlen), File_InFo[2], false);
                        }
                    }
                }
                else//지울대상이 파일이면 파일삭제 메소드로 설정한다.
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private async Task<bool> Logging(int Logging_Mode, string F_Path) {//로그를 남기는 함수. Logging_Mode 1 : Connect, 2 : DownLoad, 3 : UpLoad.
            //서버에 남길 기록을 위한 내 ip주소 가져오기
            externalip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();//정보를 가져온 뒤에 양옆에 쓰잘데기없는 문구들을 자른다.
            if (String.IsNullOrWhiteSpace(externalip))
            {
                externalip = GetInternalIPAddress();//null경우 Get Internal IP를 가져오게 한다.   
            }

            //가져온 내 ip주소로 서버에 로그 남기기
            List<string[]> Log_List = get_File_List("/LOG_FOLDER/");

            bool check_Found = false;//해당 ip에 맞는 로그파일이 존재하는지 확인하고 있으면 해당파일을 수정, 없으면 새 로그파일을 만들어 업로드한다.
            bool DownLoad_success = false;
            bool UpLoad_success = false;
            string FilePath = string.Format(localFullDownLoadPath + "\\" + externalip + ".txt");

            foreach (string[] Log in Log_List)
            {

                if (Log[2].Contains(externalip))//로그파일을 찾으면 해당파일을 다운로드 받은 뒤 수정하고, 다시 업로드한다. 로컬에 남아있는 로그파일은 삭제한다.
                {
                    check_Found = true;

                    DownLoad_success = await File_DownLoad("/LOG_FOLDER/", externalip + ".txt", true);
                    if (DownLoad_success)
                    {

                        FileStream LogfileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                        StreamReader LogReader = new StreamReader(LogfileStream);

                        string Log_contents = LogReader.ReadToEnd();//로그파일 내용 읽는다.
                        LogReader.Close();

                        LogfileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Write);
                        if(Logging_Mode == 1)
                            Log_contents = Log_contents + string.Format(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  " + externalip + "  Connect");
                        else if(Logging_Mode == 2)
                            Log_contents = Log_contents + string.Format(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  " + externalip + "  DownLoad  " + F_Path);
                        else if(Logging_Mode == 3)
                            Log_contents = Log_contents + string.Format(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  " + externalip + "  UpLoad    " + F_Path);
                        
                        StreamWriter LogWriter = new StreamWriter(LogfileStream);

                        LogWriter.WriteLine(Log_contents);

                        LogWriter.Close();
                        LogfileStream.Close();
                    }

                    UpLoad_success = await File_UpLoad(FilePath, "/LOG_FOLDER/", true);//추가한 로그 내용을 업로드한다.
                    if (UpLoad_success)
                    {//업로드 성공하면
                        File.Delete(FilePath);
                        return true;
                    }
                    else
                        return false;
                }
            }
            if (!check_Found) //해당 아이피에 대한 로그파일이 없을 때 파일을 새로 생성한다.
            {
                FileStream LogfileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);

                StreamWriter LogWriter = new StreamWriter(LogfileStream);

                if (Logging_Mode == 1)
                    LogWriter.WriteLine(string.Format(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  " + externalip + "  Connect"));
                else if (Logging_Mode == 2)
                    LogWriter.WriteLine(string.Format(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  " + externalip + "  DownLoad " + F_Path));
                else if (Logging_Mode == 3)
                    LogWriter.WriteLine(string.Format(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "  " + externalip + "  UpLoad " + F_Path));

                LogWriter.Close();
                LogfileStream.Close();

                UpLoad_success = await File_UpLoad(FilePath, "/LOG_FOLDER/", true);//로그 내용을 업로드한다.
                if (UpLoad_success)
                {//업로드 성공하면
                    File.Delete(FilePath);
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        //새 폴더를 만드는 함수
        public bool New_Folder(string serverCurrentPath, string Folder_Name)
        {
            try
            {
                string FTP_URL = string.Format("FTP://{0}:{1}{2}{3}", this.IP, this.port, serverCurrentPath, Folder_Name);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTP_URL);
                request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);//인증정보
                request.Method = WebRequestMethods.Ftp.MakeDirectory;//폴더 만들기 지정.
                request.KeepAlive = false;
                request.UsePassive = false;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();//bool형은 안되고 var형만 using 할 수 있는듯.
                
                response.Close();
                

            }
            catch {
                return false;
            }
            return true;
        }

        //내부ip주소 가져오는 함수
        private static string GetInternalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        //해당 디렉토리의 크기를 알아내는 함수
        public long get_Total_Size(string PATH)
        {
            long size = 0;
            string URL = string.Format("FTP://{0}:{1}{2}", this.IP, this.port, PATH);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
            request.Credentials = new NetworkCredential(this.user_ID, this.user_PW);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            //응답을 받아온다.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //받은 응답에서 스트림을 가져와 읽는다.
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string[] raw_fileInfo = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string file in raw_fileInfo)
            {
                //fileDetailes = {날짜, 용량(폴더라면 <DIR>), 파일이름}

                string Capacity = file.Substring(17, 21).Trim();
                string name = file.Substring(39);

                if (Capacity.Equals("<DIR>"))//폴더면 파일 용량 연산을 안하고 바로 값을 집어넣고
                    size = size + get_Total_Size(string.Format(PATH + name + "/"));
                else//파일이면 파일 용량 연산을 시행하고 값을 집어넣는다.
                   size = size + long.Parse(Capacity);

            }
           
            return size;
        }

        //현재 작업할 파일의 전체 버퍼 수를 반환하는 함수
        public async Task<int> getFullSize() {
            return FullSize;
        }

        //현재 작업 중인 파일의 작업진행현황을 반환하는 함수
        public async Task<int> getDownloadSize() {
            return WorkedSize;
        }
    }
}
