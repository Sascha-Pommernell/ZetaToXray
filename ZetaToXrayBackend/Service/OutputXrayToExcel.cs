using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaToXrayBackend.Model;

namespace ZetaToXrayBackend.Service
{
    public class OutputXrayToExcel
    {
        private static int lineStart = 2;
        private static int columnsStart = 1;
        private static int lineEnd = 10000;
        private static int columnsEnd = 21;
        private string[,] outputXrayTests = new string[lineEnd - lineStart, columnsEnd - columnsStart];
        private string[,] outputXrayPreCondition = new string[lineEnd - lineStart, columnsEnd - columnsStart];

        public string[,] OutputXrayTestCase(List<TestCaseXray> testCaseXrayList)
        {
            if (testCaseXrayList != null)
            {
                outputXrayTests[1, 1] = "TCID";
                outputXrayTests[1, 2] = "Test Summary";
                outputXrayTests[1, 3] = "Description";
                outputXrayTests[1, 4] = "Component";
                outputXrayTests[1, 5] = "Action";
                outputXrayTests[1, 6] = "Data";
                outputXrayTests[1, 7] = "Result";
                outputXrayTests[1, 8] = "Max number of executions";

                foreach (TestCaseXray testCaseXray in testCaseXrayList)
                {
                    for (int line = lineStart; line < lineEnd - lineStart; line++)
                    {
                        for (int column = columnsStart; column < columnsEnd - columnsStart; column++)
                        {
                            outputXrayTests[line, column] = testCaseXray.TCID.ToString();
                            outputXrayTests[line, column] = testCaseXray.TestSummary;
                        }
                    }
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
