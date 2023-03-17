using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using ZetaToXray.ExcelControl;

namespace ZetaToXray.ExcelControl
{
    public class ZetaXrayConverter
    {
        private string? excelPath;        
        private string[,]? inputExcelArray;
        private string[,]? outputExcelArray;
        private ExcelReader excelReader = new ExcelReader();        

        public string[,] ExcelConverterTestCase()
        {
            inputExcelArray = excelReader.CreateExcelRangeObject();



            return outputExcelArray;
        }
        
    }
}
