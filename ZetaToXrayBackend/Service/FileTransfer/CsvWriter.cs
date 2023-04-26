using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.IO;
using ZetaToXrayBackend.Model.Xray;
using Excel = Microsoft.Office.Interop.Excel;


namespace ZetaToXrayBackend.Service.FileTransfer
{
    public class CsvWriter
    {
        public void WriteExcelDatei(List<TestCaseXray> outputData ,string pathExcelWrite)
        {
            using (StreamWriter writer = new StreamWriter(pathExcelWrite))
            {
                writer.WriteLine("TCID;Test Summary;Test Priority;Discription;Components;Action;Data;Result;Max Executions");

                foreach (TestCaseXray testCaseXray in outputData)
                {
                    writer.WriteLine($"{testCaseXray.TCID};" +
                        $"{testCaseXray.TestSummary};" +
                        $"{testCaseXray.TestPriority};" +
                        $"{testCaseXray.Discription};" +
                        $"{testCaseXray.Components};" +
                        $"{testCaseXray.Action};" +
                        $"{testCaseXray.Data};" +
                        $"{testCaseXray.Result};" +
                        $"{testCaseXray.MaxExecutions}");
                }
            }
        }
    }
}
