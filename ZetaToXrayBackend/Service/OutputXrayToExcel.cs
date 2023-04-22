using System.Collections.Generic;
using ZetaToXrayBackend.Model.Xray;

namespace ZetaToXrayBackend.Service
{
    public class OutputXrayToExcel
    {
        private static int lineEnd = 10000;
        private static int columnsEnd = 9;
        private int line = 1;
        private string[,] outputXrayPreCondition = new string[lineEnd, columnsEnd];

        public string[,] OutputXrayTestCase(List<TestCaseXray> testCaseXrayList)
        {
            lineEnd = testCaseXrayList.Count;
            string[,] outputXrayTests = new string[lineEnd, columnsEnd];
            
            if (testCaseXrayList != null)
            {
                outputXrayTests[0, 0] = "TCID";
                outputXrayTests[0, 1] = "Test Summary";
                outputXrayTests[0, 2] = "Test Priority";
                outputXrayTests[0, 3] = "Description";
                outputXrayTests[0, 4] = "Component";
                outputXrayTests[0, 5] = "Action";
                outputXrayTests[0, 6] = "Data";
                outputXrayTests[0, 7] = "Result";
                outputXrayTests[0, 8] = "Max number of executions";

                foreach (TestCaseXray testCaseXray in testCaseXrayList)
                {
                    outputXrayTests[line, 0] = testCaseXray.TCID;
                    outputXrayTests[line, 1] = testCaseXray.TestSummary;
                    outputXrayTests[line, 2] = testCaseXray.TestPriority;
                    outputXrayTests[line, 3] = testCaseXray.Discription;
                    outputXrayTests[line, 4] = testCaseXray.Components;
                    outputXrayTests[line, 5] = testCaseXray.Action;
                    outputXrayTests[line, 6] = testCaseXray.Data;
                    outputXrayTests[line, 7] = testCaseXray.Result;
                    outputXrayTests[line, 8] = testCaseXray.MaxExecutions;
                    
                    line++;                    
                }
            }

            return outputXrayTests;
        }

        public string[,] OutputXrayPreCondition()
        {
            return outputXrayPreCondition;
        }
    }
}
