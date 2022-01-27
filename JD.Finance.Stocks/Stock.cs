using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace JD.Finance.Stocks
{    public class Stock
    {
        public static float GetQuote(string isin)
        {
            string sURL = $"https://www.tradegate.de/orderbuch.php?isin={isin}";
            var wrGETURL = WebRequest.Create(sURL);
            Stream objStream = wrGETURL.GetResponse().GetResponseStream();
            var objReader = new StreamReader(objStream);
            var input = objReader.ReadToEnd();


            string pattern = @"(?<=<strong id=""last"">)(\d+.+)(?=<\/strong>)";
            var matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
            if (matches.Count == 0) return 0;
            var s = matches.First().Value.Replace(",", ".");
            if (!float.TryParse(s, out float v)) return 0;
            return v;
        }

    }
}
