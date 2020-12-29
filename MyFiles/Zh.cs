using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JD.MF
{
    public static class ZH
    {
        /// <summary>
        /// 中文字符工具类
        /// </summary>
        private const int LOCALE_SYSTEM_DEFAULT = 0x0800;
        private const int LCMAP_SIMPLIFIED_CHINESE = 0x02000000;
        private const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc, [Out] string lpDestStr, int cchDest);

        /// <summary>
        /// 将字符转换成简体中文
        /// </summary>
        /// <param name="source">输入要转换的字符串</param>
        /// <returns>转换完成后的字符串</returns>
        public static string ToSimplified(string source)
        {
            try
            {
                String target = new String(' ', source.Length);
                int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_SIMPLIFIED_CHINESE, source, source.Length, target, source.Length);
                return target;
            }
            catch { return source; };
        }

        /// <summary>
        /// 讲字符转换为繁体中文
        /// </summary>
        /// <param name="source">输入要转换的字符串</param>
        /// <returns>转换完成后的字符串</returns>
        public static string ToTraditional(string source)
        {
            String target = new String(' ', source.Length);
            int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_TRADITIONAL_CHINESE, source, source.Length, target, source.Length);
            return target;
        }

        // / 转半角的函数(DBC case)
        public static string ToDBC(string input)
        {
            input = input.Replace("【", "[").Replace("】", "]").Replace("＜","<").Replace("＞", ">");
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }


        #region 中文转阿拉伯数字
        /// <summary>
        /// e.g. 第二十二个   第 begin  个 end
        /// </summary>
        /// <param name="w"></param>
        /// <param name="begin">identifier for the begining  比如 第一百集</param>
        /// <param name="end">identifier for the end, e.g 集</param>
        /// <returns></returns>
        public static string Word2Number(string w, string begin = "^", string end = "$")
        {
            if (w == "")
                return w;

            var m = Regex.Match(w, $"{begin}([零一二三四五六七八九十百千万]+亿)?([零一二三四五六七八九十百千]+万)?([零一二三四五六七八九十百千]+)?{end}");
            if (m.Success)
            {
                var number = (
                    Convert.ToInt64(foh(m.Result("$1"))) * 100000000 +
                    Convert.ToInt64(foh(m.Result("$2"))) * 10000 +
                    Convert.ToInt64(foh(m.Result("$3")))
                    ).ToString();
                return w.Replace(m.Value, $"{begin}{number}{end}");
            }
            else
            {
                return w;
            }
        }

        private static int foh(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            string e = "零一二三四五六七八九";
            string[] ew = new string[] { "十", "百", "千" };
            string[] ej = new string[] { "万", "亿" };

            int a = 0;
            if (str.IndexOf(ew[0]) == 0)
                a = 10;
            str = Regex.Replace(str, e[0].ToString(), "");

            if (Regex.IsMatch(str, "([" + e + "])$"))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])$").Value[0]);
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[0]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[0]).Value[0]) * 10;
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[1]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[1]).Value[0]) * 100;
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[2]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[2]).Value[0]) * 1000;
            }
            return a;
        }
        
        #endregion
    }
}
