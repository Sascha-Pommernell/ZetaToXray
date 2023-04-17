using System.Collections.Generic;
using ZetaToXrayBackend.Model;

namespace ZetaToXrayFrontend.Converter
{
    public class ZetaXrayConverter
    {
        private char[]? teststep;
        private string? tmpTeststep;
        private TestStepXray testStepXray = new TestStepXray();
        private TestCaseXray testCaseXray = new TestCaseXray();
        private TestStepXray tmptestStepXray = new TestStepXray();
        private PreConditionXray preConditionXray = new PreConditionXray();
        private List<TestStepXray> testStepXrayList = new List<TestStepXray>();
        private List<TestCaseXray> testCaseXrayList = new List<TestCaseXray>();
        private List<PreConditionXray> preConditionXrayList = new List<PreConditionXray>();

        public List<TestStepXray> CreateTestStepXrayList(List<TestCaseZeta> testCaseZetaList)
        {
            if(testCaseZetaList != null)
            {
                foreach(TestCaseZeta testCaseZeta in testCaseZetaList)
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
                                testStepXray.TestStepAction = tmpTeststep.ToString();
                                testStepXrayList.Add(testStepXray);
                                tmpTeststep = null;
                            } 
                            else if (teststep[index] != '.' && index == teststep.Length)
                            {
                                tmpTeststep = tmpTeststep + teststep[index];
                            }
                            else if (teststep[index] == '.' && index == teststep.Length)
                            {
                                tmpTeststep = tmpTeststep + ".";
                                testStepXray.TCID = testCaseZeta.TestFallID;
                                testStepXray.TestStepAction = tmpTeststep.ToString();
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
                foreach(TestCaseZeta testCaseZeta in testCaseZetasList)
                {
                    testCaseXray.TCID = testCaseZeta.TestFallID;
                    testCaseXray.TestSummary = testCaseZeta.TestFallTitel;
                    testCaseXray.TestPriority = testCaseZeta.Testpriorität;
                    testCaseXray.Discription = testCaseZeta.TestFallBeschreibung;
                    testCaseXray.Components = testCaseZeta.Hierachie;
                    testCaseXray.MaxExecutions = "1";
                    
                    foreach(TestStepXray testStepXray in testStepXrayList)
                    {
                        if(testStepXray.TCID == testStepXray.TCID)
                        {                            
                            if (testStepXray.TestStepResult != null)
                            {
                                tmptestStepXray.TCID = testStepXray.TCID;
                                tmptestStepXray.TestStepAction = testStepXray.TestStepAction;
                                tmptestStepXray.TestStepData = "";
                                tmptestStepXray.TestStepResult = testStepXray.TestStepResult;
                                
                                if(testCaseXray.TestCaseTestStepList != null)
                                {
                                    testCaseXray.TestCaseTestStepList.Add(tmptestStepXray);
                                }
                            }
                            else
                            {
                                tmptestStepXray.TCID = testStepXray.TCID;
                                tmptestStepXray.TestStepAction = testStepXray.TestStepAction;
                                tmptestStepXray.TestStepData = "";
                                
                                if (testCaseXray.TestCaseTestStepList != null)
                                {
                                    testCaseXray.TestCaseTestStepList.Add(tmptestStepXray);
                                }
                            }
                        }
                    }

                    testCaseXrayList.Add(testCaseXray);
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
