using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using ZetaToXrayFrontend.ExcelControl;

namespace ZetaToXrayFrontend.Converter
{
    public class ZetaXrayConverter
    {
        private int lineStart = 2;
        private int columnsStart = 1;
        private int lineEnd = 10000;
        private int columnsEnd = 21;
        private string[,]? outputExcelTestCase;
        private string[,]? outputExcelPreCondition;
        private string[,] excelinput;
        private char[]? teststep;
        private int outputCellLine = 1;
        private string? action;
        private string? data;
        private string? tmpString;

        public ZetaXrayConverter(string[,] _excelinput)
        {
            excelinput = _excelinput;
        }      
        
        public string[,] ExcelConverterTestCase()
        {
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
                            outputExcelTestCase[outputCellLine, 4] = excelinput[cellLine, 1];
                            break;                       
                        case 3:
                            outputExcelTestCase[outputCellLine, 1] = excelinput[cellLine, 3];                           
                            break;
                        case 4:
                            outputExcelTestCase[outputCellLine, 2] = excelinput[cellLine, 4];
                            break;                        
                        case 6:
                            outputExcelTestCase[outputCellLine, 3] = excelinput[cellLine, 6];                            
                            break;
                        case 11:
                            outputExcelTestCase[outputCellLine, 7] = excelinput[cellLine,11];
                            break;
                        case 13:
                            teststep = excelinput[cellLine, 13].ToCharArray();
                            //action
                            outputExcelTestCase[outputCellLine, 5] = excelinput[cellLine, 13];
                            //data
                            outputExcelTestCase[outputCellLine, 6] = excelinput[cellLine, 13];
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
