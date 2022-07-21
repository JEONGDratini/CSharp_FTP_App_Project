using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Microsoft_doc_tutorial_experience
{
    class Program
    {
        static void Main(string[] args)
        {
            // 코드 단순화를 위해 하드코드함
            string ftpPath = "ftp://111.111.0.31:21/";
            string user = "user";  // FTP 익명 로그인시. 아니면 로그인/암호 지정.
            string pwd = "godvndsk1!";
            string outputFile = "index.txt";
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential (user,pwd);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string[] data = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            StreamWriter writer = new StreamWriter(outputFile);
            
            
            foreach (string str in data)
            {
                Console.WriteLine(str);
                writer.WriteLine(str);
            }
            List<string[]> file_list = new List<string[]>();

            foreach (string file in data)
            {
                //fileDetailes = {날짜, 용량(폴더라면 <DIR>), 파일이름}
                string date = file.Substring(0, 17);
                string Capacity = file.Substring(17, 21).Trim();
                string name = file.Substring(39);
                string[] fileDetailes = { date, Capacity, name };
                Console.WriteLine("++{0}++{1}++{2}++", fileDetailes[0], fileDetailes[1], fileDetailes[2]);
                file_list.Add(fileDetailes);
            }

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();
            writer.Close();
            Console.ReadLine();
        }            
    }
}

