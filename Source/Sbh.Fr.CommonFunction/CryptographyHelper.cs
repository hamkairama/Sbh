using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sbh.Fr.CommonFunction
{
    public static class CryptographyHelper
    {
        private static string key = "sblw-3hn8-sqoy19";

        public static string EncrytPwd(string encPwd)
        {
            try
            {
                string decpwd = "";
                for (int i = 0; i < encPwd.Length; i++)
                {
                    char chr = (char)(encPwd[i] + 10);
                    decpwd += new string(chr, 1);
                }
                decpwd = Guid.NewGuid().ToString().Substring(0, 5) + decpwd + Guid.NewGuid().ToString().Substring(0, 3);
                return Encrypt(decpwd);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string Encrypt(string input)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptPwd(string input)
        {
            try
            {
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Decrypt(UTF8Encoding.UTF8.GetString(resultArray));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string Decrypt(string decPwd)
        {
            string decpwd = "";
            for (int i = 0; i < decPwd.Length; i++)
            {
                char chr = (char)(decPwd[i] - 10);
                decpwd += new string(chr, 1);
            }
            decpwd = decpwd.Substring(5);
            decpwd = decpwd.Substring(0, decpwd.Length - 3);
            return decpwd;
        }
    }
}
