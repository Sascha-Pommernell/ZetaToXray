using System.Collections.Generic;
using ZetaToXrayBackend.Model.Zeta;

namespace ZetaToXrayBackend.Service
{
    public class ZetaTestCaseList
    {
        private static int lineStart = 1;
        private static int columnsStart = 1;
        private static int lineEnd = 1000;
        private static int columnsEnd = 21;
        private List<TestCaseZeta> testCaseZetaList = new List<TestCaseZeta>();

        public List<TestCaseZeta> CreateTestCaseZetaList(string[,] excelinput)
        {
            if (excelinput != null)
            {
                for (int cellLine = 1; cellLine < lineEnd - lineStart - 1; cellLine++)
                {
                    TestCaseZeta testCaseZeta = new TestCaseZeta();

                    testCaseZeta.TesteinheitTitel = excelinput[cellLine, 1];
                    testCaseZeta.TesteinheitBeschreibung = excelinput[cellLine, 2];                            
                    testCaseZeta.TestFallID = excelinput[cellLine, 3];                              
                    testCaseZeta.TestFallTitel = excelinput[cellLine, 4];                               
                    testCaseZeta.Hierachie = excelinput[cellLine, 4];                               
                    testCaseZeta.TestFallBeschreibung = excelinput[cellLine, 6];                               
                    testCaseZeta.Variante = excelinput[cellLine, 7];                            
                    testCaseZeta.TestfallDatum = excelinput[cellLine, 8];                                
                    testCaseZeta.TestFallErstBenutzer = excelinput[cellLine, 9];                             
                    testCaseZeta.TestFallAenderungsBenutzer = excelinput[cellLine, 10];                               
                    testCaseZeta.ErwartetesErgebnis = excelinput[cellLine, 11];                                
                    testCaseZeta.Vorbedingung = excelinput[cellLine, 12];                                
                    testCaseZeta.Testschritte = excelinput[cellLine, 13];                               
                    testCaseZeta.AnforderungsKapitelID = excelinput[cellLine, 14];                                
                    testCaseZeta.ReviewBearbeitungsstatus = excelinput[cellLine, 15];                              
                    testCaseZeta.ReviewGruppe = excelinput[cellLine, 16];                                
                    testCaseZeta.TFSRequirementBugID = excelinput[cellLine, 17];
                    testCaseZeta.Testpriorität = excelinput[cellLine, 18];                               
                    testCaseZeta.TFSRequirementFeature = excelinput[cellLine, 19];                                
                    testCaseZeta.Testdaten = excelinput[cellLine, 20];                               
                    testCaseZeta.JiraTicket = excelinput[cellLine, 21];                                

                    testCaseZetaList.Add(testCaseZeta);
                }
                return testCaseZetaList;
            }
            else
            {
                return testCaseZetaList;
            }
        }

        public List<TestCaseZeta> GetTestCaseZetaList()
        { 
            return testCaseZetaList;
        }
    }
}
