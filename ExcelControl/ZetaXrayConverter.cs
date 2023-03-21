using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using ZetaToXray.ExcelControl;

namespace ZetaToXray.ExcelControl
{
    public class ZetaXrayConverter
    {
        private int lineStart = 2;
        private int columnsStart = 1;
        private int lineEnd = 10000;
        private int columnsEnd = 21;
        private string[,] outputExcelTestCase;
        private string[,] outputExcelPreCondition;
        private ExcelReader excelReader = new ExcelReader();
        private char[] testCase;


        private string[,] ExcelInput()
        {
            string [,]inputExcelArray = excelReader.CreateExcelArry();

            return inputExcelArray;            
        }
        
        public string[,] ExcelConverterTestCase()
        {
            string[,] testCase = ExcelInput();
            
            outputExcelTestCase[1, 1] = "TCID";
            outputExcelTestCase[1, 2] = "Test Summary";
            outputExcelTestCase[1, 3] = "Description";
            outputExcelTestCase[1, 4] = "Component";
            outputExcelTestCase[1, 5] = "Action";
            outputExcelTestCase[1, 6] = "Data";
            outputExcelTestCase[1, 7] = "Result";

            for (int cellLine = 2; cellLine <= lineEnd - lineStart; cellLine++)
            {
                for (int cellColumn = 1; cellColumn <= columnsEnd - columnsStart; cellColumn++)
                {
                    switch (cellColumn)
                    {
                        case 1:
                            outputExcelTestCase[cellLine, 4] = testCase[cellLine, 1];
                            break;                       
                        case 3:
                            outputExcelTestCase[cellLine, 1] = testCase[cellLine, 3];                           
                            break;
                        case 4:
                            outputExcelTestCase[cellLine, 2] = testCase[cellLine, 4];
                            break;                        
                        case 6:
                            outputExcelTestCase[cellLine, 3] = testCase[cellLine, 6];                            
                            break;
                        case 11:
                            outputExcelTestCase[cellLine, 7] = testCase[cellLine,11];
                            break;
                        case 13:
                            testCase = testCase[cellLine, 13].ToCharArray();
                            outputExcelTestCase[cellLine, 5] = testCase[cellLine, 13];
                            outputExcelTestCase[cellLine, 6] = testCase[cellLine, 13];
                            break;
                    }               
                }
            }

                    return outputExcelTestCase;
        }

        public string[,] ExcelConverterPreCondition()
        {
            return outputExcelPreCondition;
        }
        
    }
}
