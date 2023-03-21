using System;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ZetaToXray.ExcelControl
{
    public class ExcelReader
    {
        private static int lineStart = 2;
        private static int columnsStart = 1;
        private static int lineEnd = 10000; 
        private static int columnsEnd = 21;

        
        private string pathExcelRead;
        private string[,]? excelRead;

        public string PathExcelRead 
        { 
            get => pathExcelRead;
            set
            {
                try
                {
                    if (value != null)
                    {
                        pathExcelRead = value;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Es wurde keine Dateipfad und keine Datei für den Import angegeben!\n" + ex.Message);
                }
                
            }            
        }

        public string[,] CreateExcelArry()
        {
            Excel.Application application;
            Excel.Workbooks workbooks;
            Excel.Workbook workbook;
            Excel.Sheets sheets;
            Excel.Worksheet worksheet;
            Excel.Range cells;

            application = new Excel.Application();
            application.Visible = false;
            workbooks = application.Workbooks;
            workbook = workbooks.Open(pathExcelRead);
            sheets = workbook.Worksheets;
            worksheet = sheets.Item[1];
            cells = worksheet.Cells;
            application.Application.DisplayAlerts = false;

            Range range = (Range)worksheet.Range[worksheet.Cells[lineStart, columnsStart], worksheet.Cells[lineEnd, columnsEnd]];

            object[,] input = range.Value2;
            string[,] excelArry = new string[lineEnd - lineStart, columnsEnd - columnsStart];

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

            return excelArry;            
        }
    }
}
