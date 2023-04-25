using System.Collections.Generic;
using ZetaToXrayBackend.Model.Zeta;

namespace ZetaToXrayBackend.Service
{
    public class ZetaTestCaseList
    {
        private static int lineStart = 2;
        private static int columnsStart = 1;
        private static int lineEnd = 10000;
        private static int columnsEnd = 21;
        private List<TestCaseZeta> testCaseZetaList = new List<TestCaseZeta>();

        public List<TestCaseZeta> CreateTestCaseZetaList(string[,] excelinput)
        {
            if (excelinput != null)
            {
                for (int cellLine = 1; cellLine <= lineEnd - lineStart - 1; cellLine++)
                {
                    TestCaseZeta testCaseZeta = new TestCaseZeta();

                    testCaseZeta.TesteinheitTitel = excelinput[cellLine, 0];
                    testCaseZeta.TesteinheitBeschreibung = excelinput[cellLine, 1];                            
                    testCaseZeta.TestFallID = excelinput[cellLine, 2];                              
                    testCaseZeta.TestFallTitel = excelinput[cellLine, 3];                               
                    testCaseZeta.Hierachie = excelinput[cellLine, 4];                               
                    testCaseZeta.TestFallBeschreibung = excelinput[cellLine, 5];                               
                    testCaseZeta.Variante = excelinput[cellLine, 6];                            
                    testCaseZeta.TestfallDatum = excelinput[cellLine, 7];                                
                    testCaseZeta.TestFallErstBenutzer = excelinput[cellLine, 8];                             
                    testCaseZeta.TestFallAenderungsBenutzer = excelinput[cellLine, 9];                               
                    testCaseZeta.ErwartetesErgebnis = excelinput[cellLine, 10];                                
                    testCaseZeta.Vorbedingung = excelinput[cellLine, 11];                                
                    testCaseZeta.Testschritte = excelinput[cellLine, 12];                               
                    testCaseZeta.AnforderungsKapitelID = excelinput[cellLine, 13];                                
                    testCaseZeta.ReviewBearbeitungsstatus = excelinput[cellLine, 14];                              
                    testCaseZeta.ReviewGruppe = excelinput[cellLine, 15];                                
                    testCaseZeta.TFSRequirementBugID = excelinput[cellLine, 16];
                    testCaseZeta.Testpriorität = excelinput[cellLine, 17];                               
                    testCaseZeta.TFSRequirementFeature = excelinput[cellLine, 18];                                
                    testCaseZeta.Testdaten = excelinput[cellLine, 19];                               
                    testCaseZeta.JiraTicket = excelinput[cellLine, 20];                                

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
