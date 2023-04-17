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
        private static int columnsEnd = 10;
        private int testStepLine = 1;
        private string[,] outputXrayTests = new string[lineEnd - lineStart, columnsEnd - columnsStart];
        private string[,] outputXrayPreCondition = new string[lineEnd - lineStart, columnsEnd - columnsStart];

        public string[,] OutputXrayTestCase(List<TestCaseXray> testCaseXrayList)
        {
            if (testCaseXrayList != null)
            {
                outputXrayTests[1, 1] = "TCID";
                outputXrayTests[1, 2] = "Test Summary";
                outputXrayTests[1, 3] = "Test Priority";
                outputXrayTests[1, 4] = "Description";
                outputXrayTests[1, 5] = "Component";
                outputXrayTests[1, 6] = "Action";
                outputXrayTests[1, 7] = "Data";
                outputXrayTests[1, 8] = "Result";
                outputXrayTests[1, 9] = "Max number of executions";

                foreach (TestCaseXray testCaseXray in testCaseXrayList)
                {
                    for (int line = lineStart; line < lineEnd - lineStart; line++)
                    {
                        outputXrayTests[line, 1] = testCaseXray.TCID.ToString();
                        outputXrayTests[line, 2] = testCaseXray.TestSummary;
                        outputXrayTests[line, 3] = testCaseXray.TestPriority;
                        outputXrayTests[line, 4] = testCaseXray.Discription;
                        outputXrayTests[line, 5] = testCaseXray.Components;
                            
                        if (testCaseXray.TestCaseTestStepList  != null)
                        {
                            testStepLine = line;

                            foreach (TestStepXray testStepXray in testCaseXray.TestCaseTestStepList)
                            {
                                if (testCaseXray.TCID == testStepXray.TCID)
                                {                                    
                                    if (testStepLine == line)
                                    {
                                        outputXrayTests[testStepLine, 6] = testStepXray.TestStepAction;
                                        outputXrayTests[testStepLine, 7] = testStepXray.TestStepData;
                                        outputXrayTests[testStepLine, 8] = testStepXray.TestStepResult;
                                        outputXrayTests[testStepLine, 9] = testCaseXray.MaxExecutions;

                                        testStepLine++;
                                        line = testStepLine;
                                    }
                                    else
                                    {
                                        outputXrayTests[testStepLine, 1] = testCaseXray.TCID.ToString();
                                        outputXrayTests[testStepLine, 2] = "";
                                        outputXrayTests[testStepLine, 3] = "";
                                        outputXrayTests[testStepLine, 4] = "";
                                        outputXrayTests[testStepLine, 5] = "";
                                        outputXrayTests[testStepLine, 6] = testStepXray.TestStepAction;
                                        outputXrayTests[testStepLine, 7] = testStepXray.TestStepData;
                                        outputXrayTests[testStepLine, 8] = testStepXray.TestStepResult;
                                        outputXrayTests[testStepLine, 9] = testCaseXray.MaxExecutions;

                                        testStepLine++;
                                        line = testStepLine;
                                    }
                                }
                                else
                        {
                                    break;
                                }
                            }
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
