using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;

//메인폼
namespace FTP_FTP_Admin
{
    public partial class Form1 : Form
    {
        private FTP_Access FTP = null;//따로만든 FTP접속 클래스 객체 받아올 변수
        private FTP_Admin.AES_En_DeCryption Cryptor = new FTP_Admin.AES_En_DeCryption();

        private int BtnColumnIndex;//버튼 컬럼 인덱스
        private int DelBtnColumnIndex;//삭제버튼 컬럼 인덱스

        private Thread th_progress;//프로그레스 바 제어하기 위한 스레드
        private delegate void SetProgressBarSafeDelegate(int var);


        private Stack<string> Directory_History;

        DataGridViewButtonColumn Down_Openbtn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn Delete_btn = new DataGridViewButtonColumn();
                    
        public Form1()
        {
            InitializeComponent();
            
        }

        //폼이 로드되면 기존에 저장돼있던 ip, 포트를 dat에서 읽어와서 ip입력창, 포트입력창에 띄운다.
        //서버에 연결되기 전엔 쓸 수 없는 파일 목록란과 파일업로드ui, 작업진행상황 프로그레스바를 비활성화 시킨다.
        private void Form_Load(object sender, EventArgs e)
        {
            StreamReader IP_Port_Log = new StreamReader("IP_Port_Log.txt");
            StreamReader ID_PW_Log = new StreamReader("ID_PW_Log.txt");

            BtnColumnIndex = File_InFo_GridView.Columns.Add(Down_Openbtn);//데이터 그리드 뷰에 버튼 열을 추가한다.
            Down_Openbtn.HeaderText = "다운로드/폴더열기";
            Down_Openbtn.Name = "DownLoad_Open_Btn";
            Down_Openbtn.Width = 70;

            DelBtnColumnIndex = File_InFo_GridView.Columns.Add(Delete_btn);//데이터 그리드 뷰에 삭제버튼 열을 추가한다.
            Delete_btn.HeaderText = "삭제";
            Delete_btn.Name = "Del_Btn";
            Delete_btn.Width = 40;

            string IP_ADDR = IP_Port_Log.ReadLine();
            string Port_Num = IP_Port_Log.ReadLine();
            IP_Port_Log.Close();

            string ID_str = ID_PW_Log.ReadLine();
            string PassWord = ID_PW_Log.ReadLine();
            ID_PW_Log.Close();

            IP_Address_Input.Text = Cryptor.Decrypt(IP_ADDR);//파일에 있는 내용을 복호화해서 가져온다.
            Port.Text = Cryptor.Decrypt(Port_Num);
            if (IP_Address_Input.Text.Length > 0)//이미 가져올 정보가 있다면
                Remember_Addr.Checked = true;//주소기억하기를 체크상태로 바꾼다.

            Account_ID.Text = Cryptor.Decrypt(ID_str);
            Password.Text = Cryptor.Decrypt(PassWord);
            if (Account_ID.Text.Length > 0)//이미 가져올 정보가 있다면
                Remember_ID_PW.Checked = true;//주소기억하기를 체크상태로 바꾼다.

            File_InFo_GridView.Enabled = false;
            progressBar1.Enabled = false;
            File_Upload_Button.Enabled = false;
            Find_FilePath_Button.Enabled = false;
            Upload_FilePath.Enabled = false;
            Back_Dir.Enabled = false;


        }

        //파일주소 찾아서 업로드 파일경로에 집어넣는다.
        private void Find_FilePath_Button_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            Upload_FileDialog.InitialDirectory = "C:\\";
            if (Upload_FileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = Upload_FileDialog.FileName;
            }
            Upload_FilePath.Text = filePath;
        }

        //연결을 시도한다. 연결이 성공하고 이 주소 기억하기 체크박스가 체크 돼있으면 dat파일에 ip주소와 포트를 작성한다.
        private void Connection_Button_Click(object sender, EventArgs e)
        {

            if (Connection_Button.Text.Equals("연결"))
            {
                //FTP 연결 객체 생성.
                FTP = new FTP_Access();
                //연결 시도하기 전에 ip주소나 다른 입력들이 제대로 입력됐는지 확인한다.
                if (string.IsNullOrEmpty(IP_Address_Input.Text))
                {
                    MessageBox.Show("ip주소를 입력하세요.");
                    IP_Address_Input.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(Port.Text))
                {
                    MessageBox.Show("포트번호를 입력하세요.");
                    Port.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(Account_ID.Text))
                {
                    MessageBox.Show("아이디를 입력해주세요.");
                    Account_ID.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(Password.Text))
                {
                    MessageBox.Show("비밀번호를 입력해주세요.");
                    Password.Focus();
                    return;
                }

//폴더 경로 텍스트박스에 있던 텍스트를 DirectoryInfo 형식으로 선언해 Exists로 해당 경로가 유효한지 확인한다.
                DirectoryInfo dir_info = new DirectoryInfo(Download_Dir_Path.Text);
                if (!dir_info.Exists) 
                {
                    MessageBox.Show("유효하지 않은 폴더 경로입니다.");
                    Download_Dir_Path.Focus();
                    return;
                }

                //서버에 연결을 시도하고 성공 여부를 불린변수로 받아온다.
                bool success = FTP.Connect_FTP_Server(IP_Address_Input.Text, Port.Text, Account_ID.Text, Password.Text);
                if (success)//성공하면 비활성화된 파일 목록란과 파일업로드ui, 작업진행상황 프로그레스바를 활성화시키고 접속정보 입력란 비활성화와 함께 접속버튼 텍스트를 변경한다.
                {
                    Server_statement.Text = "연결 상태 : 연결성공";
                    Connection_Button.Text = "연결해제";
                    File_InFo_GridView.Enabled = true;//비활성화 시켰던 친구들 활성화
                    progressBar1.Enabled = true;
                    File_Upload_Button.Enabled = true;
                    Find_FilePath_Button.Enabled = true;
                    Upload_FilePath.Enabled = true;
                    Back_Dir.Enabled = true;

                    IP_Address_Input.Enabled = false;//활성화 돼있던 친구들 비활성화
                    Port.Enabled = false;
                    Account_ID.Enabled = false;
                    Password.Enabled = false;
                    Download_Dir_Path.Enabled = false;

                    //이 주소 기억하기가 체크돼있으면 파일에 해당 정보를 암호화 한 뒤 집어넣는다. 체크 안돼있으면 기존 텍스트파일은 삭제한다.
                    if (Remember_Addr.Checked)
                    {
                        StreamWriter sw = new StreamWriter("IP_Port_Log.txt");
                        sw.WriteLine(Cryptor.Encrypt(IP_Address_Input.Text));
                        sw.WriteLine(Cryptor.Encrypt(Port.Text));
                        sw.Close();
                    }
                    else
                        File.Delete("IP_Port_Log.txt");

                    //이 로그인 정보 기억하기가 체크돼있으면 파일에 해당 정보를 암호화한 뒤에 집어넣는다. 체크 안돼있으면 기존 텍스트파일은 삭제한다.
                    if (Remember_Addr.Checked)
                    {
                        StreamWriter sw = new StreamWriter("ID_PW_Log.txt");
                        sw.WriteLine(Cryptor.Encrypt(Account_ID.Text));
                        sw.WriteLine(Cryptor.Encrypt(Password.Text));
                        sw.Close();
                    }
                    else
                        File.Delete("ID_PW_Log.txt");

                    //현재경로 수정하기
                    Current_Path.Text = "/";

                    Directory_History = new Stack<string>();//폴더기록도 가져오기.

                    Update_DataGridView();


                }
                else//실패시
                {
                    MessageBox.Show("연결에 실패했습니다. 올바르게 입력했는지 확인해주세요.");
                    return;
                }
            }
            else {//연결버튼이 연결해제 상태일때

                FTP = null;//FTP객체 박살내기
                Server_statement.Text = "연결 상태 : 연결안됨";
                Connection_Button.Text = "연결";
                File_InFo_GridView.Enabled = false;//비활성화 시켰던 친구들 활성화
                File_InFo_GridView.Rows.Clear();
                progressBar1.Enabled = false;
                File_Upload_Button.Enabled = false;
                Find_FilePath_Button.Enabled = false;
                Upload_FilePath.Enabled = false;
                NewFolder_Button.Enabled = false;

                IP_Address_Input.Enabled = true;//활성화 돼있던 친구들 비활성화
                Port.Enabled = true;
                Account_ID.Enabled = true;
                Password.Enabled = true;
                Download_Dir_Path.Enabled = true;
            }
        }

        //폴더 위치 찾아서 폴더 경로 텍스트박스에 집어넣는다.
        private void Get_Dir_Path_Click(object sender, EventArgs e)
        {
            if (FTP_Client_folderBrowser.ShowDialog() == DialogResult.OK)
               Download_Dir_Path.Text = FTP_Client_folderBrowser.SelectedPath;
            
        }

        //그..DataGridBox의 각 원소의 그 다운로드 버튼을 클릭하면 해당 버튼의 열에 맞는 파일을 다운로드 한다. 프로세스바에 현재 진행상황을 띄운다.
        private async void File_InFo_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BtnColumnIndex)//클릭된 셀의 인덱스가 버튼 컬럼인덱스와 같으면 실행한다.
            {
                //클릭된 행에서 파일이름 가져오기, 용량에서 폴더인지 아닌지 여부 가져오기
                string FileName = File_InFo_GridView.Rows[e.RowIndex].Cells["File_Name"].Value.ToString();
                bool Is_Directory = File_InFo_GridView.Rows[e.RowIndex].Cells["Capacity"].Value.ToString().Equals("폴더");
                
                //폴더라면 해당 폴더 내부 파일정보들 뽑아와서 데이터그리드 뷰에 띄운다.
                if (Is_Directory)
                {
                    File_InFo_GridView.Rows.Clear();
                    //현재경로 수정하기
                    Current_Path.Text = string.Format("{0}{1}/",Current_Path.Text, FileName);

                    //지금까지 온 폴더들 스택에 FileName추가하기
                    Directory_History.Push(FileName);

                    //DataGridview에 내용 표기하기
                    Update_DataGridView();
                }
                else//파일이면 메시지박스로 다운로드 할건지 물어보고 다운로드 시작. 다운로드 완료되면 파일탐색기로 다운로드된 파일폴더 열어서 보여준다.
                {
                    string MsgBx_Content = string.Format(FileName + "파일을 다운로드 하시겠습니까?");
                    DialogResult dr = MessageBox.Show(MsgBx_Content, "다운로드 확인", MessageBoxButtons.YesNo);
                    Working_State.Text = "작업 상태 : 다운로드 중...";
                    if (dr == DialogResult.Yes)
                    {
                        int FullSize = await FTP.getFullSize();
                        if (FullSize>0)
                            MessageBox.Show("이미 다운로더가 작동 중입니다.", "경고");
                        else
                        {
                            File_InFo_GridView.Enabled = false;
    
                            th_progress = new Thread(new ThreadStart(update_progressbar));
                            th_progress.Start();

                            Task<bool> success = FTP.File_DownLoad(Download_Dir_Path.Text, Current_Path.Text, FileName);
                            bool sucs = await success;
                            if (sucs)
                            {
                                MessageBox.Show(FileName + "파일 다운로드를 완료했습니다.");
                                System.Diagnostics.Process.Start(Download_Dir_Path.Text);
                            }
                            else
                                MessageBox.Show(FileName + "파일 다운로드를 실패했습니다.");
                            th_progress.Abort();
                            
                            File_InFo_GridView.Enabled = true;
                        }
                    }
                    Working_State.Text = "작업 상태 : 작업안함.";
                }
                //MessageBox.Show(string.Format("FileName : {0}, {1}", FileName, Is_Directory ? 1:0)); 
            }
            else if (e.ColumnIndex == DelBtnColumnIndex) {//삭제버튼 눌렀을 때
                //클릭된 행에서 파일이름 가져오기, 용량에서 폴더인지 아닌지 여부 가져오기
                string FileName = File_InFo_GridView.Rows[e.RowIndex].Cells["File_Name"].Value.ToString();
                bool Is_Directory = File_InFo_GridView.Rows[e.RowIndex].Cells["Capacity"].Value.ToString().Equals("폴더");

                string MsgBx_Content;
                if (Is_Directory)
                    MsgBx_Content = string.Format(FileName + "폴더 안의 내용 전부를 삭제 하시겠습니까?");
                else
                    MsgBx_Content = string.Format(FileName + "파일을 삭제 하시겠습니까?");
                DialogResult dr = MessageBox.Show(MsgBx_Content, "다운로드 확인", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    bool success = FTP.Delete(Current_Path.Text, FileName, Is_Directory);
                    if (success)
                    {
                        MessageBox.Show(FileName + "파일/폴더 삭제를 완료했습니다.");
                        //DataGridview에 내용 표기하기
                        Update_DataGridView();
                    }
                    else {
                        MessageBox.Show(FileName + "파일/폴더를 삭제하지 못했습니다.");
                    }
                }
                
            }
        }

        //파일을 업로드 한다. 프로세스바에 현재 진행상황을 띄운다.
        private async void File_Upload_Button_Click(object sender, EventArgs e)
        {
            string FileName = Path.GetFileName(Upload_FilePath.Text);
            string MsgBx_Content = string.Format(FileName + "파일을 업로드 하시겠습니까?");
            DialogResult dr = MessageBox.Show(MsgBx_Content, "업로드 확인", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int FullSize = await FTP.getFullSize();
                if (FullSize>0)
                    MessageBox.Show("이미 프로그램이 작업 중입니다.", "경고");
                else
                {
                    File_InFo_GridView.Enabled = false;
                    Working_State.Text = "작업 상태 : 업로드 중...";
                    th_progress = new Thread(new ThreadStart(update_progressbar));
                    th_progress.Start();

                    bool success = await FTP.File_UpLoad(Upload_FilePath.Text, Current_Path.Text);

                    if (success)
                    {
                        MessageBox.Show(FileName + "파일 업로드를 완료했습니다.");
                        Update_DataGridView(); 
                    }
                    else
                        MessageBox.Show(FileName + "파일 업로드를 실패했습니다.");

                    th_progress.Abort();
                    Working_State.Text = "작업 상태 : 작업안함.";
                    File_InFo_GridView.Enabled = true;
                }
            }
        }

        //해당경로에 새폴더를 만든다.
        private void NewFolder_Button_Click(object sender, EventArgs e)
        {
            FTP_Admin.Form2 new_folder_form = new FTP_Admin.Form2(Current_Path.Text);
            new_folder_form.DataPassEvent += new FTP_Admin.Form2.DataPassEventHandler(DataReceiveEvent);
            new_folder_form.Show();
        }

        
        //폴더 뒤로가기 해주는 메소드
        private void Back_Dir_Click(object sender, EventArgs e)
        {
            if (Directory_History.Count == 0)
                MessageBox.Show("더이상 이동할 폴더가 없습니다.");
            else
            {
                //dir 경로 기록에서 가장 최근에 추가한 폴더명을 빼온다.
                string Current_Folder = Directory_History.Pop();

                //현재경로 수정하기
                Current_Path.Text = Current_Path.Text.Substring(0, Current_Path.Text.Length - (Current_Folder.Length+1));

                Update_DataGridView();
            }
        }

        //숫자용량을 적당한 단위로 표기하도록 변환해주는 메소드
        private string Convert_Byte_To_String(string Capacity) {
            string output;
            long real_capacity = long.Parse(Capacity);

            if (real_capacity < 1024) 
                output = string.Format("{0}byte", real_capacity);
            else if (real_capacity < 1024*1024) {
                output = string.Format("{0}kb", real_capacity / 1024);}
            else if (real_capacity < 1024 * 1024 * 1024)
                output = string.Format("{0}mb", real_capacity / (1024 * 1024));
            else
                output = string.Format("{0}gb", real_capacity / (1024 * 1024 * 1024));
            return output;
        }

        private void DataReceiveEvent(string Data) {
            bool success = FTP.New_Folder(Current_Path.Text, Data);

            if (success)
            {
                MessageBox.Show(Data + "폴더 생성했습니다.");

                Update_DataGridView();
            }
            else
                MessageBox.Show(Data + "폴더 생성실패");

        }

        //DataGridView를 갱신해주는 메소드
        private void Update_DataGridView() {

            File_InFo_GridView.Rows.Clear();
            //파일 리스트 받아와서 데이터그리드 뷰에 출력시키기
            List<string[]> File_InFo_List = FTP.get_File_List(Current_Path.Text);

            //각 파일 정보마다 연산한다.
            foreach (string[] File_InFo in File_InFo_List)
            {
                if (File_InFo[1].Equals("<DIR>"))//폴더면 파일 용량 연산을 안하고 바로 값을 집어넣고
                    File_InFo_GridView.Rows.Add(File_InFo[2], "폴더");
                else//파일이면 파일 용량 연산을 시행하고 값을 집어넣는다.
                    File_InFo_GridView.Rows.Add(File_InFo[2], Convert_Byte_To_String(File_InFo[1]));
            }

            //생성된 각 행마다 버튼 추가하기
            foreach (DataGridViewRow row in File_InFo_GridView.Rows)
            {
                row.Cells[BtnColumnIndex].Value = "실행";
                row.Cells[DelBtnColumnIndex].Value = "삭제";
            }
        
        }

        //다운로드 도중에 실시간으로 변하는 progressBar
        private async void update_progressbar() {
            Thread.Sleep(100);
            int FullSize = await FTP.getFullSize();
            progressBar1.Invoke(new SetProgressBarSafeDelegate(set_ProgressMaximum), new object[] { FullSize });

            while (true)
            {
                int WorkedSize = await FTP.getWorkedSize();
            progressBar1.Invoke(new SetProgressBarSafeDelegate(update_progrssbar_safe), new object[] { WorkedSize });
            Thread.Sleep(50);
            }
        }

        private void set_ProgressMaximum(int var)
        {
            progressBar1.Maximum = var;
        }


        private void update_progrssbar_safe(int var) 
        {   
            progressBar1.Value = var;
        }


    }
}
