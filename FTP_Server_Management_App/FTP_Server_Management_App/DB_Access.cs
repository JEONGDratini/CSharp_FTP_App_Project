using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//왜 mysql패키지를 깔아야하는데 안깔려 ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ
//정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 
//정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 
//정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 정신나갈 것 같아 
//집에서 깔아야할듯..ㅠ 이부분 코딩은 태블릿으로 하는걸로...
namespace FTP_Server_Management_App
{
    class DB_Connection
    {
        string Server_IP = "";
        string Port = "";
        string DB_Name = "";
        string UID = "";
        string Password = "";

        public DB_Connection(string Server_IP, string Port, string DB_Name, string UID, string Password) {
            this.Server_IP = Server_IP;
            this.Port = Port;
            this.DB_Name = DB_Name;
            this.UID = UID;
            this.Password = Password;
        }

    }
}
