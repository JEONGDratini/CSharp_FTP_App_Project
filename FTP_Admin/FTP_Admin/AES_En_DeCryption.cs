using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FTP_Admin
{
    //문자열에 대한 AES 암, 복호화를 할 수 있게 해주는 클래스
    class AES_En_DeCryption
    {
        private string aes_key = "sprkrjesmsrmrlfdldjswpskghksgkrpvldjskrlf";//key값(멜로망스 - 좋은날 가사 중 발췌) : 네가걷는그길이언제나환하게피어나길
        
        RijndaelManaged aes = new RijndaelManaged();
        public AES_En_DeCryption(string key) {
            this.aes_key = key;
        }

        public string Encrypt(string contentToEncrypt) {
            string result = null;



            return result;
        }

        public string Decrypt(string contentToDecrypt)
        {
            string result = null;

            return result;
        }
    }
}
