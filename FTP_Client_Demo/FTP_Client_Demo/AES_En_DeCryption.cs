using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FTP_Client_Demo
{
    class AES_En_DeCryption
    {
        //key값 (멜로망스 - 좋은날 가사 중 발췌)
        private string aes_key = "sprkrjesmsrmrlfdldjswpskghksgkrpvldjskrlf";


        public AES_En_DeCryption() { }

        public string Encrypt(string contentToEncrypt)
        {
            RijndaelManaged AES_crypt = new RijndaelManaged();//암호화 객체 생성.
            AES_crypt.Mode = CipherMode.CBC;//기본값이지만 보여주려고 적었음.
            AES_crypt.Padding = PaddingMode.PKCS7;//얘도 기본값이지만 보여주려고 적음.

            AES_crypt.KeySize = 128;//키사이즈 설정.
            AES_crypt.BlockSize = 128;

            byte[] pwdBytes = Encoding.UTF8.GetBytes(aes_key);//키값을 바이트로 인코딩시킨다.
            byte[] keyBytes = new byte[16];//키사이즈에 맞게 keybyte배열을 선언한다.
            int length = pwdBytes.Length;//변환한 바이트의 크기를 keybyte배열 크기와 비교한 후 변환한 바이트 크기가 더 크면 length를 갱신한다.
            if (length > keyBytes.Length)
                length = keyBytes.Length;
            Array.Copy(pwdBytes, keyBytes, length);//pwdByte를 keyByte로 length만큼 복사한다.
            AES_crypt.Key = keyBytes;//key값과 IV값 설정한다.
            AES_crypt.IV = keyBytes;
            ICryptoTransform tf = AES_crypt.CreateEncryptor();//암호화기 만들고.
            byte[] plainText = Encoding.UTF8.GetBytes(contentToEncrypt);//암호화할 문자열을 바이트로 인코딩 시킨 뒤


            return Convert.ToBase64String(tf.TransformFinalBlock(plainText, 0, plainText.Length));//암호화시킨 것을 반환한다.
        }

        public string Decrypt(string contentToDecrypt)
        {
            byte[] plainText;
            try
            {
                RijndaelManaged AES_crypt = new RijndaelManaged();//암호화 객체 생성.
                AES_crypt.KeySize = 128;//키사이즈 설정.
                AES_crypt.BlockSize = 128;

                byte[] EncryptedData = Convert.FromBase64String(contentToDecrypt);
                byte[] pwdBytes = Encoding.UTF8.GetBytes(aes_key);
                byte[] keyBytes = new byte[16];
                int length = pwdBytes.Length;
                if (length > keyBytes.Length)
                    length = keyBytes.Length;
                Array.Copy(pwdBytes, keyBytes, length);
                AES_crypt.Key = keyBytes;
                AES_crypt.IV = keyBytes;

                plainText = AES_crypt.CreateDecryptor().TransformFinalBlock(EncryptedData, 0, EncryptedData.Length);
            }
            catch
            {
                return "";
            }


            return Encoding.UTF8.GetString(plainText);
        }
    }
}
