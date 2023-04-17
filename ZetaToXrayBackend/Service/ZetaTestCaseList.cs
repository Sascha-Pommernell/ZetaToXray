using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaToXrayBackend.Model;

namespace ZetaToXrayBackend.Service
{
    public class ZetaTestCaseList
    {
        private static int lineStart = 2;
        private static int columnsStart = 1;
        private static int lineEnd = 10000;
        private static int columnsEnd = 21;
        private TestCaseZeta testCaseZeta = new TestCaseZeta();
        private List<TestCaseZeta> testCaseZetaList = new List<TestCaseZeta>();

        public List<TestCaseZeta> CreateTestCaseZetaList(string[,] excelinput)
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
                                testCaseZeta.ReviewGruppe = excelinput[cellLine, 16];
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
    }
}
