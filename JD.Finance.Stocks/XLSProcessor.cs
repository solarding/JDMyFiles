using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace JD.Finance.Stocks
{
    internal class XLSProcessor
    {
        private const string _PFAD = @"d:\temp\";// @"C:\Users\solar\OneDrive\Finance\Wertpapier\";
        public XLSProcessor()
        {
        }

        public void testc()
        {
            IWorkbook workbook;

            var fn = _PFAD + "Portfolio2020.xlsx";
            var newFn = _PFAD + $"Portfolio{DateTime.Now:yyyyMMddHHmm}.xlsx";
            File.Copy(fn, newFn);
            using (var fs = new FileStream(fn, FileMode.Open, FileAccess.Read))
            {
                workbook = WorkbookFactory.Create(fs);                
                var dict = GetStockInfos(workbook);

                var shtAnalysis = workbook.GetSheet("Analysis");
                for (int i = 1; i < 100; i++)
                {
                    var r = shtAnalysis.GetRow(i);
                    if (r == null) break;
                    var stockname = r.GetCell(0)?.StringCellValue;
                    if (string.IsNullOrWhiteSpace(stockname) || !dict.ContainsKey(stockname)) continue;
                    var stockCount = r.GetCell(3)?.NumericCellValue;
                    if (!stockCount.HasValue || stockCount.Value <= 0) continue;
                    var price = Stock.GetQuote(dict[stockname]);
                    var marketValue = price * stockCount.Value;
                    var cellMarketValue = r.GetCell(5);
                    cellMarketValue.SetCellValue(marketValue);
                }
                shtAnalysis.GetRow(0).GetCell(5).SetCellValue(DateTime.Today.ToShortDateString());
            }


            using (var fs1 = new FileStream(newFn, FileMode.OpenOrCreate, FileAccess.Write))
                workbook.Write(fs1);

            workbook.Close();

        }

        public Dictionary<string, string> GetStockInfos(IWorkbook workbook)
        {
            var dict = new Dictionary<string, string>();
            // read stock infos (ISIN, WKN ...)
            var shInfo = workbook.GetSheet("info");
            for (int i = 1; i < 100; i++)
            {
                var r = shInfo.GetRow(i);
                if (r == null) break;
                var stockname = r.GetCell(0).ToString();
                if (string.IsNullOrWhiteSpace(stockname) || null == r.GetCell(1)) continue;
                dict.Add(stockname, r.GetCell(1).ToString());
            }
            return dict;
        }
    }

}
