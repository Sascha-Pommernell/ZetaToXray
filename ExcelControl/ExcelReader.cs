﻿using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ZetaToXray.ExcelControl
{
    public class ExcelReader
    {
        private static int lineStart = 1;
        private static int columnsStart = 1;
        private static int lineEnd = 2000; 
        private static int columnsEnd = 21;

        
        private string pathExcelRead = @"C:\";
        private string[,]? excelRead;

        public string PathExcelRead { get => pathExcelRead; set => pathExcelRead = value; }

        public string[,] CreateExcelRangeObject()
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

            return excelArry;            
        }
    }
}