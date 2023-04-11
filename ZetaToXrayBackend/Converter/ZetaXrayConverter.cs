using System.Collections.Generic;
using ZetaToXrayBackend.Model;

namespace ZetaToXrayFrontend.Converter
{
    public class ZetaXrayConverter
    {
        private int lineStart = 2;
        private int columnsStart = 1;
        private int lineEnd = 10000;
        private int columnsEnd = 21;
        private string[,] outputXrayTests;
        private string[,] outputXrayPreCondition;
        private string[,] excelinput;
        private char[]? teststep;
        private string? tmpTeststep;
        private TestCaseZeta testCaseZeta = new TestCaseZeta();
        private TestStepXray testStepXray = new TestStepXray();
        private List<TestCaseZeta> testCaseZetaList = new List<TestCaseZeta>();
        private List<TestStepXray> testStepXrayList = new List<TestStepXray>();

        public ZetaXrayConverter(string[,] _excelinput)
        {
            if (_excelinput != null)
            {
                excelinput = _excelinput;
                CreateTestCaseZetaList(excelinput);
                if (testCaseZetaList != null)
                {
                    CreateTestStepXrayList(testCaseZetaList);
                    if (testStepXrayList != null)
                    {
                        ConverterOutput(testCaseZetaList, testStepXrayList);
                    }
                }
            }
        }

        
        private List<TestCaseZeta> CreateTestCaseZetaList(string[,] excelinput)
        {
            if (excelinput != null)
            {
                for (int cellLine = 2; cellLine <= lineEnd - lineStart; cellLine++)
                {
                    for (int cellColumn = 1; cellColumn <= columnsEnd - columnsStart; cellColumn++)
                    {
                        switch (cellColumn)
                        {
                            case 1:
                                testCaseZeta.TesteinheitTitel = excelinput[cellLine, 1];
                                break;
                            case 2:
                                testCaseZeta.TesteinheitBeschreibung = excelinput[cellLine, 2];
                                break;
                            case 3:
                                testCaseZeta.TestFallID = int.Parse(excelinput[cellLine, 3]);
                                break;
                            case 4:
                                testCaseZeta.TestFallTitel = excelinput[cellLine, 4];
                                break;
                            case 5:
                                testCaseZeta.Hierachie = excelinput[cellLine, 5];
                                break;
                            case 6:
                                testCaseZeta.TestFallBeschreibung = excelinput[cellLine, 6];
                                break;
                            case 7:
                                testCaseZeta.Variante = excelinput[cellLine, 7];
                                break;
                            case 8:
                                testCaseZeta.TestfallDatum = excelinput[cellLine, 8];
                                break;
                            case 9:
                                testCaseZeta.TestFallErstBenutzer = excelinput[cellLine, 9];
                                break;
                            case 10:
                                testCaseZeta.TestFallAenderungsBenutzer = excelinput[cellLine, 10];
                                break;
                            case 11:
                                testCaseZeta.ErwartetesErgebnis = excelinput[cellLine, 11];
                                break;
                            case 12:
                                testCaseZeta.Vorbedingung = excelinput[cellLine, 12];
                                break;
                            case 13:
                                testCaseZeta.Testschritte = excelinput[cellLine, 13];
                                break;
                            case 14:
                                testCaseZeta.AnforderungsKapizelID = excelinput[cellLine, 14];
                                break;
                            case 15:
                                testCaseZeta.ReviewBearbeitungsstatus = excelinput[cellLine, 15];
                                break;
                            case 16:
                                testCaseZeta.RevierGruppe = excelinput[cellLine, 16];
                                break;
                            case 17:
                                testCaseZeta.TFSRequirementBugID = excelinput[cellLine, 17];
                                break;
                            case 18:
                                testCaseZeta.Testpriorität = excelinput[cellLine, 18];
                                break;
                            case 19:
                                testCaseZeta.TFSRequirementFeature = excelinput[cellLine, 19];
                                break;
                            case 20:
                                testCaseZeta.Testdaten = excelinput[cellLine, 20];
                                break;
                            case 21:
                                testCaseZeta.JiraTicket = excelinput[cellLine, 21];
                                break;
                        }
                    }
                    testCaseZetaList.Add(testCaseZeta);
                }
                return testCaseZetaList;
            }
            else
            {
                return testCaseZetaList;
            }
        }

        private List<TestStepXray> CreateTestStepXrayList(List<TestCaseZeta> testCaseZetaList)
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
                                testStepXray.Aktion = tmpTeststep.ToString();
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
                                testStepXray.Aktion = tmpTeststep.ToString();
                                testStepXray.Ergebnis = testCaseZeta.ErwartetesErgebnis;
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
        
        private string[,] ConverterOutput(List<TestCaseZeta> testCaseZetasList, List<TestStepXray> testStepXrayList)
        {
            if (testCaseZetasList != null && testStepXrayList != null)
            {

            }
            
            return outputXrayTests;
        }

        public string[,] ExcelConverterPreCondition()
        {
            return outputXrayPreCondition;
        }
        
    }
}
