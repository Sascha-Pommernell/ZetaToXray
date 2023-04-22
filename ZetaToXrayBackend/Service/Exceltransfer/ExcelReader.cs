using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ZetaToXrayBackend.Service.Exceltransfer
{
    public class ExcelReader
    {
        private static int lineStart = 2;
        private static int columnsStart = 1;
        private static int lineEnd = 10000;
        private static int columnsEnd = 21;
        private string pathExcelRead;
        private object[,] input = new object[lineEnd - lineStart, columnsEnd - columnsStart];
        private string[,] excelArry = new string[lineEnd - lineStart, columnsEnd - columnsStart];

        public ExcelReader(string _pathExcelRead)
        {
            pathExcelRead = _pathExcelRead;
        }

        public string[,] CreateExcelArry()
        {
            Excel.Application application;
            Excel.Workbooks workbooks;
            Excel.Workbook workbook;
            Excel.Sheets sheets;
            Excel.Worksheet worksheet;
            Range cells;

            application = new Excel.Application();
            application.Visible = false;
            workbooks = application.Workbooks;
            workbook = workbooks.Open(pathExcelRead);
            sheets = workbook.Worksheets;
            worksheet = sheets.Item[1];
            cells = worksheet.Cells;
            application.Application.DisplayAlerts = false;

            Range range = (Range)worksheet.Range[worksheet.Cells[lineStart, columnsStart], worksheet.Cells[lineEnd, columnsEnd]];

            input = range.Value2;

            for (int cellLine = 2; cellLine <= lineEnd - lineStart; cellLine++)
            {
                for (int cellColumn = 1; cellColumn <= columnsEnd - columnsStart; cellColumn++)
                {
                    if (input[cellLine, 1] == null)
                    {
                        cellLine = lineEnd - lineStart + 1;
                        cellColumn = columnsEnd - columnsStart + 1;
                    }
                    else
                    {
                        excelArry[cellLine - 1, cellColumn - 1] = input[cellLine, cellColumn].ToString();
                    }
                }
            }

            ExcelProcessKill();
            
            return excelArry;
        }

        private void ExcelProcessKill()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process process in processes)
            {
                process.Kill();
            }
        }
    }
}
