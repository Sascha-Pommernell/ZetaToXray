using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZetaToXrayBackend.Model.Xray;
using Excel = Microsoft.Office.Interop.Excel;


namespace ZetaToXrayBackend.Service.FileTransfer
{
    public class CsvWriter
    {
        public void WriteXrayTestCaseCSV(List<TestCaseXray> outputData ,string pathExportTestCase)
        {
            using (StreamWriter writer = new StreamWriter(pathExportTestCase, false, Encoding.UTF8, 512))
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

        public void WriteXrayPreConditionCSV (List<PreConditionXray> outputData ,string pathExportPreCondition)
        {
            using (StreamWriter writer= new StreamWriter(pathExportPreCondition, false, Encoding.UTF8,512))
            {
                writer.WriteLine("Assigen;Condition;Description;IssueType;Reporter;Summary;Test Associated Pre-Condition");

                foreach (PreConditionXray preConditionXray in outputData)
                {
                   writer.WriteLine($"{preConditionXray.Assigen};" +
                        $"{preConditionXray.Condition};" +
                        $"{preConditionXray.Description};" +
                        $"{preConditionXray.IssueType};" +
                        $"{preConditionXray.Type}" +
                        $"{preConditionXray.Reporter};" +
                        $"{preConditionXray.Summary};" +
                        $"{preConditionXray.TestsAssociatedPreCondition}");
                }
            }
        }
    }
}
