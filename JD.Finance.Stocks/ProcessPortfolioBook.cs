using ClosedXML.Excel;

namespace JD.Finance.Stocks
{
    internal class ProcessPortfolioBook
    {
        private const string _PFAD = @"d:\temp\";// @"C:\Users\solar\OneDrive\Finance\Wertpapier\";
        public void test()
        {      
            var fn = _PFAD + "Portfolio2020.xlsx";

            using (var workbook = new XLWorkbook(fn))
            {               
                var dict = GetStockInfos(workbook);
                System.Diagnostics.Debug.WriteLine($"Dict count: {dict.Count}");
                foreach (var key in dict.Keys.Take(10))
                {
                    System.Diagnostics.Debug.WriteLine($"  Key: '{key}'");
                }
                
                var shtAnalysis = workbook.Worksheet("Analysis");
                IXLPivotTable xLPTable = shtAnalysis.PivotTable("PivotTable1");
                int topRow = xLPTable.TargetCell.Address.RowNumber;

                System.Diagnostics.Debug.WriteLine($"PivotTable TargetCell: {xLPTable.TargetCell.Address}");
                System.Diagnostics.Debug.WriteLine($"TopRow: {topRow}");

                // Check what's actually in the rows
                for (int i = topRow; i < topRow + 20; i++)
                {
                    var r = shtAnalysis.Row(i);
                    var cellA = r.Cell("A");
                    var cellB = r.Cell("B");
                    var cellE = r.Cell("E");
                    
                    System.Diagnostics.Debug.WriteLine($"Row {i}: A='{cellA.GetString()}' B='{cellB.GetString()}' E='{cellE.GetString()}' (A.Empty={cellA.IsEmpty()})");
                }

                int processedCount = 0;
                var analyzedStocks = new List<string>();
                for (int i = topRow + 1; i < 100; i++)
                {
                    var r = shtAnalysis.Row(i);
                    if (r == null) break;
                    
                    var stocknameCell = r.Cell("A");    
                    if (stocknameCell.IsEmpty()) continue;
                    
                    var stockname = stocknameCell.GetString()?.Trim() ?? string.Empty;
                    analyzedStocks.Add(stockname);
                    
                    if (analyzedStocks.Count <= 15)
                    {
                        System.Diagnostics.Debug.WriteLine($"Row {i}: Analysis='{stockname}' - InDict: {dict.ContainsKey(stockname)}");
                    }
                    
                    if (string.IsNullOrWhiteSpace(stockname) || !dict.ContainsKey(stockname)) continue;
                    
                    var stockCount = r.Cell("E").Value.IsText ? 0 : r.Cell("E").GetDouble();
                    if (stockCount <= 0) continue;
                    
                    var price = Stock.GetQuote(dict[stockname]);
                    var marketValue = price * stockCount;
                    var cellMarketValue = r.Cell("F");
                    cellMarketValue.SetValue(marketValue);
                    processedCount++;
                }
                
                System.Diagnostics.Debug.WriteLine($"Processed {processedCount} rows");
                System.Diagnostics.Debug.WriteLine($"All stocks in Analysis: {string.Join(", ", analyzedStocks.Take(20))}");
                shtAnalysis.Row(1).Cell(5).SetValue(DateTime.Today.ToShortDateString());
                workbook.Save();
            }

        }

        public Dictionary<string, string> GetStockInfos(XLWorkbook workbook)
        {
            var dict = new Dictionary<string, string>();
            // read stock infos (ISIN, WKN ...)
            var shInfo = workbook.Worksheet("info");
            for (int i = 2; i < 100; i++)  // Start at row 2 to skip header
            {
                var r = shInfo.Row(i);
                if (r == null) break;
                var stockname = r.Cell(1).GetString()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(stockname)) break;  // Stop at first empty row
                var isin = r.Cell(2).GetString()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(isin))
                {
                    dict.Add(stockname, isin);
                }
            }
            return dict;
        }
    }
}
