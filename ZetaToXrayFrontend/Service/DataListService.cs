using System;
using System.Collections.Generic;
using ZetaToXrayBackend.Model.Xray;
using ZetaToXrayBackend.Model.Zeta;
using ZetaToXrayBackend.Service;
using ZetaToXrayBackend.Service.Converter;
using ZetaToXrayBackend.Service.Exceltransfer;
using ZetaToXrayBackend.Service.Settingtransfer;

namespace ZetaToXrayFrontend.Service
{
    class DataListService
    {
        private List<TestCaseZeta> testCaseZetaList = new List<TestCaseZeta>();
        private List<TestStepXray> testStepXrays = new List<TestStepXray>();
        private List<TestCaseXray> testCaseXrays = new List<TestCaseXray>();
        private List<PreConditionXray> preConditionXrays = new List<PreConditionXray>();
        
        public List<TestCaseZeta> ZetaTestCaseListService()
        {
            SettingReader settingReader = new SettingReader();
            string excelImportPath = settingReader.ReadSettingExcelImport();
            ExcelReader excelReader = new ExcelReader(excelImportPath);
            ZetaTestCaseList zetaTestCaseList = new ZetaTestCaseList();
            testCaseZetaList = zetaTestCaseList.CreateTestCaseZetaList(excelReader.CreateExcelArry());

            return testCaseZetaList;
        }

        public List<TestCaseXray> XrayTestCaseListService()
        {
            ZetaXrayConverter converter = new ZetaXrayConverter();
            testStepXrays = converter.CreateTestStepXrayList(testCaseZetaList);
            testCaseXrays = converter.CreateTestCaseXrayList(testCaseZetaList, testStepXrays);

            return testCaseXrays;
        }

        public List<PreConditionXray> PreConditionXrayService()
        {
            ZetaXrayConverter converter = new ZetaXrayConverter();
            preConditionXrays = converter.CreatePreConditionXrayList(testCaseZetaList);

            return preConditionXrays;
        }
    }
}
