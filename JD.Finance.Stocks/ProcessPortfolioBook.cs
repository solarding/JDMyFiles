using ClosedXML.Excel;

namespace JD.Finance.Stocks
{
    internal class ProcessPortfolioBook
    {
        private const string _PFAD = @"d:\temp\";// @"C:\Users\solar\OneDrive\Finance\Wertpapier\";
        public void test()
        {      

            var fn = _PFAD + "Portfolio2020.xlsx";
            //var newFn = _PFAD + $"Portfolio{DateTime.Now:yyyyMMddHHmm}.xlsx";
            //File.Copy(fn, newFn);

            using (var workbook = new XLWorkbook(fn))
            {               
                var dict = GetStockInfos(workbook);
                var shtAnalysis = workbook.Worksheet("Analysis");

                IXLPivotTable xLPTable = shtAnalysis.PivotTable("PivotTable1");
                int topRow = xLPTable.TargetCell.Address.RowNumber;

                for (int i = topRow; i < 100; i++)
                {
                    var r = shtAnalysis.Row(i);
                    if (r == null) break;
                    var stockname = r.Cell("S").GetString();
                    if (string.IsNullOrWhiteSpace(stockname) || !dict.ContainsKey(stockname)) continue;
                    var stockCount = r.Cell("V").Value.IsText? 0: r.Cell("V").GetDouble();
                    if (stockCount <= 0) continue;
                    var price = Stock.GetQuote(dict[stockname]);
                    var marketValue = price * stockCount;
                    var cellMarketValue = r.Cell("F");
                    cellMarketValue.SetValue(marketValue);
                }
                shtAnalysis.Row(1).Cell(5).SetValue(DateTime.Today.ToShortDateString());

                workbook.Save();
            }

        }

        public Dictionary<string, string> GetStockInfos(XLWorkbook workbook)
        {
            var dict = new Dictionary<string, string>();
            // read stock infos (ISIN, WKN ...)
            var shInfo = workbook.Worksheet("info");
            for (int i = 1; i < 100; i++)
            {
                var r = shInfo.Row(i);
                if (r == null) break;
                var stockname = r.Cell(1).GetString();
                if (string.IsNullOrWhiteSpace(stockname) || null == r.Cell(2)) continue;
                dict.Add(stockname, r.Cell(2).GetString());
            }
            return dict;
        }
    }
}
