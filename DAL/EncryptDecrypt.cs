using System;
using System.Text;

namespace HSBank.DAL
{
    public class EncryptDecrypt
    {
       public  string EncryptData(string sDataToEncrypt)
        {
            string strmsg = string.Empty;
            byte[] encode = null;
            try
            {
                if (!string.IsNullOrEmpty(sDataToEncrypt))
                {
                    encode = new byte[sDataToEncrypt.Length];
                    encode = Encoding.UTF8.GetBytes(sDataToEncrypt);
                    strmsg = Convert.ToBase64String(encode);
                }
                return strmsg;
            }
            catch
            {
                throw;
            }
            finally
            {
                strmsg = string.Empty;
                encode = null;
            }
        }
         public string Decryptdata(string sDataToDecrypt)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = null;
            Decoder Decode = null;
            byte[] todecode_byte = null;
            char[] decoded_char = null;
            try
            {
                encodepwd = new UTF8Encoding();
                Decode = encodepwd.GetDecoder();
                todecode_byte = Convert.FromBase64String(sDataToDecrypt);
                int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                decoded_char = new char[charCount];
                Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                decryptpwd = new String(decoded_char);
                return decryptpwd;
            }
            catch
            {
                throw;
            }
        }
    }
}
