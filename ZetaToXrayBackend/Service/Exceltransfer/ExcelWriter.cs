using Microsoft.Office.Interop.Excel;

using Excel = Microsoft.Office.Interop.Excel;


namespace ZetaToXrayBackend.Service.Exceltransfer
{
    public class ExcelWriter
    {
        private string pathExcelWrite;

        public ExcelWriter(string _pathExcelWrite)
        {
            pathExcelWrite = _pathExcelWrite;
        }

        public void WriteExcelDatei(string[,] outputData)
        {
            Excel.Application application;
            Excel.Workbook workbook = new Workbook();
            Excel.Worksheet worksheet = workbook.Worksheets[0];

            application = new Excel.Application();
            application.Visible = false;
            application.Application.DisplayAlerts = false;

            worksheet.get_Range("A1", "I10000").Value2 = outputData;
            workbook.SaveAs(pathExcelWrite + "XrayImportdaten.xlsx", XlFileFormat.xlWorkbookDefault, application);
            ExcelProcessKill();
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
