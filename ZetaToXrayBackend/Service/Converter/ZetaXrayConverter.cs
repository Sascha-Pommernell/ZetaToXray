using System.Collections.Generic;
using ZetaToXrayBackend.Model.Xray;
using ZetaToXrayBackend.Model.Zeta;

namespace ZetaToXrayBackend.Service.Converter
{
    public class ZetaXrayConverter
    {
        private bool testCaseInput = true;
        private string? tmpTeststep;
        private char[] teststep = null!;
        private int index = 0;
        private List<TestStepXray> testStepXrayList = new List<TestStepXray>();
        private List<TestCaseXray> testCaseXrayList = new List<TestCaseXray>();
        private List<PreConditionXray> preConditionXrayList = new List<PreConditionXray>();

        private List<TestStepXray> CreateTestStepXrayList(TestCaseZeta testCaseZeta)
        {
            testStepXrayList.Clear();
            if (testCaseZeta != null)
            {
                if (testCaseZeta.Testschritte != null)
                {
                    teststep = testCaseZeta.Testschritte.ToCharArray();
                    for (int index = 0; index < teststep.Length; index++)
                    {
                        if (teststep[index] != '.' && index < teststep.Length)
                        {
                            tmpTeststep = tmpTeststep + teststep[index];
                        }
                        else if (teststep[index] == '.' && index +1 < teststep.Length)
                        {
                            TestStepXray testStepXray = new TestStepXray();
                            tmpTeststep = tmpTeststep + ".";
                            testStepXray.TCID = testCaseZeta.TestFallID;
                            testStepXray.TestStepAction = tmpTeststep;
                            testStepXrayList.Add(testStepXray);
                            tmpTeststep = null;
                        }
                        else if (teststep[index] == '.' && index < teststep.Length)
                        {
                            TestStepXray testStepXray = new TestStepXray();
                            tmpTeststep = tmpTeststep + ".";
                            testStepXray.TCID = testCaseZeta.TestFallID;
                            testStepXray.TestStepAction = tmpTeststep;
                            testStepXray.TestStepResult = testCaseZeta.ErwartetesErgebnis;
                            testStepXrayList.Add(testStepXray);
                            tmpTeststep = null;
                        }
                    }
                    return testStepXrayList;
                }
                return testStepXrayList;
            }
            return testStepXrayList;
        }

        private void ConvertTestSteps(TestCaseZeta testCaseZeta)
        {
            foreach (TestStepXray testStepXray in testStepXrayList)
            {
                TestCaseXray testCaseXray = new TestCaseXray();

                if (testStepXray.TCID == testCaseZeta.TestFallID && testCaseInput == true)
                {
                    if (testStepXray.TestStepResult != "")
                    {
                        testCaseXray.TCID = testCaseZeta.TestFallID;
                        testCaseXray.TestSummary = testCaseZeta.TestFallTitel.Replace("\r\n", " ");

                        if (testCaseZeta.Testpriorität.Contains('3') == true)
                        {
                            testCaseXray.TestPriority = "Medium";
                        }
                        else if (testCaseZeta.Testpriorität.Contains('2') == true)
                        {
                            testCaseXray.TestPriority = "High";
                        }
                        else if (testCaseZeta.Testpriorität.Contains('1') == true)
                        {
                            testCaseXray.TestPriority = "Highest";
                        }
                        else if (testCaseZeta.Testpriorität == "")
                        {
                            testCaseXray.TestPriority = "Lowest";
                        }

                        testCaseXray.Discription = testCaseZeta.TestFallBeschreibung.Replace("\r\n", " ");
                        testCaseXray.Components = testCaseZeta.Hierachie.Replace("\r\n", " ");
                        testCaseXray.MaxExecutions = "1";
                        testCaseXray.Action = testStepXray.TestStepAction.Replace("\r\n", " ");
                        testCaseXray.Data = "";
                        testCaseXray.Result = testStepXray.TestStepResult.Replace("\r\n", " ");
                    }
                    else
                    {
                        testCaseXray.TCID = testCaseZeta.TestFallID;
                        testCaseXray.TestSummary = testCaseZeta.TestFallTitel.Replace("\r\n", " ");

                        if (testCaseZeta.Testpriorität.Contains('3') == true)
                        {
                            testCaseXray.TestPriority = "Medium";
                        }
                        else if (testCaseZeta.Testpriorität.Contains('2') == true)
                        {
                            testCaseXray.TestPriority = "High";
                        }
                        else if (testCaseZeta.Testpriorität.Contains('1') == true)
                        {
                            testCaseXray.TestPriority = "Highest";
                        }
                        else if (testCaseZeta.Testpriorität == "")
                        {
                            testCaseXray.TestPriority = "Lowest";
                        }

                        testCaseXray.Discription = testCaseZeta.TestFallBeschreibung.Replace("\r\n", " ");
                        testCaseXray.Components = testCaseZeta.Hierachie.Replace("\r\n", " ");
                        testCaseXray.MaxExecutions = "1";
                        testCaseXray.Action = testStepXray.TestStepAction.Replace("\r\n", " ");
                        testCaseXray.Data = "";
                        testCaseXray.Result = "";
                    }
                    testCaseInput = false;
                    testCaseXrayList.Add(testCaseXray);
                }
                else if (testStepXray.TCID == testCaseZeta.TestFallID && testCaseInput == false)
                {
                    if (testStepXray.TestStepResult != "")
                    {
                        testCaseXray.TCID = testCaseZeta.TestFallID;
                        testCaseXray.TestSummary = "";
                        testCaseXray.TestPriority = "";
                        testCaseXray.Discription = "";
                        testCaseXray.Components = "";
                        testCaseXray.MaxExecutions = "";
                        testCaseXray.Action = testStepXray.TestStepAction.Replace("\r\n", " ");
                        testCaseXray.Data = "";
                        testCaseXray.Result = testStepXray.TestStepResult.Replace("\r\n", " ");
                    }
                    else
                    {
                        testCaseXray.TCID = testCaseZeta.TestFallID;
                        testCaseXray.TestSummary = "";
                        testCaseXray.TestPriority = "";
                        testCaseXray.Discription = "";
                        testCaseXray.Components = "";
                        testCaseXray.MaxExecutions = "";
                        testCaseXray.Action = testStepXray.TestStepAction.Replace("\r\n", " "); 
                        testCaseXray.Data = "";
                        testCaseXray.Result = "";
                    }
                    testCaseXrayList.Add(testCaseXray);
                }
                else if (testStepXray.TCID != testCaseZeta.TestFallID)
                {
                    break;
                }
            }
        }

        public List<TestCaseXray> CreateTestCaseXrayList(List<TestCaseZeta> testCaseZetasList, List<TestStepXray> testStepXrayList)
        {
            if (testCaseZetasList != null && testStepXrayList != null)
            {
                
                for (index = 0; index < testCaseZetasList.Count; index++) 
                {
                    testCaseInput = true;
                    TestCaseZeta testCaseZeta = new TestCaseZeta();
                    testCaseZeta = testCaseZetasList[index];
                    CreateTestStepXrayList(testCaseZeta);
                    ConvertTestSteps(testCaseZeta);            
 
                }
            }

            return testCaseXrayList;
        }

        public List<PreConditionXray> CreatePreConditionXrayList(List<TestCaseZeta> testCaseZetaList)
        {
            foreach (var testCase in testCaseZetaList)
            {
                PreConditionXray preConditionXray = new PreConditionXray();

                if(testCase.TestFallID != "")
                {
                    preConditionXray.Summary = testCase.TestFallTitel.Replace("\r\n", " ");
                    preConditionXray.Assigen = "admin";
                    preConditionXray.Reporter = "admin";
                    //https://docs.getxray.app/display/XRAY30/Issue+Type+Mapping
                    preConditionXray.IssueType = "10";
                    preConditionXray.Type = "Manual";
                    preConditionXray.Condition = testCase.Vorbedingung.Replace("\r\n", " ");
                    preConditionXray.Description = testCase.TestFallBeschreibung.Replace("\r\n", " ");
                    preConditionXray.TestsAssociatedPreCondition = testCase.TestFallID.Replace("\r\n", " ");

                    preConditionXrayList.Add(preConditionXray);
                }
                else
                {
                    break;
                }
            }
            return preConditionXrayList;
        }


    }
}
