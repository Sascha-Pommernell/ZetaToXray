using System.Collections.Generic;
using ZetaToXrayBackend.Model.Xray;
using ZetaToXrayBackend.Model.Zeta;
using ZetaToXrayBackend.Service;
using ZetaToXrayBackend.Service.Converter;
using ZetaToXrayBackend.Service.Exceltransfer;

namespace ZetaToXrayFrontend.Service
{
    class DataListService
    {
        private List<TestCaseZeta> testCaseZetaList = new List<TestCaseZeta>();
        private List<TestStepXray> testStepXrays = new List<TestStepXray>();
        private List<TestCaseXray> testCaseXrays = new List<TestCaseXray>();
        private List<PreConditionXray> preConditionXrays = new List<PreConditionXray>();
        
        public List<TestCaseZeta> ZetaTestCaseListService(string excelImportPath)
        {
            ExcelReader excelReader = new ExcelReader(excelImportPath);
            ZetaTestCaseList zetaTestCaseList = new ZetaTestCaseList();
            testCaseZetaList = zetaTestCaseList.CreateTestCaseZetaList(excelReader.CreateExcelArry());

            return testCaseZetaList;
        }

        public List<TestCaseXray> XrayTestCaseListService(List<TestCaseZeta> testCaseZetaList)
        {
            ZetaXrayConverter converter = new ZetaXrayConverter();
            testCaseXrays = converter.CreateTestCaseXrayList(testCaseZetaList, testStepXrays);

            return testCaseXrays;
        }

        public List<PreConditionXray> PreConditionXrayService(List<TestCaseZeta> testCaseZetaList)
        {
            ZetaXrayConverter converter = new ZetaXrayConverter();
            preConditionXrays = converter.CreatePreConditionXrayList(testCaseZetaList);

            return preConditionXrays;
        }
    }
}
