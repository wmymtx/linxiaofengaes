﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Des
    {
        /// <summary>  
        /// 创建Key  
        /// </summary>  
        /// <returns></returns>  
        public string GenerateKey()
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }
        /// <summary>  
        /// 加密字符串  
        /// </summary>  
        /// <param name="sinputString"></param>  
        /// <param name="Skey"></param>  
        /// <returns></returns>  
        public static string EncryptString(string sinputString, string Skey)
        {
            byte[] data = Encoding.UTF8.GetBytes(sinputString);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(Skey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(Skey);
            ICryptoTransform desEncrypt = DES.CreateEncryptor();
            byte[] result = desEncrypt.TransformFinalBlock(data, 0, data.Length);
            return BitConverter.ToString(result);
        }
        /// <summary>  
        /// 解密字符串  
        /// </summary>  
        /// <param name="sinputString"></param>  
        /// <param name="sKey"></param>  
        /// <returns></returns>  
        public static string DecryptString(string sinputString, string sKey)
        {
            string[] sinput = sinputString.Split("-".ToCharArray());
            byte[] data = new byte[sinput.Length];
            for (int i = 0; i < sinput.Length; i++)
            {
                data[i] = byte.Parse(sinput[i], NumberStyles.HexNumber);
            }
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateDecryptor();
            byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF8.GetString(result);
        }

        /// <summary>  
        /// DES加密  
        /// </summary>  
        /// <param name="pToEncrypt"></param>  
        /// <param name="sKey"></param>  
        /// <returns></returns>  
        public static string MD5Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            byte[] keys = new byte[24];
            keys = Encoding.UTF8.GetBytes(sKey);
            byte[] iv = Encoding.UTF8.GetBytes("LinXiaoF");
            des.Key = keys;
            des.IV = Encoding.UTF8.GetBytes("LinXiaoF");
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        /// <summary>  
        /// DES解密  
        /// </summary>  
        /// <param name="pToDecrypt"></param>  
        /// <param name="sKey"></param>  
        /// <returns></returns>  
        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes("LinXiaoF");
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}
