using System.Collections.Generic;
using ZetaToXrayBackend.Model.Xray;
using ZetaToXrayBackend.Model.Zeta;

namespace ZetaToXrayBackend.Service.Converter
{
    public class ZetaXrayConverter
    {
        private bool testCaseInput = false;
        private string? tmpTeststep;
        private char[]? teststep;
        private TestStepXray testStepXray = new TestStepXray();
        private TestCaseXray testCaseXray = new TestCaseXray();
        private PreConditionXray preConditionXray = new PreConditionXray();
        private List<TestStepXray> testStepXrayList = new List<TestStepXray>();
        private List<TestCaseXray> testCaseXrayList = new List<TestCaseXray>();
        private List<PreConditionXray> preConditionXrayList = new List<PreConditionXray>();

        public List<TestStepXray> CreateTestStepXrayList(List<TestCaseZeta> testCaseZetaList)
        {
            if (testCaseZetaList != null)
            {
                foreach (TestCaseZeta testCaseZeta in testCaseZetaList)
                {
                    if (testCaseZeta.Testschritte != null)
                    {
                        teststep = testCaseZeta.Testschritte.ToCharArray();
                        for (int index = 0; index <= teststep.Length; index++)
                        {
                            if (teststep[index] != '.' && index < teststep.Length)
                            {
                                tmpTeststep = tmpTeststep + teststep[index];
                            }
                            else if (teststep[index] == '.' && index < teststep.Length)
                            {
                                tmpTeststep = tmpTeststep + ".";
                                testStepXray.TCID = testCaseZeta.TestFallID;
                                testStepXray.TestStepAction = tmpTeststep;
                                testStepXrayList.Add(testStepXray);
                                tmpTeststep = null;
                            }
                            else if (teststep[index] != '.' && index == teststep.Length)
                            {
                                tmpTeststep = tmpTeststep + teststep[index];
                                testStepXray.TCID = testCaseZeta.TestFallID;
                                testStepXray.TestStepAction = tmpTeststep;
                                testStepXrayList.Add(testStepXray);
                            }
                            else if (teststep[index] == '.' && index == teststep.Length)
                            {
                                tmpTeststep = tmpTeststep + ".";
                                testStepXray.TCID = testCaseZeta.TestFallID;
                                testStepXray.TestStepAction = tmpTeststep;
                                testStepXray.TestStepResult = testCaseZeta.ErwartetesErgebnis;
                                testStepXrayList.Add(testStepXray);
                                tmpTeststep = null;
                            }
                        }
                    }
                }

                return testStepXrayList;
            }
            else
            {
                return testStepXrayList;
            }
        }

        public List<TestCaseXray> CreateTestCaseXrayList(List<TestCaseZeta> testCaseZetasList, List<TestStepXray> testStepXrayList)
        {
            if (testCaseZetasList != null && testStepXrayList != null)
            {
                foreach (TestCaseZeta testCaseZeta in testCaseZetasList)
                {
                    testCaseXray.TCID = testCaseZeta.TestFallID;
                    testCaseXray.TestSummary = testCaseZeta.TestFallTitel;

                    if (testCaseZeta.Testpriorität == "3 - Niedrig  =  Kann")
                    {
                        testCaseXray.TestPriority = "Medium";
                    }
                    else if (testCaseZeta.Testpriorität == "2 - Mittel      =  Soll")
                    {
                        testCaseXray.TestPriority = "High";
                    }
                    else if (testCaseZeta.Testpriorität == "1 - Hoch = Muss")
                    {
                        testCaseXray.TestPriority = "Highest";
                    }
                    else if (testCaseZeta.Testpriorität == "")
                    {
                        testCaseXray.TestPriority = "Lowest";
                    }

                    testCaseXray.Discription = testCaseZeta.TestFallBeschreibung;
                    testCaseXray.Components = testCaseZeta.Hierachie;
                    testCaseXray.MaxExecutions = "1";

                    foreach (TestStepXray testStepXray in testStepXrayList)
                    {
                        if (testStepXray.TCID == testCaseZeta.TestFallID && testCaseInput == false)
                        {
                            if (testStepXray.TestStepResult != null)
                            {
                                testCaseXray.Action = testStepXray.TestStepAction;
                                testCaseXray.Data = "";
                                testCaseXray.Result = testStepXray.TestStepResult;
                            }
                            else
                            {
                                testCaseXray.Action = testStepXray.TestStepAction;
                                testCaseXray.Data = "";
                                testCaseXray.Result = "";
                            }

                            testCaseXrayList.Add(testCaseXray);
                            testCaseInput = true;
                        }
                        else if (testStepXray.TCID == testCaseZeta.TestFallID && testCaseInput == true)
                        {
                            if (testStepXray.TestStepResult != null)
                            {
                                testCaseXray.TCID = testCaseZeta.TestFallID;
                                testCaseXray.TestSummary = "";
                                testCaseXray.TestPriority = "";
                                testCaseXray.Discription = "";
                                testCaseXray.Components = "";
                                testCaseXray.MaxExecutions = "";
                                testCaseXray.Action = testStepXray.TestStepAction;
                                testCaseXray.Data = "";
                                testCaseXray.Result = testStepXray.TestStepResult;
                            }
                            else
                            {
                                testCaseXray.TCID = testCaseZeta.TestFallID;
                                testCaseXray.TestSummary = "";
                                testCaseXray.TestPriority = "";
                                testCaseXray.Discription = "";
                                testCaseXray.Components = "";
                                testCaseXray.MaxExecutions = "";
                                testCaseXray.Action = testStepXray.TestStepAction;
                                testCaseXray.Data = "";
                                testCaseXray.Result = "";
                            }

                            testCaseXrayList.Add(testCaseXray);
                        }
                        else if (testStepXray.TCID != testCaseZeta.TestFallID && testCaseInput == true)
                        {
                            testCaseInput = false;
                            break;
                        }
                    }
                }
            }

            return testCaseXrayList;
        }

        public List<PreConditionXray> CreatePreConditionXray(List<TestCaseZeta> testCaseZetaList)
        {
            return preConditionXrayList;
        }
    }
}
