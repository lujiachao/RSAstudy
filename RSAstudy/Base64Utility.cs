using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace RSAstudy
{
    public class Base64Utility
    {
        private static char[] base64CodeArray = new char[]
                {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4',  '5', '6', '7', '8', '9', '+', '/', '='
                };

        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsBase64(string base64Str)
        {
            byte[] bytes = null;
            return IsBase64(base64Str, out bytes);
        }

        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <param name="bytes">字符串转换成的字节数组</param>
        /// <returns></returns>
        public static bool IsBase64(string base64Str, out byte[] bytes)
        {
            //string strRegex = "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$";
            bytes = null;
            if (string.IsNullOrEmpty(base64Str))
                return false;
            else
            {
                if (base64Str.Contains(","))
                    base64Str = base64Str.Split(',')[1];
                if (base64Str.Length % 4 != 0)
                    return false;
                if (base64Str.Any(c => !base64CodeArray.Contains(c)))
                    return false;
            }
            try
            {
                bytes = Convert.FromBase64String(base64Str);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// 把base64字符串转换成Bitmap
        /// </summary>
        /// <param name="base64Str">要转换的base64字符串</param>
        /// <returns></returns>
        public static Bitmap Base64ToBitmap(string base64Str)
        {
            Bitmap bitmap = null;
            byte[] bytes = null;
            try
            {
                if (IsBase64(base64Str, out bytes))
                {
                    using (MemoryStream stream = new MemoryStream(bytes))
                    {
                        stream.Seek(0, SeekOrigin.Begin);//为了避免有时候流指针定位错误，显式定义一下指针位置
                        bitmap = new Bitmap(stream);
                    }
                }
            }
            catch (Exception)
            {
                bitmap = null;
            }
            return bitmap;
        }

        /// <summary>
        /// 根据base64字符串获取文件后缀（图片格式）
        /// </summary>
        /// <param name="base64Str">base64</param>
        /// <returns></returns>
        public static string GetSuffixFromBase64Str(string base64Str)
        {
            string suffix = string.Empty;
            string prefix = "data:image/";
            if (base64Str.StartsWith(prefix) && base64Str.Contains(";") && base64Str.Contains(","))
            {
                base64Str = base64Str.Split(';')[0];
                suffix = base64Str.Substring(prefix.Length);
            }
            return suffix;
        }
    }
}

